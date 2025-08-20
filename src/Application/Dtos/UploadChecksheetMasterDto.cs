// -----------------------------------------------------------------------------------
// UploadChecksheetMasterDto.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System.Linq;
using MSCoip.Application.Common.Mappings;

namespace MSCoip.Application.Common.Dtos;

/// <summary>
/// UploadChecksheetMasterDto
/// </summary>
public class UploadChecksheetMasterDto : IMapFrom<ChecksheetMaster>
{
    /// <summary>
    /// Gets or sets Sector
    /// </summary>
    /// <value></value>
    public string Sector { get; set; }

    /// <summary>
    /// Gets or sets Parameter
    /// </summary>
    /// <value></value>
    public string Parameter { get; set; }

    /// <summary>
    /// Gets or sets AssessmentArea
    /// </summary>
    /// <value></value>
    public string AssessmentArea { get; set; }

    /// <summary>
    /// Gets or sets UnitApplication
    /// </summary>
    /// <value></value>
    public string UnitApplication { get; set; }

    /// <summary>
    /// Gets or sets Klausul
    /// </summary>
    /// <value></value>
    public string Klausul { get; set; }

    /// <summary>
    /// Gets or sets Description
    /// </summary>
    /// <value></value>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets OperationStandard
    /// </summary>
    /// <value></value>
    public string[] OperationStandard { get; set; }

    /// <summary>
    /// Gets or sets Guidance
    /// </summary>
    /// <value></value>
    public string[] Guidance { get; set; }

    /// <summary>
    /// Gets or sets Score
    /// </summary>
    /// <value></value>
    public short[] Score { get; set; }

    /// <summary>
    /// Gets or sets Weight
    /// </summary>
    /// <value></value>
    public float Weight { get; set; }

    /// <summary>
    /// Gets or sets Measurement
    /// </summary>
    /// <value></value>
    public string Measurement { get; set; }
}

/// <summary>
/// Provides a mapping profile for UploadChecksheetMasterDto to ChecksheetMaster.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfile"/> class.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<UploadChecksheetMasterDto, ChecksheetMaster>()
            .ForMember(dest => dest.OperationStandard, opt => opt.MapFrom(src => src.OperationStandard))
            .ForMember(dest => dest.Guidance, opt => opt.MapFrom(src => src.Guidance))
            .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score))
            .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
            .ForMember(dest => dest.Measurement, opt => opt.MapFrom(src => src.Measurement))
            .ForMember(dest => dest.Sector, opt => opt.MapFrom(src => src.Sector))
            .ForMember(dest => dest.Parameter, opt => opt.MapFrom(src => src.Parameter))
            .ForMember(dest => dest.AssessmentArea, opt => opt.MapFrom(src => src.AssessmentArea))
            .ForMember(dest => dest.UnitApplication, opt => opt.MapFrom(src => src.UnitApplication))
            .ForMember(dest => dest.Klausul, opt => opt.MapFrom(src => TransformKlausul(src.Klausul)))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
    }

    private static string TransformKlausul(string klausul)
    {
        if (string.IsNullOrWhiteSpace(klausul))
        {
            return klausul;
        }

        return klausul.Replace(',', '.');
    }
}