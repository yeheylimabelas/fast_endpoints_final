// -----------------------------------------------------------------------------------
// Job.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MSCoip.Domain.Common;

namespace MSCoip.Domain.Entities;

/// <summary>
/// Job
/// </summary>
public record Job : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets CustomerId
    /// </summary>
    /// <value></value>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Gets or sets Number
    /// </summary>
    /// <value></value>
    public string Number { get; set; }

    /// <summary>
    /// Gets or sets Status
    /// </summary>
    /// <value></value>
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets PlantArea
    /// </summary>
    /// <value></value>
    public string PlantArea { get; set; }

    /// <summary>
    /// Gets or sets Latitude
    /// </summary>
    public string Latitude { get; set; }

    /// <summary>
    /// Gets or sets Longitude
    /// </summary>
    public string Longitude { get; set; }

    /// <summary>
    /// Gets or sets PlanExecutionDate
    /// </summary>
    /// <value></value>
    public DateTimeOffset? PlanExecutionDate { get; set; }

    /// <summary>
    /// Gets or sets DownTimeStartDate
    /// </summary>
    /// <value></value>
    public DateTimeOffset? DownTimeStartDate { get; set; }

    /// <summary>
    /// Gets or sets DownTimeEndDate
    /// </summary>
    /// <value></value>
    public DateTimeOffset? DownTimeEndDate { get; set; }

    /// <summary>
    /// Gets or sets MainJob
    /// </summary>
    /// <value></value>
    public string MainJob { get; set; }

    /// <summary>
    /// Gets or sets CreatedByName
    /// </summary>
    /// <value></value>
    public string CreatedByName { get; set; }

    /// <summary>
    /// Gets or sets AverageSpeed
    /// </summary>
    /// <value></value>
    public float AverageSpeed { get; set; }

    /// <summary>
    /// Gets or sets LocationDetail
    /// </summary>
    /// <value></value>
    public string LocationDetail { get; set; }

    /// <summary>
    /// Gets or sets JobType
    /// </summary>
    /// <value></value>
    public string JobType { get; set; }

    /// <summary>
    /// Gets or sets Customer
    /// </summary>
    public Customer Customer { get; set; }

    /// <summary>
    /// Gets or sets EquipmentIdentities
    /// </summary>
    /// <value></value>
    public ICollection<EquipmentIdentity> EquipmentIdentities { get; set; }

    /// <summary>
    /// Gets or sets ChecksheetValues
    /// </summary>
    /// <value></value>
    public ICollection<ChecksheetValue> ChecksheetValues { get; set; }

    /// <summary>
    /// Gets or sets additionalJobs
    /// </summary>
    /// <value></value>
    public ICollection<AdditionalJob> AdditionalJobs { get; set; }
}
