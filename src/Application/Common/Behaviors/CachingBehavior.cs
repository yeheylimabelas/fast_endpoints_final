// -----------------------------------------------------------------------------------
// CachingBehavior.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MSCoip.Application.Common.Interfaces;
using MSCoip.Domain.Constants;

namespace MSCoip.Application.Common.Behaviors;

/// <summary>
/// FastEndpoints Caching Pipeline Behavior
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResponse"></typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="CachingBehavior{TCommand, TResponse}"/> class.
/// </remarks>
/// <param name="_cache"></param>
/// <param name="_userAuthorizationService"></param>
/// <param name="_logger"></param>
/// <param name="_cachePolicies"></param>
/// <param name="_environment"></param>
public class CachingBehavior<TCommand, TResponse>(
    ICache _cache,
    IUserAuthorizationService _userAuthorizationService,
    ILogger<CachingBehavior<TCommand, TResponse>> _logger,
    IEnumerable<ICachePolicy<TCommand, TResponse>> _cachePolicies,
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

        var cachePolicy = _cachePolicies.FirstOrDefault();

        if (cachePolicy == null)
        {
            return await next().ConfigureAwait(false);
        }

        var customerCode = _userAuthorizationService.GetCustomerCode();
        var attributes = await _userAuthorizationService
            .GetUserAttributesAsync(ct)
            .ConfigureAwait(false);

        var cacheKey = cachePolicy.GetCacheKey(command, customerCode, attributes);
        var cachedResponse = await _cache
            .GetAsync<TResponse>(cacheKey, ct)
            .ConfigureAwait(false);

        var requestName = typeof(TCommand).Name;

        if (cachedResponse != null)
        {
            _logger.LogDebug(
                "Response retrieved {requestName} from cache. CacheKey: {cacheKey}",
                requestName,
                cacheKey);

            return cachedResponse;
        }

        var response = await next().ConfigureAwait(false);

        _logger.LogDebug(
            "Caching response for {requestName} with cache key: {cacheKey}",
            requestName,
            cacheKey);

        await _cache
            .SetAsync(
                cacheKey,
                response,
                cachePolicy.SlidingExpiration,
                cachePolicy.AbsoluteExpiration,
                cachePolicy.AbsoluteExpirationRelativeToNow,
                ct)
            .ConfigureAwait(false);

        return response;
    }
}
