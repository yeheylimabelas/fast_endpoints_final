// -----------------------------------------------------------------------------------
// Plant.cs 2025
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using MSCoip.Domain.Common;

namespace MSCoip.Domain.Entities;

/// <summary>
/// Plant
/// </summary>
public record Plant : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets PlantName
    /// </summary>
    /// <value></value>
    public string PlantName { get; set; }

    /// <summary>
    /// Gets or sets PlantDescription
    /// </summary>
    public string PlantDescription { get; set; }
}
