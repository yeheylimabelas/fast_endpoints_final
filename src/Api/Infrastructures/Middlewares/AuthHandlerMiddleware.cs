// -----------------------------------------------------------------------------------
// AuthHandlerMiddleware.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Net.Http;
using System.Threading;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MSCoip.Application.Common.Models;
using MSCoip.Infrastructure.Services;

namespace MSCoip.Api.Infrastructures.Middlewares;

/// <summary>
/// AuthHandlerMiddleware
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AuthHandlerMiddleware"/> class.
/// </remarks>
/// <param name="_next"></param>
/// <param name="_appSetting"></param>
/// <param name="_logger"></param>
public class AuthHandlerMiddleware(
    RequestDelegate _next,
    AppSetting _appSetting,
    ILogger<AuthHandlerMiddleware> _logger)
{
    /// <summary>
    /// Invoke
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Invoke(HttpContext context)
    {
        var whitelistPathSegment =
            _appSetting.AuthorizationServer.WhiteListPathSegment?.Split(",").ToList() ?? [];
        var requiredCheck = !whitelistPathSegment.Exists(
            item => context.Request.Path.StartsWithSegments(item));

        if (requiredCheck)
        {
            _logger.LogDebug("Authenticating");
            var auth = await CheckAuthAsync(context).ConfigureAwait(false);
            if (!auth.Succeeded)
            {
                await context.ChallengeAsync().ConfigureAwait(false);
                return;
            }
        }

        await _next(context).ConfigureAwait(false);
    }

    private static async Task<AuthenticateResult> CheckAuthAsync(HttpContext context)
    {
        var auth = context.RequestServices.GetRequiredService<IAuthenticationService>();
        return await auth.AuthenticateAsync(context, scheme: JwtBearerDefaults.AuthenticationScheme)
            .ConfigureAwait(false);
    }
}

/// <summary>
/// AuthHandlerMiddlewareExtensions
/// </summary>
public static class AuthHandlerMiddlewareExtensions
{
    /// <summary>
    /// UseAuthHandler
    /// </summary>
    /// <param name="builder"></param>
    public static void UseAuthHandler(this IApplicationBuilder builder)
    {
        builder.UseAuthentication();
        builder.UseAuthorization();
        builder.UseMiddleware<AuthHandlerMiddleware>();
    }

    /// <summary>
    /// AddPermissions
    /// </summary>
    /// <param name="services"></param>
    /// <param name="appSetting"></param>
    public static void AddPermissions(this IServiceCollection services, AppSetting appSetting)
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = appSetting.AuthorizationServer.Address;
                options.Audience = appSetting.AuthorizationServer.Service;
                options.RequireHttpsMetadata = false;
                options.BackchannelHttpHandler = new HttpHandler(new HttpClientHandler())
                {
                    UsingCircuitBreaker = true,
                    UsingWaitRetry = true,
                    RetryCount = 4,
                    SleepDuration = 1000
                };
            });

        services.AddAuthorization(options =>
        {
            var policy = appSetting.AuthorizationServer.Policy ?? [];
            policy.ForEach(p =>
            {
                if (p != null)
                {
                    options.AddPolicy(p.Name, pol => pol.Requirements.Add(new Permission(p.Name)));
                }
            });
        });

        services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
    }
}

/// <summary>
/// AuthorizationPolicyProvider
/// </summary>
public class AuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
{
    private readonly AuthorizationOptions _options;
    private static readonly SemaphoreSlim SemaphoreSlim = new(1);

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorizationPolicyProvider"/> class.
    /// </summary>
    /// <param name="options"></param>
    public AuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
        : base(options)
    {
        _options = options.Value;
    }

    /// <inheritdoc/>
    public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
        SemaphoreSlim.Wait();

        var policy = await base.GetPolicyAsync(policyName).ConfigureAwait(false);

        if (policy == null)
        {
            policy = new AuthorizationPolicyBuilder()
                .AddRequirements(new Permission(policyName))
                .Build();

            _options.AddPolicy(policyName, policy);
        }

        SemaphoreSlim.Release();

        return policy;
    }
}
