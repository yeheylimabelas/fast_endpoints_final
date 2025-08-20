// -----------------------------------------------------------------------------------
// ChecksheetReportCustomerVm.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using MSCoip.Application.Common.Mappings;
using Newtonsoft.Json;

namespace MSCoip.Application.Common.Vms;

/// <summary>
/// ChecksheetReportCustomerVm
/// </summary>
public class ChecksheetReportCustomerVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets jobId
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public Guid JobId { get; set; }

    /// <summary>
    /// Gets or sets jobNumber
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string JobNumber { get; set; }

    /// <summary>
    /// Gets or sets coipReports
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public CoipReportCustomerVm CoipReports { get; set; }

    /// <summary>
    /// Gets or sets dataUnitReport
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public DataUnitReportVm DataUnitReport { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChecksheetValue, ChecksheetReportCustomerVm>()
            .ForMember(dto => dto.JobId, conf => conf.MapFrom(x => x.JobId))
            .ForMember(dto => dto.JobNumber, conf => conf.MapFrom(x => x.Job.Number));
    }
}

/// <summary>
/// CoipReportCustomerVm
/// </summary>
public class CoipReportCustomerVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets coipNumber
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string CoipNumber { get; set; }

    /// <summary>
    /// Gets or sets unitApplication
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string UnitApplication { get; set; }

    /// <summary>
    /// Gets or sets dataCustomer
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public DataCustomerVm DataCustomer { get; set; }

    /// <summary>
    /// Gets or sets dataJobObserver
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public DataJobObserverVm DataJobObserver { get; set; }

    /// <summary>
    /// Gets or sets TableData
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public TableDataVm TableData { get; set; }

    /// <summary>
    /// Gets or sets DataChecksheetSummary
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public List<ParameterCustomerSummaryVm> DataChecksheetSummary { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChecksheetValue, CoipReportCustomerVm>()
            .ForMember(dto => dto.CoipNumber, conf => conf.MapFrom(x => $"COIP{x.Job.Number}"))
            .ForMember(dto => dto.UnitApplication, conf => conf.MapFrom(x => x.UnitApplication));
    }
}

/// <summary>
/// TableDataVm
/// </summary>
public class TableDataVm
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets assessmentAreas
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public List<AssessmentAreaVm> AssessmentAreas { get; set; }

    /// <summary>
    /// Gets or sets averageScore
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public int AverageScore { get; set; }

    /// <summary>
    /// Gets or sets CustomerLevel
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public double CustomerLevel { get; set; }
}

/// <summary>
/// DataUnitReportVm
/// </summary>
public class DataUnitReportVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    /// <value></value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets unitModel
    /// </summary>
    /// <value></value>
    public string UnitModel { get; set; }

    /// <summary>
    /// Gets or sets unitCode
    /// </summary>
    /// <value></value>
    public string UnitCode { get; set; }

    /// <summary>
    /// Gets or sets dataRelatedUnitReport
    /// </summary>
    /// <value></value>
    public List<DataRelatedUnitReportVm> DataRelatedUnitReport { get; set; }

    /// <summary>
    /// Maps the ChecksheetValue
    /// </summary>
    /// <param name="profile">The AutoMapper profile to use for mapping.</param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChecksheetValue, DataUnitReportVm>()
            .ForMember(dest => dest.UnitModel, conf => conf.MapFrom(src => src.Job.EquipmentIdentities
                .Where(e => e.IsExcavator)
                .Select(e => e.Equipment.UnitModel)
                .FirstOrDefault()))
            .ForMember(dest => dest.UnitCode, conf => conf.MapFrom(src => src.Job.EquipmentIdentities
                .Where(e => e.IsExcavator)
                .Select(e => e.Equipment.UnitCode)
                .FirstOrDefault()));
    }
}

/// <summary>
/// DataRelatedUnitReportVm
/// </summary>
public class DataRelatedUnitReportVm : IMapFrom<Equipment>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    /// <value></value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets unitModel
    /// </summary>
    /// <value></value>
    public string UnitModel { get; set; }

    /// <summary>
    /// Gets or sets unitCode
    /// </summary>
    /// <value></value>
    public string UnitCode { get; set; }
}