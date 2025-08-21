// -----------------------------------------------------------------------------------
// RequestBehavior.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MSCoip.Application.Common.Exceptions;

namespace MSCoip.Application.Common.Behaviors;

/// <summary>
/// RequestBehavior
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResponse"></typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="RequestBehavior{TCommand, TResponse}"/> class.
/// </remarks>
/// <param name="_logger"></param>
public class RequestBehavior<TCommand, TResponse>(
    ILogger<RequestBehavior<TCommand, TResponse>> _logger
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
        var requestType = typeof(TCommand).Name;

        var response = await next().ConfigureAwait(false);

        if (requestType.EndsWith("Command"))
        {
            _logger.LogDebug("Command Request: {request}", command);
        }
        else if (requestType.EndsWith("Query"))
        {
            _logger.LogDebug("Query Request: {request}", command);
            _logger.LogDebug("Query Response: {response}", response);
        }
        else
        {
            throw new ThrowException("The request is not the Command or Query type");
        }

        return response;
    }
}
