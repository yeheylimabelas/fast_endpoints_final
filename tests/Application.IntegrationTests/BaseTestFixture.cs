// -----------------------------------------------------------------------------------
// BaseTestFixture.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using MSCoip.Application.Common.Models;
using MSCoip.Domain.Entities;

namespace MSCoip.Application.IntegrationTests;

using static Testing;

/// <summary>
/// BaseTestFixture
/// </summary>
[TestFixture]
public abstract class BaseTestFixture
{
    /// <summary>
    /// Gets JobId
    /// </summary>
    /// <value></value>
    protected Guid JobId { get; private set; }

    /// <summary>
    /// Gets CustomerId
    /// </summary>
    /// <value></value>
    protected Guid CustomerId { get; private set; }

    /// <summary>
    /// Gets or sets the checksheet masters
    /// </summary>
    /// <value>
    /// The checksheet masters
    /// </value>
    protected List<ChecksheetMaster> ChecksheetMasters { get; set; }

    /// <summary>
    /// Gets or sets the checksheet values
    /// </summary>
    /// <value>
    /// The checksheet values
    /// </value>
    protected List<ChecksheetValue> ChecksheetValues { get; set; }

    /// <summary>
    /// Gets or sets the customers
    /// </summary>
    /// <value>
    /// The customers
    /// </value>
    protected List<Customer> Customers { get; set; }

    /// <summary>
    /// Gets or sets the jobs
    /// </summary>
    /// <value>
    /// The jobs
    /// </value>
    protected List<Domain.Entities.Job> Jobs { get; set; }

    /// <summary>
    /// Gets or sets the additional jobs
    /// </summary>
    /// <value>
    /// The additional jobs
    /// </value>
    protected List<AdditionalJob> AdditionalJobs { get; set; }

    /// <summary>
    /// Gets or sets the unit populations
    /// </summary>
    /// <value>
    /// The unit populations
    /// </value>
    protected List<Equipment> UnitPopulations { get; set; }

    /// <summary>
    /// TestSetUp
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task TestSetUp()
    {
        ChecksheetMasters = MockData.CreateChecksheetMasters();
        Customers = MockData.CreateCustomers();
        Jobs = MockData.CreateJobs(Customers[0].Id);

        Context.ChecksheetMaster.AddRange(ChecksheetMasters);
        Context.Customers.AddRange(Customers);
        Context.Jobs.AddRange(Jobs);

        await Context.SaveChangesAsync().ConfigureAwait(false);

        CustomerId = Customers.FirstOrDefault()?.Id ?? Guid.NewGuid();
        JobId = Jobs.FirstOrDefault()?.Id ?? Guid.NewGuid();

        ChecksheetValues = MockData.CreateChecksheetValues(JobId);
        AdditionalJobs = MockData.CreateAdditionalJobs(JobId);
        UnitPopulations = MockData.CreateUnitPopulations(Customers[0].Id, Customers[0].Code);

        Context.ChecksheetValue.AddRange(ChecksheetValues);
        Context.AdditionalJobs.AddRange(AdditionalJobs);
        Context.UnitPopulations.AddRange(UnitPopulations);
        await Context.SaveChangesAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Setup method that is run once before any tests in the test fixture.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        await ResetData().ConfigureAwait(false);
        await TestSetUp().ConfigureAwait(false);
    }
}
