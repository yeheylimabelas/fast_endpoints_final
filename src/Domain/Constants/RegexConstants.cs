// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Reflection.Metadata;

namespace MSCoip.Domain.Constants;

/// <summary>
/// RegexConstants
/// </summary>
public abstract class RegexConstants
{
    /// <summary>
    /// RegexPattern
    /// </summary>
    public const string Pattern = @"^[{pattern}]+$";

    /// <summary>
    /// RegexChar
    /// </summary>
    public const string Char = "a-zA-Z";

    /// <summary>
    /// RegexNumeric
    /// </summary>
    public const string Numeric = "0-9";

    /// <summary>
    /// RegexSymbol
    /// </summary>
    public const string Symbol = @"\&()@_:;/.-";

    /// <summary>
    /// RegexEmoji
    /// </summary>
    public const string Emoji = @"(\u00a9|\u00ae|[\u2000-\u3300]|\ud83c[\ud000-\udfff]|\ud83d[\ud000-\udfff]|\ud83e[\ud000-\udfff])";
}
