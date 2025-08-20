// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MSCoip.Domain.Constants;

/// <summary>
/// ValidationConstants
/// </summary>
public abstract class ValidationConstants
{
    /// <summary>
    /// Maximum Length Base64 in byte
    /// </summary>
    public const int MaximumLengthBase64 = 512 * 1024;

    /// <summary>
    /// Maximum File Size in byte
    /// </summary>
    public const int MaximumFileSize = 3072 * 1024;
}
