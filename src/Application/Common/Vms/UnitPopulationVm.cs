// -----------------------------------------------------------------------------------
// UnitPopulationVm.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using MSCoip.Application.Common.Mappings;

namespace MSCoip.Application.Common.Vms;

/// <summary>
/// UnitPopulationVm
/// </summary>
public class UnitPopulationVm : IMapFrom<Equipment>
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets UnitModel
    /// </summary>
    public string UnitModel { get; set; }

    /// <summary>
    /// Gets or sets UnitCode
    /// </summary>
    public string UnitCode { get; set; }

    /// <summary>
    /// Gets or sets SerialNumber
    /// </summary>
    public string SerialNumber { get; set; }

    /// <summary>
    /// Gets or sets Smr
    /// </summary>
    public float Smr { get; set; }

    /// <summary>
    /// Gets or sets BrandCode
    /// </summary>
    public string BrandCode { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the unit is a product unit
    /// </summary>
    public bool IsProductUT { get; set; }

    /// <summary>
    /// Gets or sets Plant
    /// </summary>
    public string Plant { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile">The AutoMapper profile to use for mapping.</param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Equipment, UnitPopulationVm>()
            .ForMember(dest => dest.Smr, opt => opt.MapFrom(src => src.SMRTotalInMinutes))
            .ForMember(dest => dest.Plant, opt => opt.MapFrom(src => src.PlantCode))
            .ReverseMap();
    }
}
