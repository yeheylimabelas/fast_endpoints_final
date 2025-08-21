// -----------------------------------------------------------------------------------
// ValidationBehavior.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = MSCoip.Application.Common.Exceptions.ValidationException;

namespace MSCoip.Application.Common.Behaviors;

/// <summary>
/// ValidationBehavior
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResponse"></typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ValidationBehavior{TCommand, TResponse}"/> class.
/// </remarks>
/// <param name="_validators"></param>
public class ValidationBehavior<TCommand, TResponse>(IEnumerable<IValidator<TCommand>> _validators)
    : ICommandMiddleware<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    /// <summary>
    /// ExecuteAsync
    /// </summary>
    /// <param name="command"></param>
    /// <param name="next"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    /// <exception cref="ValidationException">Validation exception</exception>
    public async Task<TResponse> ExecuteAsync(
        TCommand command,
        CommandDelegate<TResponse> next,
        CancellationToken ct)
    {
        if (!_validators.Any())
        {
            return await next().ConfigureAwait(false);
        }

        var context = new FluentValidation.ValidationContext<TCommand>(command);

        var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, ct)))
            .ConfigureAwait(false);

        var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

        if (failures.Count != 0)
        {
            throw new ValidationException(failures);
        }

        return await next().ConfigureAwait(false);
    }
}
