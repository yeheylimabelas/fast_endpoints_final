// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MSCoip.Domain.Common;

namespace MSCoip.Domain.Entities;

/// <summary>
/// UserLoginLog
/// </summary>
public record UserLoginLog : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets userName
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether isMobileDevice
    /// </summary>
    public bool IsMobileDevice { get; set; }
}
