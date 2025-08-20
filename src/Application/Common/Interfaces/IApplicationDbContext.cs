// -----------------------------------------------------------------------------------
// IApplicationDbContext.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MSCoip.Application.Common.Interfaces;

/// <summary>
/// IApplicationDbContext
/// </summary>
public interface IApplicationDbContext
{
#pragma warning disable
    public DbSet<Changelog> Changelogs { get; set; }
    public DbSet<MessageBroker> MessageBroker { get; set; }
    public DbSet<ReceivedMessageBroker> ReceivedMessageBroker { get; set; }
    public DbSet<ChecksheetMaster> ChecksheetMaster { get; set; }
    public DbSet<ChecksheetValue> ChecksheetValue { get; set; }
    public DbSet<AdditionalJob> AdditionalJobs { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Domain.Entities.Job> Jobs { get; set; }
    public DbSet<UserLoginLog> UserLoginLogs { get; set; }
    public DbSet<MobileVersion> MobileVersion { get; set; }
    public DbSet<Plant> Plants { get; set; }
    public DbSet<Equipment> UnitPopulations { get; set; }
    public DbSet<EquipmentIdentity> EquipmentIdentities { get; set; }
    public DbSet<MSector> MSector { get; set; }
    public DbSet<MJob> MJobs { get; set; }
    public DbSet<MUnitApplication> MUnitApplication { get; set; }
    public DbSet<MasterChecksheetCustomer> MasterChecksheetCustomer { get; set; }
#pragma warning restore

    /// <summary>
    /// Gets database
    /// </summary>
    public DatabaseFacade Database { get; }

    /// <summary>
    /// AsNoTracking
    /// </summary>
    public void AsNoTracking();

    /// <summary>
    /// Clear
    /// </summary>
    public void Clear();

    /// <summary>
    /// Execute using EF Core resiliency strategy
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public Task ExecuteResiliencyAsync(Func<Task> action);

    /// <summary>
    /// SaveChangesAsync
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
