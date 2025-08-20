// -----------------------------------------------------------------------------------
// Copyright DAD RnD 2025. All rights reserved.
// United Tractors DAD Mobile Web Help Desk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MSCoip.Api.Infrastructures.Handlers;

/// <summary>
/// SwaggerHandler
/// </summary>
public static class SwaggerHandler
{
    /// <summary>
    /// ApplyCorsOrigin
    /// </summary>
    /// <param name="builder"></param>
    public static void Apply(IApplicationBuilder builder)
    {
        builder.Use(
            async (context, next) =>
            {
                var path = context.Request.Path.ToString();

                if (path.StartsWith("/swagger/") && path.Contains(".html"))
                {
                    var body = context.Response.Body;

                    using var updatedBody = new MemoryStream();
                    context.Response.Body = updatedBody;

                    await next(context).ConfigureAwait(false);

                    context.Response.Body = body;

                    updatedBody.Seek(0, SeekOrigin.Begin);
                    var newContent = await new StreamReader(updatedBody)
                        .ReadToEndAsync()
                        .ConfigureAwait(false);

                    var nonce = context.TraceIdentifier.Replace(":", "").ToLower();

                    newContent = newContent.Replace("<script", $"<script nonce=\"{nonce}\"");

                    await context.Response.WriteAsync(newContent).ConfigureAwait(false);
                }
                else
                {
                    await next(context).ConfigureAwait(false);
                }
            });
    }
}

/// <summary>
/// UseSwaggerHandlerExtension
/// </summary>
public static class UseSwaggerHandlerExtension
{
    /// <summary>
    /// UseSwaggerHandler
    /// </summary>
    /// <param name="builder"></param>
    public static void UseSwaggerHandler(this IApplicationBuilder builder)
    {
        SwaggerHandler.Apply(builder);
    }
}
