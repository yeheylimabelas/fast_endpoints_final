// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace MSCoip.Domain.Constants;

/// <summary>
/// EventHubConstants
/// </summary>
public abstract class EventHubConstants
{
    /// <summary>
    /// DefaultHealthCheckEventHub
    /// </summary>
    public const string DefaultHealthCheckEventHub = "EventHub";

    /// <summary>
    /// EventHubUCP
    /// </summary>
    public const string EventHubUCP = "ucp";

    /// <summary>
    /// EventHubNameEM
    /// </summary>
    public const string EventHubNameEM = "utportal_equipmentmonitoringservice_equipment";

    /// <summary>
    /// ConsumerList
    /// </summary>
    public static readonly IReadOnlyDictionary<string, (string, bool, byte)> ConsumerJobList =
        new Dictionary<string, (string, bool, byte)>
        {
            { EventHubNameEM, (EventHubUCP, false, 12) },
        };

    /// <summary>
    /// FormatDateFile
    /// </summary>
    public readonly record struct FormatDateFile
    {
        /// <summary>
        /// EM
        /// </summary>
        public const string EM = "MM/dd/yyyy HH:mm:ss";
    }
}
