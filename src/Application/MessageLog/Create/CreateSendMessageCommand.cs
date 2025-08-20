using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MSCoip.Application.Common.Interfaces;

namespace MSCoip.Application.MessageLog.Create;

/// <summary>
/// CreateSendMessageCommand
/// </summary>
public class CreateSendMessageCommand : IRequest<Unit>
{
    /// <summary>
    /// Gets or sets MessageBroker
    /// </summary>
    public MessageBroker MessageBroker { get; set; }
}

/// <summary>
/// Handling CreateSendMessageCommand
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CreateSendMessageCommandHandler"/> class.
/// </remarks>
/// <param name="_context">Set context to perform CRUD into Database</param>
/// <param name="_logger">Set logger to perform logging</param>
public class CreateSendMessageCommandHandler(
    IApplicationDbContext _context,
    ILogger<CreateSendMessageCommandHandler> _logger
) : IRequestHandler<CreateSendMessageCommand, Unit>
{
    /// <summary>
    /// Handle Create Send Message Command
    /// </summary>
    /// <param name="request">
    /// The encapsulated request body
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token to perform cancel the operation
    /// </param>
    /// <returns></returns>
    public async Task<Unit> Handle(
        CreateSendMessageCommand request,
        CancellationToken cancellationToken)
    {
        _context.MessageBroker.Add(request.MessageBroker);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        _logger.LogDebug("Save send message success");

        return Unit.Value;
    }
}
