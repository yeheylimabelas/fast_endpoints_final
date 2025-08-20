// -----------------------------------------------------------------------------------
// Copyright DAD RnD 2025. All rights reserved.
// United Tractors DAD Mobile Web Help Desk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using MSCoip.Application.Common.Models;

namespace MSCoip.Api.Infrastructures.Handlers;

/// <summary>
/// CspHandler
/// </summary>
public static class CspHandler
{
    /// <summary>
    /// ApplyCorsOrigin
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="appSetting"></param>
    public static void Apply(IApplicationBuilder builder, AppSetting appSetting)
    {
        builder.Use(
            async (context, next) =>
            {
                var nonce = context.TraceIdentifier.Replace(":", "").ToLower();
                var cspHeader = appSetting.CspHeader.Replace("{nonce}", nonce);
                context.Response.Headers.ContentSecurityPolicy = cspHeader;
                await next().ConfigureAwait(false);
            });
    }
}

/// <summary>
/// UseCspHandlerExtension
/// </summary>
public static class UseCspHandlerExtension
{
    /// <summary>
    /// UseCspHandler
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="appSetting"></param>
    public static void UseCspHandler(this IApplicationBuilder builder, AppSetting appSetting)
    {
        CspHandler.Apply(builder, appSetting);
    }
}
