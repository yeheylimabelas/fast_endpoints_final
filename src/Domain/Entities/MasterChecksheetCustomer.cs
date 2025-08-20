// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using MSCoip.Domain.Common;

namespace MSCoip.Domain.Entities;

/// <summary>
/// MasterChecksheetCustomer
/// </summary>
public record MasterChecksheetCustomer : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets unitApplicationId
    /// </summary>
    public Guid? UnitApplicationId { get; set; }

    /// <summary>
    /// Gets or sets customerId
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Gets or sets customerCode
    /// </summary>
    public string CustomerCode { get; set; }

    /// <summary>
    /// Gets or sets mUnitApplication
    /// </summary>
    /// <value></value>
    public MUnitApplication MUnitApplication { get; set; }

    /// <summary>
    /// Gets or sets customer
    /// </summary>
    /// <value></value>
    public Customer Customer { get; set; }
}
