using MSCoip.Application.Common.Models;

namespace MSCoip.Application.IntegrationTests;

/// <summary>
/// TestDatabaseFactory
/// </summary>
public static class TestDatabaseFactory
{
    /// <summary>
    /// TestDatabaseFactory
    /// </summary>
    /// <param name="appSetting"/>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static async Task<ITestDatabase> CreateAsync(AppSetting appSetting)
    {
        var database = new PostgresTestDatabase();

        await database.InitializeAsync().ConfigureAwait(false);

        return database;
    }
}
