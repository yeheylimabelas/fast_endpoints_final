// -----------------------------------------------------------------------------------
// Copyright DAD RnD 2025. All rights reserved.
// United Tractors DAD Mobile Web Help Desk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using MSCoip.Application.Common.Models;

namespace MSCoip.Api.Infrastructures.Handlers;

/// <summary>
/// HstsHandler
/// </summary>
public static class HstsHandler
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
                context.Response.Headers.StrictTransportSecurity = appSetting.HstsHeader;

                await next().ConfigureAwait(false);
            });
    }
}

/// <summary>
/// UseHstsHandlerExtension
/// </summary>
public static class UseHstsHandlerExtension
{
    /// <summary>
    /// UseHstsHandler
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="appSetting"></param>
    public static void UseHstsHandler(this IApplicationBuilder builder, AppSetting appSetting)
    {
        HstsHandler.Apply(builder, appSetting);
    }
}
