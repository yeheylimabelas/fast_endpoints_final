// -----------------------------------------------------------------------------------
// ParameterCustomerSummaryVm.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MSCoip.Application.Common.Vms;

/// <summary>
/// ParameterCustomerSummaryVm
/// </summary>
public class ParameterCustomerSummaryVm
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets PageNumber
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public int PageNumber { get; set; }

    /// <summary>
    /// Gets or sets checksheetValues
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public List<ChecksheetDetailReportCustomerVm> ChecksheetValues { get; set; }
}
