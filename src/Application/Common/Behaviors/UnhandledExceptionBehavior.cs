// -----------------------------------------------------------------------------------
// UnhandledExceptionBehavior.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MSCoip.Application.Common.Exceptions;
using MSCoip.Application.Common.Models;
using ValidationException = MSCoip.Application.Common.Exceptions.ValidationException;

namespace MSCoip.Application.Common.Behaviors;

/// <summary>
/// UnhandledExceptionBehavior
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResponse"></typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="UnhandledExceptionBehavior{TCommand, TResponse}"/> class.
/// </remarks>
/// <param name="logger"></param>
/// <param name="appSetting"></param>
public class UnhandledExceptionBehavior<TCommand, TResponse>(
    ILogger<TCommand> logger,
    AppSetting appSetting
) : ICommandMiddleware<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    private readonly ILogger<TCommand> _logger = logger;
    private readonly AppSetting _appSetting = appSetting;

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
        try
        {
            return await next().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            switch (ex)
            {
                case OperationCanceledException:
                    _logger.LogWarning("The request has been canceled");
                    break;
                case ValidationException:
                case BadRequestException:
                case NotFoundException:
                    break;
                default:
                    _logger.LogError(
                        ex,
                        "{namespace} Request: Unhandled Exception for Request {Name} {@Request}",
                        _appSetting.App.Namespace,
                        typeof(TCommand).Name,
                        command);
                    break;
            }

            throw;
        }
    }
}
