using MSCoip.Application.MessageLog.Create;
using MSCoip.Domain.Entities;
using static MSCoip.Application.IntegrationTests.Testing;

namespace MSCoip.Application.IntegrationTests.MessageLog.Commands;

/// <summary>
/// CreateReceivedMessageCommandTest
/// </summary>
public class CreateReceivedMessageCommandTest : BaseTestFixture
{
    /// <summary>
    /// ShouldCreateReceivedMessage
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    [Test]
    public async Task ShouldCreateReceivedMessage()
    {
        var id = Guid.NewGuid();

        var query = new CreateReceivedMessageCommand
        {
            Message = new ReceivedMessageBroker { Id = id }
        };

        await SendAsync(query).ConfigureAwait(false);

        var test = await Context.ReceivedMessageBroker
            .FirstOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);

        test.Should().NotBeNull();
    }
}
