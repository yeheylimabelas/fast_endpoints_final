// -----------------------------------------------------------------------------------
// EquipmentIdentity.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using MSCoip.Domain.Common;

namespace MSCoip.Domain.Entities;

/// <summary>
/// EquipmentIdentity
/// </summary>
public record EquipmentIdentity : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets jobId
    /// </summary>
    /// <value></value>
    public Guid? JobId { get; set; }

    /// <summary>
    /// Gets or sets equipmentId
    /// </summary>
    /// <value></value>
    public Guid? EquipmentId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether IsProductUT
    /// </summary>
    /// <value></value>
    public bool IsProductUT { get; set; }

    /// <summary>
    /// Gets or sets customerOperator
    /// </summary>
    /// <value></value>
    public string CustomerOperator { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether IsExcavator
    /// </summary>
    /// <value></value>
    public bool IsExcavator { get; set; }

    /// <summary>
    /// Gets or sets job
    /// </summary>
    /// <value></value>
    public Job Job { get; set; }

    /// <summary>
    /// Gets or sets equipment
    /// </summary>
    /// <value></value>
    public Equipment Equipment { get; set; }
}
