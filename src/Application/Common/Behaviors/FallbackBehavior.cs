// -----------------------------------------------------------------------------------
// FallbackBehavior.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MSCoip.Application.Common.Interfaces;
using MSCoip.Domain.Constants;
using Polly;

namespace MSCoip.Application.Common.Behaviors;

/// <summary>
/// Wraps request handler execution of requests
/// inside a policy to handle transient fallback the execution.
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResponse"></typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="FallbackBehavior{TCommand, TResponse}"/> class.
/// </remarks>
/// <param name="_fallbackHandlers"></param>
/// <param name="_logger"></param>
/// <param name="_environment"></param>
public class FallbackBehavior<TCommand, TResponse>(
    IEnumerable<IFallbackHandler<TCommand, TResponse>> _fallbackHandlers,
    ILogger<FallbackBehavior<TCommand, TResponse>> _logger,
    IWebHostEnvironment _environment
) : ICommandMiddleware<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    /// <summary>
    /// ExecuteAsync
    /// </summary>
    /// <param name="command"></param>
    /// <param name="next"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task<TResponse> ExecuteAsync(
        TCommand command,
        CommandDelegate<TResponse> next,
        CancellationToken ct)
    {
        if (_environment.EnvironmentName.Equals(EnvironmentConstants.NameTest))
        {
            return await next().ConfigureAwait(false);
        }

        var fallbackHandler = _fallbackHandlers.FirstOrDefault();

        if (fallbackHandler == null)
        {
            return await next().ConfigureAwait(false);
        }

        var requestName = typeof(TCommand).Name;

        return await Policy<TResponse>
            .Handle<Exception>()
            .FallbackAsync(
                async (cancellationToken) =>
                {
                    _logger.LogInformation("Falling back response for request {name}", requestName);

                    return await fallbackHandler
                        .HandleFallback(command, cancellationToken)
                        .ConfigureAwait(false);
                })
            .ExecuteAsync(() => next())
            .ConfigureAwait(false);
    }
}
