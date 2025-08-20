// -----------------------------------------------------------------------------------
// MSector.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Collections.Generic;
using MSCoip.Domain.Common;

namespace MSCoip.Domain.Entities;

/// <summary>
/// MSector
/// </summary>
public record MSector : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets name
    /// </summary>
    /// /// <value></value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets mUnitApplications
    /// </summary>
    /// <value></value>
    public ICollection<MUnitApplication> MUnitApplications { get; set; }
}
