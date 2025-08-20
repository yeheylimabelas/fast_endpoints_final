// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using MSCoip.Domain.Common;

namespace MSCoip.Domain.Entities;

/// <summary>
/// MUnitApplication
/// </summary>
public record MUnitApplication : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets sectorId
    /// </summary>
    /// <value></value>
    public Guid? SectorId { get; set; }

    /// <summary>
    /// Gets or sets name
    /// </summary>
    /// /// <value></value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets mSector
    /// </summary>
    /// <value></value>
    public MSector MSector { get; set; }

    /// <summary>
    /// Gets or sets masterChecksheetCustomers
    /// </summary>
    /// <value></value>
    public ICollection<MasterChecksheetCustomer> MasterChecksheetCustomers { get; set; }
}
