// -----------------------------------------------------------------------------------
// ChecksheetReportVm.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MSCoip.Application.Common.Mappings;
using Newtonsoft.Json;

namespace MSCoip.Application.Common.Vms;

/// <summary>
/// ChecksheetReportVm
/// </summary>
public class ChecksheetReportVm : IMapFrom<ChecksheetValue>
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
    /// Gets or sets coipNumber
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string CoipNumber { get; set; }

    /// <summary>
    /// Gets or sets coipReports
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public CoipReportVm CoipReports { get; set; }

    /// <summary>
    /// Gets or sets parameters
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public List<ParameterSummaryVm> Parameters { get; set; }

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
        profile.CreateMap<ChecksheetValue, ChecksheetReportVm>()
            .ForMember(dto => dto.JobId, conf => conf.MapFrom(x => x.JobId))
            .ForMember(dto => dto.CoipNumber, conf => conf.MapFrom(x => x.Job.Number));
    }
}

/// <summary>
/// CoipReportVm
/// </summary>
public class CoipReportVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets unitApplication
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string UnitApplication { get; set; }

    /// <summary>
    /// Gets or sets customerLevel
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public double CustomerLevel { get; set; }

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
    /// Gets or sets dataChart
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public DataChartVm DataChart { get; set; }
}

/// <summary>
/// DataCustomerVm
/// </summary>
public class DataCustomerVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets customerName
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string CustomerName { get; set; }

    /// <summary>
    /// Gets or sets sector
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Sector { get; set; }

    /// <summary>
    /// Gets or sets location
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Location { get; set; }

    /// <summary>
    /// Gets or sets locationDetail
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string LocationDetail { get; set; }

    /// <summary>
    /// Gets or sets location
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public SpesificLocationVm SpesificLocation { get; set; }

    /// <summary>
    /// Gets or sets ApprovalName
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string ApprovalName { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChecksheetValue, DataCustomerVm>()
            .ForMember(dto => dto.CustomerName, conf => conf.MapFrom(src => src.Job.Customer.Name))
            .ForMember(dto => dto.Sector, conf => conf.MapFrom(x => x.Sector))
            .ForMember(dto => dto.Location, conf => conf.MapFrom(x => x.Job.PlantArea))
            .ForMember(dto => dto.LocationDetail, conf => conf.MapFrom(x => x.Job.LocationDetail))
            .ForMember(dto => dto.ApprovalName, conf => conf.MapFrom(src => src.Job.CreatedByName));
    }
}

/// <summary>
/// SpesificLocationVm
/// </summary>
public class SpesificLocationVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets Longitude
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Longitude { get; set; }

    /// <summary>
    /// Gets or sets Latitude
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Latitude { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChecksheetValue, SpesificLocationVm>()
            .ForMember(dto => dto.Longitude, conf => conf.MapFrom(src => src.Job.Longitude))
            .ForMember(dto => dto.Latitude, conf => conf.MapFrom(src => src.Job.Latitude));
    }
}

/// <summary>
/// DataJobObserverVm
/// </summary>
public class DataJobObserverVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets observerName
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string ObserverName { get; set; }

    /// <summary>
    /// Gets or sets approvalName
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string ApprovalName { get; set; }

    /// <summary>
    /// Gets or sets assignmentId
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string AssignmentId { get; set; }

    /// <summary>
    /// Gets or sets startDate
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public DateTimeOffset StartDate { get; set; }

    /// <summary>
    /// Gets or sets coipId
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string CoipId { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChecksheetValue, DataJobObserverVm>()
            .ForMember(dto => dto.ObserverName, conf => conf.MapFrom(src => src.Job.CreatedByName))
            .ForMember(dto => dto.ApprovalName, conf => conf.MapFrom(src => src.Job.CreatedByName))
            .ForMember(dto => dto.AssignmentId, conf => conf.MapFrom(x => x.JobId))
            .ForMember(dto => dto.StartDate, conf => conf.MapFrom(x => x.Job.DownTimeStartDate))
            .ForMember(dto => dto.CoipId, conf => conf.MapFrom(x => $"COIP{x.Job.Number}"));
    }
}

/// <summary>
/// DataChartVm
/// </summary>
public class DataChartVm
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
    /// Gets or sets TrendOperationLevels
    /// </summary>
    public List<TrendOperationLevel> TrendOperationLevels { get; set; } = new();
}

/// <summary>
/// AssessmentAreaVm
/// </summary>
public class AssessmentAreaVm
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets assessmentArea
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string AssessmentArea { get; set; }

    /// <summary>
    /// Gets or sets score
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public double Score { get; set; }

    /// <summary>
    /// Gets or sets Percentage
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public double Percentage { get; set; }
}

/// <summary>
/// TrendOperationLevel
/// </summary>
public class TrendOperationLevel
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets MonthCustomerLevel
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public DateTimeOffset? MonthCustomerLevel { get; set; }

    /// <summary>
    /// Gets or sets CustomerLevel
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public double CustomerLevel { get; set; }

    /// <summary>
    /// Gets or sets JobType
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string JobType { get; set; }
}
