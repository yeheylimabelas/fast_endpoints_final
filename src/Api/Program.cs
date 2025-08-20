using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MSCoip.Api;
using MSCoip.Api.Infrastructures.Handlers;
using MSCoip.Api.Infrastructures.Middlewares;
using MSCoip.Application;
using MSCoip.Application.Common.Models;
using MSCoip.Domain.Constants;
using NSwag;
using Serilog;
using Serilog.Filters;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, true);
builder
    .Configuration
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, false);
builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, true);
builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddCommandLine(args);

var appSetting = builder.Configuration.Get<AppSetting>();

builder
    .WebHost
    .UseKestrel(option =>
    {
        option.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(
            appSetting.Kestrel.KeepAliveTimeoutInM);
        option.Limits.MinRequestBodyDataRate = new MinDataRate(
            appSetting.Kestrel.MinRequestBodyDataRate.BytesPerSecond,
            TimeSpan.FromSeconds(appSetting.Kestrel.MinRequestBodyDataRate.GracePeriod));
        option.Limits.MinResponseDataRate = new MinDataRate(
            appSetting.Kestrel.MinResponseDataRate.BytesPerSecond,
            TimeSpan.FromSeconds(appSetting.Kestrel.MinResponseDataRate.GracePeriod));
        option.AddServerHeader = false;
    });

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Environment, appSetting);
builder.Services.AddApiServices(builder.Environment, appSetting);

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

if (!appSetting.IsEnableDetailError)
{
    Log.Debug("Activate exception middleware");
    builder.Services.AddExceptionHandler<CustomExceptionHandler>();
}
else
{
    Log.Warning("Enable detail error response");
}

var memoryCache = builder.Services.BuildServiceProvider().GetService<IMemoryCache>();
var sink = new LogEventSinkHandler(appSetting, memoryCache);

builder
    .Host
    .UseSerilog(
        (hostingContext, loggerConfiguration) =>
        {
            // This is configuration serilog option using abstraction app setting
            loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
            loggerConfiguration
                .Filter
                .ByExcluding(
                    Matching.FromSource<Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware>());

            loggerConfiguration
                .ReadFrom
                .Configuration(hostingContext.Configuration)
                .WriteTo
                .Sink(sink);
        });

var app = builder.Build();

app.UseCorsOriginHandler(appSetting);

app.UseCspHandler(appSetting);
app.UseHstsHandler(appSetting);

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsHandler(app.Environment, appSetting);
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();

    RegisteredServicesPage(app, builder.Services);

    var option = new RewriteOptions();

    option.AddRedirect("^$", "swagger");
    app.UseRewriter(option);
}
else
{
    app.UseHsts();
}

app.UseHealthCheck();
app.UseSwaggerHandler();
app.UseHttpsRedirection();
app.UseResponseCompression();

if (appSetting.IsEnableAuth)
{
    Log.Information("Activate auth middleware");

    if (builder.Environment.EnvironmentName == EnvironmentConstants.NameTest)
    {
        app.UseLocalAuthHandler();
    }
    else
    {
        app.UseAuthHandler();
    }
}
else
{
    Log.Warning("Disable Auth middleware");
}

app.UseOverrideRequestHandler();
app.UseOverrideResponseHandler();

app.UseOpenApi(
    x =>
        x.PostProcess = (document, _) =>
        {
            document.Schemes = new[] { OpenApiSchema.Https, OpenApiSchema.Http };
        });

app.UseSwaggerUi(settings =>
{
    settings.Path = "/swagger";
    settings.EnableTryItOut = true;
});

app.UseExceptionHandler(options => { });

app.UseMvc();

app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });

Log.Information("Starting host");

app.Run();

void RegisteredServicesPage(IApplicationBuilder appBuilder, IServiceCollection services)
{
    appBuilder.Map(
        "/services",
        build =>
            build.Run(async context =>
            {
                var sb = new StringBuilder();
                sb.Append("<h1>Registered Services</h1>");
                sb.Append("<table><thead>");
                sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Instance</th></tr>");
                sb.Append("</thead><tbody>");

                foreach (var svc in services)
                {
                    sb.Append("<tr>");
                    sb.Append(CultureInfo.InvariantCulture, $"<td>{svc.ServiceType.FullName}</td>");
                    sb.Append(CultureInfo.InvariantCulture, $"<td>{svc.Lifetime}</td>");
                    sb.Append(
                        CultureInfo.InvariantCulture,
                        $"<td>{svc.ImplementationType?.FullName}</td>");
                    sb.Append("</tr>");
                }

                sb.Append("</tbody></table>");
                await context.Response.WriteAsync(sb.ToString()).ConfigureAwait(false);
            }));
}

namespace MSCoip.Api
{
    /// <summary>
    /// Program
    /// </summary>
    public partial class Program
    {
    }
}
