using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MSCoip.Application.Common.Interfaces;

namespace MSCoip.Application.MessageLog.Create;

/// <summary>
/// CreateReceivedMessageCommand
/// </summary>
public class CreateReceivedMessageCommand : ICommand<EmptyResponse>
{
    /// <summary>
    /// Gets or sets Message
    /// </summary>
    public ReceivedMessageBroker Message { get; set; }
}

/// <summary>
/// Handling CreateReceivedMessageCommand
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CreateReceivedMessageCommandHandler"/> class.
/// </remarks>
/// <param name="_context">Set context to perform CRUD into Database</param>
/// <param name="_logger">Set logger to perform logging</param>
public class CreateReceivedMessageCommandHandler(
    IApplicationDbContext _context,
    ILogger<CreateReceivedMessageCommandHandler> _logger
) : ICommandHandler<CreateReceivedMessageCommand, EmptyResponse>
{
    /// <summary>
    /// ExecuteAsync Create Received Message Command
    /// </summary>
    /// <param name="command">
    /// The encapsulated request body
    /// </param>
    /// <param name="ct">
    /// The cancellation token to perform cancel the operation
    /// </param>
    /// <returns></returns>
    public async Task<EmptyResponse> ExecuteAsync(
        CreateReceivedMessageCommand command,
        CancellationToken ct)
    {
        _context.ReceivedMessageBroker.Add(command.Message);

        await _context.SaveChangesAsync(ct).ConfigureAwait(false);

        _logger.LogDebug("Save received message success");

        return new();
    }
}
