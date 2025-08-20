// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace MSCoip.Domain.Constants;

/// <summary>
/// ProcessConstants
/// </summary>
public abstract class ProcessConstants
{
    /// <summary>
    /// DefaultTotalMaxProcess
    /// </summary>
    public const byte DefaultTotalMaxProcess = 25;

    /// <summary>
    /// File Extensions
    /// </summary>
    public static readonly IReadOnlyList<string> FileExtensions = new List<string>
    {
        "csv",
        "xls",
        "xlsx"
    };
}
