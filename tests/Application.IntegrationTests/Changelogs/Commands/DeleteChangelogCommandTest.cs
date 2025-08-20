using MSCoip.Application.Changelogs.Commands.DeleteChangelog;
using MSCoip.Domain.Entities;
using MSCoip.Infrastructure.Data;
using static MSCoip.Application.IntegrationTests.Testing;

namespace MSCoip.Application.IntegrationTests.Changelogs.Commands;

/// <summary>
/// DeleteChangelogCommandTest
/// </summary>
public class DeleteChangelogCommandTest : BaseTestFixture
{
    private readonly ApplicationDbContext _context = Context;

    /// <summary>
    /// ShouldDeleteChangelog
    /// </summary>
    /// <param name="changeDate"/>
    /// <param name="shouldDelete"/>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    [Test]
    [TestCase("2000-01-01", true)]
    [TestCase("2100-01-01", false)]
    public async Task ShouldDeleteChangelog(DateTime changeDate, bool shouldDelete)
    {
        var query = new DeleteChangelogCommand();

        var id = Guid.NewGuid();

        _context.Changelogs.Add(new Changelog { Id = id, ChangeDate = changeDate });

        await _context.SaveChangesAsync().ConfigureAwait(false);

        var test = await _context
            .Changelogs
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id))
            .ConfigureAwait(false);

        test.Should().NotBeNull();

        (await SendAsync(query).ConfigureAwait(false)).Should().BeTrue();

        test = await _context
            .Changelogs
            .FirstOrDefaultAsync(x => x.Id.Equals(id))
            .ConfigureAwait(false);

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
