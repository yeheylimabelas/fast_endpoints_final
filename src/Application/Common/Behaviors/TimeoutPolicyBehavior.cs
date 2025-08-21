// -----------------------------------------------------------------------------------
// TimeoutPolicyBehavior.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MSCoip.Application.Common.Models;
using MSCoip.Domain.Constants;
using Polly.Timeout;
using Timeout = MSCoip.Application.Common.Models.Timeout;

namespace MSCoip.Application.Common.Behaviors;

/// <summary>
/// Applies a timeout policy on the FastEndpoints request.
/// Apply this attribute to the FastEndpoints <see cref="ICommand"/> class (not on the handler).
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class TimeoutPolicyAttribute : Attribute
{
    private int _duration = 180;

    /// <summary>
    /// Gets or sets a value indicating whether gets or sets to enabling/disabling policy.
    /// Defaults to true.
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// Gets or sets the timeout duration of the execution.
    /// Defaults to 180 seconds.
    /// </summary>
    public int Duration
    {
        get => _duration;
        set
        {
            if (value < 1)
            {
                throw new ArgumentException(
                    "Duration must be higher than 1 seconds.",
                    nameof(value));
            }

            _duration = value;
        }
    }
}

/// <summary>
/// Wraps request handler execution of requests decorated with the <see cref="TimeoutPolicyAttribute"/>
/// inside a policy to handle transient timeout policy of the execution.
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResponse"></typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="TimeoutPolicyBehavior{TCommand, TResponse}"/> class.
/// </remarks>
/// <param name="_logger"></param>
/// <param name="appSetting"></param>
/// <param name="_environment"></param>
public class TimeoutPolicyBehavior<TCommand, TResponse>(
    ILogger<TimeoutPolicyBehavior<TCommand, TResponse>> _logger,
    AppSetting appSetting,
    IWebHostEnvironment _environment
) : ICommandMiddleware<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    private readonly Timeout _timeoutPolicy = appSetting.ResiliencyPolicy.Timeout;
    private readonly string _requestName = typeof(TCommand).Name;

    private AsyncTimeoutPolicy<TResponse> _timeout;

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

        var timeoutAttr = typeof(TCommand).GetCustomAttribute<TimeoutPolicyAttribute>();

        if (
            (timeoutAttr != null && !timeoutAttr.Enabled)
            || (timeoutAttr == null && !_timeoutPolicy.Enabled)
        )
        {
            return await next().ConfigureAwait(false);
        }

        _timeout ??= Polly
            .Policy
            .TimeoutAsync<TResponse>(
                timeoutAttr?.Duration ?? _timeoutPolicy.Duration,
                TimeoutStrategy.Pessimistic,
                (_, _, _, _) =>
                {
                    _logger.LogInformation("Timeout reached for request {name}", _requestName);
                    return Task.CompletedTask;
                });

        return await _timeout.ExecuteAsync(() => next()).ConfigureAwait(false);
    }
}
