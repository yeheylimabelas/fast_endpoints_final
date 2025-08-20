// -----------------------------------------------------------------------------------
// MostActiveObserverVm.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using MSCoip.Application.Common.Mappings;

namespace MSCoip.Application.Common.Vms;

/// <summary>
/// MostActiveObserverVm
/// </summary>
public class MostActiveObserverVm : IMapFrom<Job>
{
    /// <summary>
    /// Gets or sets id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets ObserverName
    /// </summary>
    public string ObserverName { get; set; }

    /// <summary>
    /// Gets or sets Qty
    /// </summary>
    public int? Qty { get; set; }

    /// <summary>
    /// Gets or sets AverageScore
    /// </summary>
    public double AverageScore { get; set; }

    /// <summary>
    /// Gets or sets JobType
    /// </summary>
    public string JobType { get; set; }
}
