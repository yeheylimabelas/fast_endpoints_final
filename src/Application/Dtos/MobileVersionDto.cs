// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using MSCoip.Application.Common.Mappings;

namespace MSCoip.Application.Dtos;

/// <summary>
/// MobileVersionDto
/// </summary>
public class MobileVersionDto : IMapFrom<MobileVersion>
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
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<MobileVersionDto, MobileVersion>()
            .ForMember(entity => entity.Version, dto => dto.MapFrom(src => src.Version))
            .ForMember(entity => entity.Environment, dto => dto.MapFrom(src => src.Environment));
    }
}
