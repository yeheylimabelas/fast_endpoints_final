// -----------------------------------------------------------------------------------
// ParameterSummaryVm.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MSCoip.Application.Common.Vms;

/// <summary>
/// ParameterSummaryVm
/// </summary>
public class ParameterSummaryVm
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets parameter
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string Parameter { get; set; }

    /// <summary>
    /// Gets or sets assessmentAreas
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public List<AssessmentAreaSummaryVm> AssessmentAreas { get; set; }
}

/// <summary>
/// AssessmentAreaSummaryVm
/// </summary>
public class AssessmentAreaSummaryVm
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets assessmentArea
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string AssessmentArea { get; set; }

    /// <summary>
    /// Gets or sets checksheetValues
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public List<ChecksheetDetailVm> ChecksheetValues { get; set; }
}