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
/// DeleteSendMessageCommand
/// </summary>
public class DeleteSendMessageCommand : ICommand<bool>
{
}

/// <summary>
/// Handling DeleteSendMessageCommand
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="DeleteSendMessageCommandHandler"/> class.
/// </remarks>
/// <param name="_context">Set context to perform CRUD into Database</param>
/// <param name="_logger">Set logger to perform logging</param>
/// <param name="_appSetting">Set dateTime to get Application Setting</param>
public class DeleteSendMessageCommandHandler(
    IApplicationDbContext _context,
    ILogger<DeleteSendMessageCommandHandler> _logger,
    AppSetting _appSetting
) : ICommandHandler<DeleteSendMessageCommand, bool>
{
    /// <summary>
    /// ExecuteAsync Delete Send Message
    /// </summary>
    /// <param name="command">
    /// The encapsulated request body
    /// </param>
    /// <param name="ct">
    /// The cancellation token to perform cancel the operation
    /// </param>
    /// <returns></returns>
    public async Task<bool> ExecuteAsync(
        DeleteSendMessageCommand command,
        CancellationToken ct)
    {
        var status = false;

        try
        {
            _logger.LogDebug("Delete send message process");

            var lifeTime = _appSetting.DataLifetime.Changelog;

            var date = DateTime.Now.AddDays(-lifeTime);

            await _context
                .MessageBroker
                .Where(x => date > x.StoredDate)
                .DeleteAsync(ct)
                .ConfigureAwait(false);

            status = true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to delete received message: {Message}", e.Message);
        }

        _logger.LogDebug("Delete send message done");

        return status;
    }
}
