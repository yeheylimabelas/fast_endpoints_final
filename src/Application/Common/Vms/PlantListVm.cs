// -----------------------------------------------------------------------------------
// PlantListVm.cs 2025
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using MSCoip.Application.Common.Mappings;

namespace MSCoip.Application.Common.Vms;

/// <summary>
/// PlantListVm
/// </summary>
public class PlantListVm
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    /// <value></value>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets PlantName
    /// </summary>
    /// <value></value>
    public string PlantName { get; set; }

    /// <summary>
    /// Gets or sets PlantDescription
    /// </summary>
    /// <value></value>
    public string PlantDescription { get; set; }
}
