// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MSCoip.Domain.Constants;

/// <summary>
/// MsTeamConstants
/// </summary>
public abstract class MsTeamConstants
{
    /// <summary>
    /// MsTeamsServiceName
    /// </summary>
    public const string ServiceName = "MSCoip";

    /// <summary>
    /// MsTeamsServiceDomain
    /// </summary>
    public const string ServiceDomain = "mscoip.dev-aks.unitedtractors.com";

    /// <summary>
    /// MsTeamsImageWarning
    /// </summary>
    public const string ImageWarning = "https://cdn-icons-png.flaticon.com/512/1537/1537854.png";

    /// <summary>
    /// MsTeamsImageError
    /// </summary>
    public const string ImageError = "https://cdn-icons-png.flaticon.com/512/2100/2100813.png";

    /// <summary>
    /// MsTeamsSummary
    /// </summary>
    public const string SummaryError = "Something wrong";

    /// <summary>
    /// MsTeamsactivitySubtitleStart
    /// </summary>
    public const string ActivitySubtitleStart = "Application has started";

    /// <summary>
    /// MsTeamsactivitySubtitleStop
    /// </summary>
    public const string ActivitySubtitleStop = "Application has stopped";

    /// <summary>
    /// MsTeamsThemeColorError
    /// </summary>
    public const string ThemeColorError = "#eb090d";

    /// <summary>
    /// MsTeamsThemeColorWarning
    /// </summary>
    public const string ThemeColorWarning = "#f7db05";

    /// <summary>
    /// MsTeamsMaxSizeInBytes
    /// </summary>
    public const int MaxSizeInBytes = 5_242_880;
}
