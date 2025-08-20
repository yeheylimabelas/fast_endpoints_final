using MSCoip.Application.MessageLog.Create;
using MSCoip.Domain.Entities;
using MSCoip.Infrastructure.Data;
using static MSCoip.Application.IntegrationTests.Testing;

namespace MSCoip.Application.IntegrationTests.MessageLog.Commands;

/// <summary>
/// CreateSendMessageCommandTest
/// </summary>
public class CreateSendMessageCommandTest : BaseTestFixture
{
    private readonly ApplicationDbContext _context = Context;

    /// <summary>
    /// ShouldCreateSendMessage
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    [Test]
    public async Task ShouldCreateSendMessage()
    {
        var id = Guid.NewGuid();

        var query = new CreateSendMessageCommand { MessageBroker = new MessageBroker { Id = id } };

        await SendAsync(query).ConfigureAwait(false);

        var test = await _context.MessageBroker
            .FirstOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);

        test.Should().NotBeNull();
    }
}
