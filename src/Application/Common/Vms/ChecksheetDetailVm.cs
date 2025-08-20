// -----------------------------------------------------------------------------------
// ChecksheetDetailVm.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Linq;
using MSCoip.Application.Common.Dtos;
using MSCoip.Application.Common.Mappings;
using Newtonsoft.Json;

namespace MSCoip.Application.Common.Vms;

/// <summary>
/// ChecksheetDetailVm
/// </summary>
public class ChecksheetDetailVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets sector
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Sector { get; set; }

    /// <summary>
    /// Gets or sets unitApplication
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string UnitApplication { get; set; }

    /// <summary>
    /// Gets or sets parameter
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Parameter { get; set; }

    /// <summary>
    /// Gets or sets assessmentArea
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string AssessmentArea { get; set; }

    /// <summary>
    /// Gets or sets klausul
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Klausul { get; set; }

    /// <summary>
    /// Gets or sets description
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets guidance
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string[] Guidance { get; set; }

    /// <summary>
    /// Gets or sets scores
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public short[] Scores { get; set; }

    /// <summary>
    /// Gets or sets score
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public double Score { get; set; }

    /// <summary>
    /// Gets or sets weight
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public float Weight { get; set; }

    /// <summary>
    /// Gets or sets weight
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public float[] FinalScore { get; set; }

    /// <summary>
    /// Gets or sets comment
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Comment { get; set; }

    /// <summary>
    /// Gets or sets recommendation
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Recommendation { get; set; }

    /// <summary>
    /// Gets or sets image
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string[] Image { get; set; }

    /// <summary>
    /// Gets or sets linkVideo
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string LinkVideo { get; set; }

    /// <summary>
    /// Gets or sets sequence
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public int Sequence { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChecksheetValue, ChecksheetDetailVm>()
            .ForMember(vm => vm.Scores, conf => conf.MapFrom(x => x.Score))
            .ForMember(vm => vm.Image, conf => conf.MapFrom(x => ImageArrayHelper.GetImageArray(x.Image)))
            .ForMember(vm => vm.Score, conf => conf.MapFrom(x => Math.Floor(x.Score.Average(s => (int)s))))
            .ReverseMap();
    }
}

/// <summary>
/// ChecksheetMasterDetailVm
/// </summary>
public class ChecksheetMasterDetailVm : AuditTableDto, IMapFrom<ChecksheetMaster>
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
    /// Gets or sets Sequence
    /// </summary>
    /// <value></value>
    public int Sequence { get; set; }

    /// <summary>
    /// Gets or sets Measurement
    /// </summary>
    /// <value></value>
    public string Measurement { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChecksheetMaster, ChecksheetMasterDetailVm>();
    }
}

/// <summary>
/// CheckSheetValueDetailVm
/// </summary>
public class ChecksheetValueDetailVm : AuditTableDto, IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets JobId
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public Guid? JobId { get; set; }

    /// <summary>
    /// Gets or sets Sector
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Sector { get; set; }

    /// <summary>
    /// Gets or sets MaterialNumber
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string MaterialNumber { get; set; }

    /// <summary>
    /// Gets or sets Parameter
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Parameter { get; set; }

    /// <summary>
    /// Gets or sets AssessmentArea
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string AssessmentArea { get; set; }

    /// <summary>
    /// Gets or sets UnitApplication
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string UnitApplication { get; set; }

    /// <summary>
    /// Gets or sets Klausul
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Klausul { get; set; }

    /// <summary>
    /// Gets or sets Description
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets OperationStandard
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string[] OperationStandard { get; set; }

    /// <summary>
    /// Gets or sets Guidance
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string[] Guidance { get; set; }

    /// <summary>
    /// Gets or sets Score
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public short[] Score { get; set; }

    /// <summary>
    /// Gets or sets Weight
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public float Weight { get; set; }

    /// <summary>
    /// Gets or sets FinalScore
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public float[] FinalScore { get; set; }

    /// <summary>
    /// Gets or sets Comment
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Comment { get; set; }

    /// <summary>
    /// Gets or sets Recommendation
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Recommendation { get; set; }

    /// <summary>
    /// Gets or sets Image
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string[] Image { get; set; }

    /// <summary>
    /// Gets or sets LinkVideo
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string LinkVideo { get; set; }

    /// <summary>
    /// Gets or sets Sequence
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public int Sequence { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChecksheetValue, ChecksheetValueDetailVm>()
            .ForMember(vm => vm.Image, conf => conf.MapFrom(x => ImageArrayHelper.GetImageArray(x.Image)))
            .ReverseMap();
    }
}

/// <summary>
/// CheckSheetDetailReportCustomerVm
/// </summary>
public class ChecksheetDetailReportCustomerVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets Klausul
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Klausul { get; set; }

    /// <summary>
    /// Gets or sets Parameter
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Parameter { get; set; }

    /// <summary>
    /// Gets or sets Description
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets Comment
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Comment { get; set; }

    /// <summary>
    /// Gets or sets Recommendation
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Recommendation { get; set; }

    /// <summary>
    /// Gets or sets Image
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string[] Image { get; set; }

    /// <summary>
    /// Gets or sets Score
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public double Score { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChecksheetValue, ChecksheetDetailReportCustomerVm>()
            .ForMember(vm => vm.Image, conf => conf.MapFrom(x => Math.Floor(x.Score.Average(s => (int)s)) < 4 ? ImageArrayHelper.GetImageArray(x.Image) : null))
            .ForMember(vm => vm.Score, conf => conf.MapFrom(x => Math.Floor(x.Score.Average(s => (int)s))))
            .ReverseMap();
    }
}

/// <summary>
/// ImageArrayHelper
/// </summary>
public static class ImageArrayHelper
{
    /// <summary>
    /// GetImageArray
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    public static string[] GetImageArray(string image)
    {
        return image.StartsWith('[') ? JsonConvert.DeserializeObject<string[]>(image) : [image];
    }
}
