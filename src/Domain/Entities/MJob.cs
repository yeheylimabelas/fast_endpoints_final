using System;
using MSCoip.Domain.Common;

namespace MSCoip.Domain.Entities;

/// <summary>
/// MJob
/// </summary>
public record MJob : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets parentId
    /// </summary>
    /// <value></value>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether isParent
    /// </summary>
    /// <value></value>
    public bool IsParent { get; set; }

    /// <summary>
    /// Gets or sets type
    /// </summary>
    /// <value></value>
    public string JobType { get; set; }

    /// <summary>
    /// Gets or sets desc
    /// </summary>
    /// <value></value>
    public string Desc { get; set; }

    /// <summary>
    /// Gets or sets sequence
    /// </summary>
    /// <value></value>
    public int? Sequence { get; set; }
}
