// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MSCoip.Domain.Common;

namespace MSCoip.Domain.Entities;

/// <summary>
/// MobileVersion
/// </summary>
public record MobileVersion : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets version
    /// </summary>
    /// <value></value>
    public string Version { get; set; }

    /// <summary>
    /// Gets or sets environment
    /// </summary>
    /// <value></value>
    public string Environment { get; set; }

    /// <summary>
    /// Gets or sets sequence
    /// </summary>
    /// <value></value>
    public int Sequence { get; set; }
}
