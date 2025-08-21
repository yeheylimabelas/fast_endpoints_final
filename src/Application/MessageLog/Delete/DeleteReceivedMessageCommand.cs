using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MSCoip.Application.Common.Interfaces;
using MSCoip.Application.Common.Models;
using Z.EntityFramework.Plus;

namespace MSCoip.Application.MessageLog.Delete;

/// <summary>
/// DeleteReceivedMessageCommand
/// </summary>
public class DeleteReceivedMessageCommand : ICommand<bool>
{
}

/// <summary>
/// Handling DeleteReceivedMessageCommand
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="DeleteReceivedMessageCommandHandler"/> class.
/// </remarks>
/// <param name="_context">Set context to perform CRUD into Database</param>
/// <param name="_logger">Set logger to perform logging</param>
/// <param name="_appSetting">Set dateTime to get Application Setting</param>
public class DeleteReceivedMessageCommandHandler(
    IApplicationDbContext _context,
    ILogger<DeleteReceivedMessageCommandHandler> _logger,
    AppSetting _appSetting
    )
        : ICommandHandler<DeleteReceivedMessageCommand, bool>
{
    /// <summary>
    /// ExecuteAsync Delete Received Message
    /// </summary>
    /// <param name="command">
    /// The encapsulated request body
    /// </param>
    /// <param name="ct">
    /// The cancellation token to perform cancel the operation
    /// </param>
    /// <returns></returns>
    public async Task<bool> ExecuteAsync(
        DeleteReceivedMessageCommand command,
        CancellationToken ct)
    {
        var status = false;

        try
        {
            _logger.LogDebug("Delete received message process");

            var lifeTime = _appSetting.DataLifetime.Changelog;

            var date = DateTime.Now.AddDays(-lifeTime);

            await _context
                .ReceivedMessageBroker
                .Where(x => date > x.TimeIn)
                .DeleteAsync(ct)
                .ConfigureAwait(false);

            status = true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to delete received message: {Message}", e.Message);
        }

        _logger.LogDebug("Delete received message done");

        return status;
    }
}
