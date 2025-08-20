// -----------------------------------------------------------------------------------
// AuthHandlerMiddlewareLocal.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MSCoip.Api.Infrastructures.Handlers;
using MSCoip.Application.Common.Models;

namespace MSCoip.Api.Infrastructures.Middlewares;

/// <summary>
/// AuthHandlerMiddlewareLocal
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AuthHandlerMiddlewareLocal"/> class.
/// </remarks>
/// <param name="_next"></param>
public class AuthHandlerMiddlewareLocal(RequestDelegate _next)
{
    /// <summary>
    /// Invoke
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Invoke(HttpContext context)
    {
        await _next(context).ConfigureAwait(false);
    }
}

/// <summary>
/// AuthHandlerMiddlewareLocalExtensions
/// </summary>
public static class AuthHandlerMiddlewareLocalExtensions
{
    /// <summary>
    /// UseAuthHandler
    /// </summary>
    /// <param name="builder"></param>
    public static void UseLocalAuthHandler(this IApplicationBuilder builder)
    {
        builder.UseAuthentication();
        builder.UseAuthorization();
        builder.UseMiddleware<AuthHandlerMiddlewareLocal>();
    }

    /// <summary>
    /// AddPermissions
    /// </summary>
    /// <param name="services"></param>
    /// <param name="appSetting"></param>
    public static void AddLocalPermissions(this IServiceCollection services, AppSetting appSetting)
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultScheme = LocalAuthenticationHandler.AuthScheme;
                options.DefaultAuthenticateScheme = LocalAuthenticationHandler.AuthScheme;
                options.DefaultChallengeScheme = LocalAuthenticationHandler.AuthScheme;
            })
            .AddScheme<AuthenticationSchemeOptions, LocalAuthenticationHandler>(
                LocalAuthenticationHandler.AuthScheme,
                _ => { });
    }
}
