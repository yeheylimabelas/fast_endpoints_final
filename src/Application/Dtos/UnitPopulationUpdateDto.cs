// -----------------------------------------------------------------------------------
// UnitPopulationUpdateDto.cs 2025
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using MSCoip.Application.Common.Mappings;

namespace MSCoip.Application.Dtos;

/// <summary>
/// UnitPopulationUpdateDto
/// </summary>
public class UnitPopulationUpdateDto : IMapFrom<Equipment>
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets UnitCode
    /// </summary>
    public string UnitCode { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Equipment, UnitPopulationUpdateDto>()
            .ReverseMap();
    }
}
