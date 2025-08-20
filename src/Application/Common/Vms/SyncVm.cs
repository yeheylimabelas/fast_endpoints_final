// -----------------------------------------------------------------------------------
// SyncVm.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MSCoip.Application.Common.Vms;

/// <summary>
/// SyncVm
/// </summary>
public class SyncVm
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets SyncChecksheetValue
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public List<SyncChecksheetValueVm> SyncChecksheetValue { get; set; }

    /// <summary>
    /// Gets or sets checksheetMasters
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public List<ChecksheetMasterDetailVm> ChecksheetMaster { get; set; }

    /// <summary>
    /// Gets or sets syncDate
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string SyncDate { get; set; }
}

/// <summary>
/// SyncChecksheetValueVm
/// </summary>
public class SyncChecksheetValueVm
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets customerCode
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public string CustomerCode { get; set; }

    /// <summary>
    /// Gets or sets checksheetValue
    /// </summary>
    /// <value></value>
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public List<ChecksheetValueDetailVm> ChecksheetValue { get; set; }
}
