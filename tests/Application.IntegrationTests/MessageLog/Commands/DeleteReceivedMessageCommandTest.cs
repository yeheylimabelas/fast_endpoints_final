using MSCoip.Application.MessageLog.Delete;
using MSCoip.Domain.Entities;
using MSCoip.Infrastructure.Data;
using static MSCoip.Application.IntegrationTests.Testing;

namespace MSCoip.Application.IntegrationTests.MessageLog.Commands;

/// <summary>
/// DeleteReceivedMessageCommandTest
/// </summary>
public class DeleteReceivedMessageCommandTest : BaseTestFixture
{
    private readonly ApplicationDbContext _context = Context;

    /// <summary>
    /// ShouldDeleteReceivedMessage
    /// </summary>
    /// <param name="changeDate"/>
    /// <param name="shouldDelete"/>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    [Test]
    [TestCase("2000-01-01", true)]
    [TestCase("2100-01-01", false)]
    public async Task ShouldDeleteReceivedMessage(DateTime changeDate, bool shouldDelete)
    {
        var query = new DeleteReceivedMessageCommand();

        var id = Guid.NewGuid();

        _context.ReceivedMessageBroker.Add(new ReceivedMessageBroker
        {
            Id = id,
            TimeIn = changeDate
        });

        await _context.SaveChangesAsync().ConfigureAwait(false);

        var test = await _context.ReceivedMessageBroker
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);

        test.Should().NotBeNull();

        (await SendAsync(query).ConfigureAwait(false)).Should().BeTrue();

        test = await _context.ReceivedMessageBroker
            .FirstOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);

        if (shouldDelete)
        {
            test.Should().BeNull();
        }
        else
        {
            test.Should().NotBeNull();
        }
    }
}
