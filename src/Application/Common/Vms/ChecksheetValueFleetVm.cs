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
public class DashboardFleetVm
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
    /// Gets or sets TopFleetByStartDate
    /// </summary>
    public List<TopFleetByStartDateVm> TopFleetByStartDate { get; set; }

    /// <summary>
    /// Gets or sets FleetAchievementConfigVm
    /// </summary>
    public List<FleetAchievementConfigVm> FleetAchievementConfig { get; set; }

    /// <summary>
    /// Gets or sets ChecksheetValueParameters
    /// </summary>
    public ChecksheetValueParameterVm ChecksheetValueParameters { get; set; }
}

/// <summary>
/// FleetAchievementConfigVm
/// </summary>
public class FleetAchievementConfigVm
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets startDate
    /// </summary>
    public string StartDate { get; set; }

    /// <summary>
    /// Gets or sets averageScoreAssessment
    /// </summary>
    public double AverageScoreAssessment { get; set; }

    /// <summary>
    /// Gets or sets jobType
    /// </summary>
    public string JobType { get; set; }
}

/// <summary>
/// TopFleetByStartDateVm
/// </summary>
public class TopFleetByStartDateVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets StartDate
    /// </summary>
    public string StartDate { get; set; }

    /// <summary>
    /// Gets or sets AveragePerDay
    /// </summary>
    public List<ChecksheetValueAssessmentAreaPerDayVm> AverageAssessmentAreas { get; set; }

    /// <summary>
    /// Gets or sets AverageWci
    /// </summary>
    public double AverageWci { get; set; }
}

/// <summary>
/// FleetPerformanceAchievementParameterIndexPicaVm
/// </summary>
public class FleetPerformanceTablePicaVm : IMapFrom<ChecksheetValue>
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
    /// Gets or sets fleetId
    /// </summary>
    public string FleetId { get; set; }

    /// <summary>
    /// Gets or sets executionDate
    /// </summary>
    public DateTimeOffset? ExecutionDate { get; set; }

    /// <summary>
    /// Gets or sets description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets comment
    /// </summary>
    public string Comment { get; set; }

    /// <summary>
    /// Gets or sets recommendation
    /// </summary>
    public string Recommendation { get; set; }

    /// <summary>
    /// Gets or sets score
    /// </summary>
    public double Score { get; set; }
}
