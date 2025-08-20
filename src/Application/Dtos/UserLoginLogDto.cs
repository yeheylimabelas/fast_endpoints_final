// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using MSCoip.Application.Common.Mappings;

namespace MSCoip.Application.Dtos;

/// <summary>
/// UserLoginLogDto
/// </summary>
public class UserLoginLogDto : IMapFrom<UserLoginLog>
{
    /// <summary>
    /// Gets or sets UserName
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Gets or sets userFullName
    /// </summary>
    public string UserFullName { get; set; }

    /// <summary>
    /// Gets or sets lastLoginMobile
    /// </summary>
    public DateTimeOffset? LastLoginMobile { get; set; }

    /// <summary>
    /// Gets or sets lastLoginWeb
    /// </summary>
    public DateTimeOffset? LastLoginWeb { get; set; }

    /// <summary>
    /// Gets or sets countTotalMobile
    /// </summary>
    public int CountTotalMobile { get; set; }

    /// <summary>
    /// Gets or sets countTotalWeb
    /// </summary>
    public int CountTotalWeb { get; set; }
}
