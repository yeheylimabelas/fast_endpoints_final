// -----------------------------------------------------------------------------------
// ChecksheetMaster.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using MSCoip.Domain.Common;

namespace MSCoip.Domain.Entities;

/// <summary>
/// ChecksheetMaster
/// </summary>
public record ChecksheetMaster : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets Sector
    /// </summary>
    /// <value></value>
    public string Sector { get; set; }

    /// <summary>
    /// Gets or sets Parameter
    /// </summary>
    /// <value></value>
    public string Parameter { get; set; }

    /// <summary>
    /// Gets or sets AssessmentArea
    /// </summary>
    /// <value></value>
    public string AssessmentArea { get; set; }

    /// <summary>
    /// Gets or sets UnitApplication
    /// </summary>
    /// <value></value>
    public string UnitApplication { get; set; }

    /// <summary>
    /// Gets or sets UnitApplicationId
    /// </summary>
    /// <value></value>
    public Guid? UnitApplicationId { get; set; }

    /// <summary>
    /// Gets or sets Klausul
    /// </summary>
    /// <value></value>
    public string Klausul { get; set; }

    /// <summary>
    /// Gets or sets Description
    /// </summary>
    /// <value></value>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets OperationStandard
    /// </summary>
    /// <value></value>
    public string[] OperationStandard { get; set; }

    /// <summary>
    /// Gets or sets Guidance
    /// </summary>
    /// <value></value>
    public string[] Guidance { get; set; }

    /// <summary>
    /// Gets or sets Score
    /// </summary>
    /// <value></value>
    public short[] Score { get; set; }

    /// <summary>
    /// Gets or sets Weight
    /// </summary>
    /// <value></value>
    public float Weight { get; set; }

    /// <summary>
    /// Gets or sets Sequence
    /// </summary>
    /// <value></value>
    public int Sequence { get; set; }

    /// <summary>
    /// Gets or sets Measurement
    /// </summary>
    /// <value></value>
    public string Measurement { get; set; }
}
