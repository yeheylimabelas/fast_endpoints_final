// -----------------------------------------------------------------------------------
// ChecksheetValueVm.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MSCoip.Application.Common.Mappings;
using Newtonsoft.Json;

namespace MSCoip.Application.Common.Vms;

/// <summary>
/// DashboardVm
/// </summary>
public class DashboardSiteVm
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets parameter
    /// </summary>
    public string Parameter { get; set; }

    /// <summary>
    /// Gets or sets averageSpeed
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public double AverageSpeed { get; set; }

    /// <summary>
    /// Gets or sets customerLevel
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public double CustomerLevel { get; set; }

    /// <summary>
    /// Gets or sets SitePerformanceAchievementParameterIndex
    /// </summary>
    public SitePerformanceAchievementParameterIndexVm SitePerformanceAchievementParameterIndex { get; set; }

    /// <summary>
    /// Gets or sets TopFleetByUnitCode
    /// </summary>
    public List<TopFleetByUnitCodeVm> TopFleetByUnitCode { get; set; }

    /// <summary>
    /// Gets or sets ChecksheetValueParameters
    /// </summary>
    public ChecksheetValueParameterVm ChecksheetValueParameters { get; set; }
}

/// <summary>
/// SitePerformanceAchievementParameterIndexVm
/// </summary>
public class SitePerformanceAchievementParameterIndexVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets SiteAchievementParameterIndexVm
    /// </summary>
    public List<SiteAchievementParameterIndexVm> SiteAchievementParameterIndex { get; set; }

    /// <summary>
    /// Gets or sets averagePerDay
    /// </summary>
    public List<ChecksheetValueAveragePerDayVm> AveragePerDay { get; set; }
}

/// <summary>
/// SiteAchievementParameterIndexVm
/// </summary>
public class SiteAchievementParameterIndexVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets assessmentArea
    /// </summary>
    public string AssessmentArea { get; set; }

    /// <summary>
    /// Gets or sets AssessmentAreas
    /// </summary>
    public List<ChecksheetValueDateVm> Dates { get; set; }
}

/// <summary>
/// TopFleetByUnitCodeVm
/// </summary>
public class TopFleetByUnitCodeVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets Fleet
    /// </summary>
    public string Fleet { get; set; }

    /// <summary>
    /// Gets or sets AveragePerDay
    /// </summary>
    public List<ChecksheetValueAssessmentAreaPerDayVm> AverageAssessmentAreas { get; set; }

    /// <summary>
    /// Gets or sets AverageWci
    /// </summary>
    public double AverageWci { get; set; }
}

#region Coip Performance

/// <summary>
/// CoipPerformanceAchievementParameterIndexVm
/// </summary>
public class CoipPerformanceAchievementParameterIndexVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets CoipAchievementParameterIndexVm
    /// </summary>
    public List<CoipAchievementParameterIndexVm> CoipAchievementParameterIndex { get; set; }

    /// <summary>
    /// Gets or sets averagePerDay
    /// </summary>
    public List<ChecksheetValueAveragePerDayVm> AveragePerDay { get; set; }
}

/// <summary>
/// CoipAchievementParameterIndexVm
/// </summary>
public class CoipAchievementParameterIndexVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets assessmentArea
    /// </summary>
    public string AssessmentArea { get; set; }

    /// <summary>
    /// Gets or sets scoreByDates
    /// </summary>
    public List<ChecksheetValueDateVm> ScoreByDates { get; set; }
}

#endregion
