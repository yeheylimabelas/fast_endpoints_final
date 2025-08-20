// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Data.Common;
using MSCoip.Infrastructure.Data;
using Npgsql;
using Respawn;

namespace MSCoip.Application.IntegrationTests;

using static Testing;

/// <summary>
/// PostgresTestDatabase
/// </summary>
public class PostgresTestDatabase : ITestDatabase
{
    private readonly ApplicationDbContext _context = Context;
    private DbConnection _connection = null!;
    private Respawner _respawner = null!;

    /// <summary>
    /// InitializeAsync
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task InitializeAsync()
    {
        try
        {
            _connection = new NpgsqlConnection(AppSetting.ConnectionStrings.DefaultConnection);

            await _context.Database.MigrateAsync().ConfigureAwait(false);

            await _connection.OpenAsync().ConfigureAwait(false);

            _respawner = await Respawner
                .CreateAsync(
                    _connection,
                    new RespawnerOptions
                    {
                        TablesToIgnore = new Respawn.Graph.Table[] { "__EFMigrationsHistory" },
                        DbAdapter = DbAdapter.Postgres
                    })
                .ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// GetConnection
    /// </summary>
    /// <returns></returns>
    public DbConnection GetConnection()
    {
        return _connection;
    }

    /// <summary>
    /// ResetAsync
    /// </summary>
    /// <returns></returns>
    public async Task ResetAsync()
    {
        await _respawner.ResetAsync(_connection).ConfigureAwait(false);
    }

    /// <summary>
    /// DisposeAsync
    /// </summary>
    /// <returns></returns>
    public async Task DisposeAsync()
    {
        await _connection.DisposeAsync().ConfigureAwait(false);
    }
}
