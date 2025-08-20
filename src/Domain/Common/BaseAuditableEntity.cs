// -----------------------------------------------------------------------------------
// BaseAuditableEntity.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;

namespace MSCoip.Domain.Common;

/// <summary>
/// BaseAuditableEntity
/// </summary>
public abstract record BaseAuditableEntity : BaseEntity
{
    /// <summary>
    /// Gets or sets createdBy
    /// </summary>
    /// <value></value>
    public string CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets createdDate
    /// </summary>
    /// <value></value>
    public DateTimeOffset? CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets updatedBy
    /// </summary>
    /// <value></value>
    public string UpdatedBy { get; set; }

    /// <summary>
    /// Gets or sets updatedDate
    /// </summary>
    /// <value></value>
    public DateTimeOffset? UpdatedDate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether isActive
    /// </summary>
    /// <value></value>
    public bool? IsActive { get; set; }
}
