// -----------------------------------------------------------------------------------
// CoipConstants.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

namespace MSCoip.Domain.Constants;

/// <summary>
/// CoipConstants
/// </summary>
public abstract class CoipConstants
{
    /// <summary>
    /// ReportTypeInternal
    /// </summary>
    public const string ReportTypeInternal = "Internal";

    /// <summary>
    /// ReportTypeExternal
    /// </summary>
    public const string ReportTypeExternal = "External";

    /// <summary>
    /// ReportTypeCustomer
    /// </summary>
    public const string ReportTypeCustomer = "Customer";

    /// <summary>
    /// JobStatusAssigned
    /// </summary>
    public const string JobStatusNewAssigned = "0";

    /// <summary>
    /// JobStatusApproved
    /// </summary>
    public const string JobStatusJobCompleted = "2";

    /// <summary>
    /// JobStatusCanceled
    /// </summary>
    public const string JobStatusCanceled = "-1";

    /// <summary>
    /// FormatDate
    /// </summary>
    public static readonly string[] FormatDate = ["yyyy-MM-dd", "yyyy-MM-d"];
}
