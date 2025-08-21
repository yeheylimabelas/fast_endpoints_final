// -----------------------------------------------------------------------------------
// PerformanceBehavior.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MSCoip.Application.Common.Interfaces;
using MSCoip.Application.Common.Models;
using MSCoip.Domain.Constants;

namespace MSCoip.Application.Common.Behaviors;

/// <summary>
/// PerformanceBehavior
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResponse"></typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="PerformanceBehavior{TCommand, TResponse}"/> class.
/// </remarks>
/// <param name="_logger"></param>
/// <param name="_userAuthorizationService"></param>
/// <param name="_appSetting"></param>
public class PerformanceBehavior<TCommand, TResponse>(
    ILogger<TCommand> _logger,
    IUserAuthorizationService _userAuthorizationService,
    AppSetting _appSetting) : ICommandMiddleware<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    private readonly Stopwatch _timer = new Stopwatch();

    /// <summary>
    /// ExecuteAsync
    /// </summary>
    /// <param name="command"></param>
    /// <param name="next"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task<TResponse> ExecuteAsync(
        TCommand command, CommandDelegate<TResponse> next, CancellationToken ct)
    {
        _timer.Start();

        var response = await next().ConfigureAwait(false);

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds <= _appSetting.RequestPerformanceInMs)
        {
            return response;
        }

        var requestName = typeof(TCommand).Name;
        var user = _userAuthorizationService.GetAuthorizedUser();
        var userName = user.UserName ?? SystemConstants.Name;

        _logger.LogWarning(
            "{Namespace} Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserName} {@Request}",
            _appSetting.App.Namespace,
            requestName,
            elapsedMilliseconds,
            userName,
            command);

        return response;
    }
}
