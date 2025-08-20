using System;
using MSCoip.Domain.Common;

namespace MSCoip.Domain.Entities;

/// <summary>
/// AdditionalJob
/// </summary>
public record AdditionalJob : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets jobId
    /// </summary>
    /// <value></value>
    public Guid? JobId { get; set; }

    /// <summary>
    /// Gets or sets desc
    /// </summary>
    /// <value></value>
    public string Desc { get; set; }

    /// <summary>
    /// Gets or sets parameter
    /// </summary>
    /// <value></value>
    public string Parameter { get; set; }

    /// <summary>
    /// Gets or sets unitApplication
    /// </summary>
    /// <value></value>
    public string UnitApplication { get; set; }

    /// <summary>
    /// Gets or sets job
    /// </summary>
    /// <value></value>
    public Job Job { get; set; }
}
