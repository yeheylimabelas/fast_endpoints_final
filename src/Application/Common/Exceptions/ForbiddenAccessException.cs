using System;
using System.Runtime.Serialization;

namespace MSCoip.Application.Common.Exceptions;

/// <summary>
/// ForbiddenAccessException
/// </summary>
[Serializable]
public class ForbiddenAccessException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ForbiddenAccessException"/> class.
    /// </summary>
    public ForbiddenAccessException()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ForbiddenAccessException"/> class.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected ForbiddenAccessException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
