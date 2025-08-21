// -----------------------------------------------------------------------------------
// LoggingBehavior.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MSCoip.Application.Common.Interfaces;
using MSCoip.Application.Common.Models;

namespace MSCoip.Application.Common.Behaviors;

/// <summary>
/// LoggingBehavior
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="LoggingBehavior{TCommand}"/> class.
/// </remarks>
/// <param name="_logger"></param>
/// <param name="_userAuthorizationService"></param>
/// <param name="_appSetting"></param>
public class LoggingBehavior<TCommand>(
    ILogger<TCommand> _logger,
    IUserAuthorizationService _userAuthorizationService,
    AppSetting _appSetting
) : IPreProcessor<TCommand>
    where TCommand : notnull
{
    /// <summary>
    /// PreProcessAsync
    /// </summary>
    /// <param name="context"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task PreProcessAsync(IPreProcessorContext<TCommand> context, CancellationToken ct)
    {
        var requestName = typeof(TCommand).Name;
        var user = _userAuthorizationService.GetAuthorizedUser();
        await Task.Delay(0, ct).ConfigureAwait(false);
        _logger.LogDebug(
            "{Namespace} Request: {Name} {@UserId} {@UserName} {@Request}",
            _appSetting.App.Namespace,
            requestName,
            user.UserId,
            user.UserName,
            context);
    }
}
