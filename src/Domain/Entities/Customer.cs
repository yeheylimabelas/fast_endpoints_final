// -----------------------------------------------------------------------------------
// Customer.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;
using MSCoip.Domain.Common;

namespace MSCoip.Domain.Entities;

/// <summary>
/// Customer
/// </summary>
public record Customer : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets Code
    /// </summary>
    /// <value></value>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets Name
    /// </summary>
    /// <value></value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets Jobs
    /// </summary>
    public virtual ICollection<Job> Jobs { get; set; }

    /// <summary>
    /// Gets or sets UnitPopulations
    /// </summary>
    [IgnoreDataMember]
    public virtual List<Equipment> UnitPopulations { get; set; }
}
