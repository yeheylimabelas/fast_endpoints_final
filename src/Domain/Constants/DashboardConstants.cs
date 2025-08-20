// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MSCoip.Domain.Constants;

/// <summary>
/// DashboardConstants
/// </summary>
public abstract class DashboardConstants
{
    /// <summary>
    /// DateNotUpdateInDays
    /// </summary>
    public const byte DateNotUpdateInDays = 14;

    /// <summary>
    /// WorkingCondition
    /// </summary>
    public const string WorkingCondition = "Working Condition";

    /// <summary>
    /// OperationAspect
    /// </summary>
    public const string OperationAspect = "Operation Aspect";

    /// <summary>
    /// MachineSupport
    /// </summary>
    public const string MachineSupport = "Machine Support";

    /// <summary>
    /// FormatDate
    /// </summary>
    public static readonly string[] FormatDate = ["yyyy-MM-dd", "yyyy-MM-d"];
}
