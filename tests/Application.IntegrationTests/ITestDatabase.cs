using System.Data.Common;

namespace MSCoip.Application.IntegrationTests;

/// <summary>
/// ITestDatabase
/// </summary>
public interface ITestDatabase
{
    /// <summary>
    /// InitializeAsync
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task InitializeAsync();

    /// <summary>
    /// GetConnection
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    DbConnection GetConnection();

    /// <summary>
    /// ResetAsync
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task ResetAsync();

    /// <summary>
    /// DisposeAsync
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task DisposeAsync();
}
