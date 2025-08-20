// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using MSCoip.Application.Common.Mappings;

namespace MSCoip.Application.Common.Vms;

/// <summary>
/// MobileVersionVm
/// </summary>
public class MobileVersionVm : IMapFrom<MobileVersion>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets version
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    /// Gets or sets environment
    /// </summary>
    public string Environment { get; set; }

    /// <summary>
    /// Gets or sets sequence
    /// </summary>
    public string Sequence { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<MobileVersion, MobileVersionVm>();
    }
}
