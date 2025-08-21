// -----------------------------------------------------------------------------------
// BulkheadPolicyBehavior.cs 2023
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
using Polly.Bulkhead;

namespace MSCoip.Application.Common.Behaviors;

/// <summary>
/// Applies a fallback policy on the FastEndpoints request.
/// Apply this attribute to the FastEndpoints <see cref="ICommand"/> class (not on the handler).
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class BulkheadPolicyAttribute : Attribute
{
    private int _maxParallelization = 100;
    private int _maxQueuingActions = 20;

    /// <summary>
    /// Gets or sets a value indicating whether gets or sets to enabling/disabling policy.
    /// Defaults to true.
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// Gets or sets the max parallelization.
    /// Defaults to 100 parallel.
    /// </summary>
    public int MaxParallelization
    {
        get => _maxParallelization;
        set
        {
            if (value < 1)
            {
                throw new ArgumentException(
                    "Max parallelization count must be higher than 1.",
                    nameof(value));
            }

            _maxParallelization = value;
        }
    }

    /// <summary>
    /// Gets or sets the max queuing actions.
    /// Defaults to 20 queues.
    /// </summary>
    public int MaxQueuingActions
    {
        get => _maxQueuingActions;
        set
        {
            if (value < 1)
            {
                throw new ArgumentException(
                    "Max queuing actions count must be higher than 1.",
                    nameof(value));
            }

            _maxQueuingActions = value;
        }
    }
}

/// <summary>
/// Wraps request handler execution of requests decorated with the <see cref="BulkheadPolicyAttribute"/>
/// inside a policy to handle transient bulk head the execution.
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResponse"></typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="BulkheadPolicyBehavior{TCommand, TResponse}"/> class.
/// </remarks>
/// <param name="_logger"></param>
/// <param name="appSetting"></param>
/// <param name="_environment"></param>
public class BulkheadPolicyBehavior<TCommand, TResponse>(
    ILogger<BulkheadPolicyBehavior<TCommand, TResponse>> _logger,
    AppSetting appSetting,
    IWebHostEnvironment _environment
) : ICommandMiddleware<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    private readonly string _env = appSetting.Environment;
    private readonly Bulkhead _bulkHeadPolicy = appSetting.ResiliencyPolicy.Bulkhead;
    private readonly string _requestName = typeof(TCommand).Name;

    private AsyncBulkheadPolicy<TResponse> _bulkHead;

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
        if (
            _environment.EnvironmentName.Equals(EnvironmentConstants.NameTest)
            || !_env.Equals(EnvironmentConstants.IsProduction)
        )
        {
            return await next().ConfigureAwait(false);
        }

        var bulkHeadAttr = typeof(TCommand).GetCustomAttribute<BulkheadPolicyAttribute>();

        if (
            (bulkHeadAttr != null && !bulkHeadAttr.Enabled)
            || (bulkHeadAttr == null && !_bulkHeadPolicy.Enabled)
        )
        {
            return await next().ConfigureAwait(false);
        }

        _bulkHead ??= Polly
            .Policy
            .BulkheadAsync<TResponse>(
                bulkHeadAttr?.MaxParallelization ?? _bulkHeadPolicy.MaxParallelization,
                bulkHeadAttr?.MaxQueuingActions ?? _bulkHeadPolicy.MaxQueuingActions,
                (_) =>
                {
                    _logger.LogInformation(
                        "Bulkhead limit reached for request {name}",
                        _requestName);
                    return Task.CompletedTask;
                });

        return await _bulkHead.ExecuteAsync(() => next()).ConfigureAwait(false);
    }
}
