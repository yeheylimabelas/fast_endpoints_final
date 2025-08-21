using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MSCoip.Application.Common.Interfaces;
using MSCoip.Application.Common.Models;
using Z.EntityFramework.Plus;

namespace MSCoip.Application.Changelogs.Commands.DeleteChangelog;

/// <summary>
/// DeleteChangelogCommand
/// </summary>
public class DeleteChangelogCommand : ICommand<bool>
{
    /// <summary>
    /// Handling DeleteChangelogCommand
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="DeleteChangelogCommandHandler"/> class.
    /// </remarks>
    /// <param name="_context">Set context to perform CRUD into Database</param>
    /// <param name="_logger">Set logger to perform logging</param>
    /// <param name="_appSetting">Set dateTime to get Application Setting</param>
    /// <returns></returns>
    public class DeleteChangelogCommandHandler(
        IApplicationDbContext _context,
        ILogger<DeleteChangelogCommandHandler> _logger,
        AppSetting _appSetting
    ) : ICommandHandler<DeleteChangelogCommand, bool>
    {
        /// <summary>
        /// ExecuteAsync
        /// </summary>
        /// <param name="command">
        /// The encapsulated request body
        /// </param>
        /// <param name="ct">
        /// The cancellation token to perform cancel the operation
        /// </param>
        /// <returns>A bool true or false</returns>
        public async Task<bool> ExecuteAsync(
            DeleteChangelogCommand command,
            CancellationToken ct)
        {
            var status = false;

            try
            {
                var lifeTime = _appSetting.DataLifetime.Changelog;

                var date = DateTime.Now.AddDays(-lifeTime);

                await _context
                    .Changelogs
                    .Where(x => date > x.ChangeDate)
                    .DeleteAsync(ct)
                    .ConfigureAwait(false);

                status = true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to delete changelog: {Message}", e.Message);
            }

            return status;
        }
    }
}
