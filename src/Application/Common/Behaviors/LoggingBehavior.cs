// -----------------------------------------------------------------------------------
// LoggingBehavior.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using MSCoip.Application.Common.Interfaces;
using MSCoip.Application.Common.Models;

namespace MSCoip.Application.Common.Behaviors;

/// <summary>
/// LoggingBehavior
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="LoggingBehavior{TRequest}"/> class.
/// </remarks>
/// <param name="_logger"></param>
/// <param name="_userAuthorizationService"></param>
/// <param name="_appSetting"></param>
public class LoggingBehavior<TRequest>(
    ILogger<TRequest> _logger,
    IUserAuthorizationService _userAuthorizationService,
    AppSetting _appSetting
) : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    /// <summary>
    /// Process
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var user = _userAuthorizationService.GetAuthorizedUser();
        await Task.Delay(0, cancellationToken).ConfigureAwait(false);
        _logger.LogDebug(
            "{Namespace} Request: {Name} {@UserId} {@UserName} {@Request}",
            _appSetting.App.Namespace,
            requestName,
            user.UserId,
            user.UserName,
            request);
    }
}
