// -----------------------------------------------------------------------------------
// ChecksheetValueVm.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MSCoip.Application.Common.Mappings;

namespace MSCoip.Application.Common.Vms;

/// <summary>
/// ChecksheetValueAssessmentAreaPerDayVm
/// </summary>
public class ChecksheetValueAssessmentAreaPerDayVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets AssessmentArea
    /// </summary>
    public string AssessmentArea { get; set; }

    /// <summary>
    /// Gets or sets averageScore
    /// </summary>
    public double AverageScore { get; set; }
}

/// <summary>
/// ChecksheetValueParameterVm
/// </summary>
public class ChecksheetValueParameterVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets assessmentAreas
    /// </summary>
    public List<ChecksheetValueAssessmentAreaVm> AssessmentAreas { get; set; }

    /// <summary>
    /// Implicitly converts a ChecksheetValueParameterVm to a List&lt;object&gt;.
    /// </summary>
    /// <param name="v">The ChecksheetValueParameterVm to convert.</param>
    /// <returns>A List&lt;object&gt; representation of the ChecksheetValueParameterVm.</returns>
    public static implicit operator List<object>(ChecksheetValueParameterVm v)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// ChecksheetValueAssessmentAreaVm
/// </summary>
public class ChecksheetValueAssessmentAreaVm : IMapFrom<ChecksheetValue>
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
    /// Gets or sets indexPointArea
    /// </summary>
    public double IndexPointArea { get; set; }

    /// <summary>
    /// Gets or sets clauses
    /// </summary>
    public List<ChecksheetValueClauseVm> Clauses { get; set; }

    /// <summary>
    /// Gets or sets averagePerDay
    /// </summary>
    public List<ChecksheetValueAveragePerDayVm> AveragePerDay { get; set; }
}

/// <summary>
/// ChecksheetValueClauseVm
/// </summary>
public class ChecksheetValueClauseVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets clause
    /// </summary>
    public string Clause { get; set; }

    /// <summary>
    /// Gets or sets description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets dates
    /// </summary>
    public List<ChecksheetValueDateVm> Dates { get; set; }

    /// <summary>
    /// Mapping method for ChecksheetValueClauseVm
    /// </summary>
    /// <param name="profile">The profile to map</param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChecksheetValue, ChecksheetValueAssessmentAreaVm>();
        profile.CreateMap<ChecksheetValue, ChecksheetValueDateVm>();
        profile.CreateMap<ChecksheetValue, ChecksheetValueClauseVm>();
    }
}

/// <summary>
/// ChecksheetValueAveragePerDayVm
/// </summary>
public class ChecksheetValueAveragePerDayVm
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets date
    /// </summary>
    public string Date { get; set; }

    /// <summary>
    /// Gets or sets averageScore
    /// </summary>
    public double AverageScore { get; set; }

    /// <summary>
    /// Gets or sets jobType
    /// </summary>
    public string JobType { get; set; }
}

/// <summary>
/// ChecksheetValueDateVm
/// </summary>
public class ChecksheetValueDateVm : IMapFrom<ChecksheetValue>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets date
    /// </summary>
    public string Date { get; set; }

    /// <summary>
    /// Gets or sets score
    /// </summary>
    public double Score { get; set; }
}
