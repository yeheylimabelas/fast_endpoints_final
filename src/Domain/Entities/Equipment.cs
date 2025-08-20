// -----------------------------------------------------------------------------------
// Equipment.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MSCoip.Domain.Common;

namespace MSCoip.Domain.Entities;

/// <summary>
/// Equipment
/// </summary>
/// <value></value>
public record Equipment : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets customerId
    /// </summary>
    /// <value></value>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Gets or sets unitModel
    /// </summary>
    /// <value></value>
    public string UnitModel { get; set; }

    /// <summary>
    /// Gets or sets serialNumber
    /// </summary>
    /// <value></value>
    public string SerialNumber { get; set; }

    /// <summary>
    /// Gets or sets unitCode
    /// </summary>
    /// <value></value>
    public string UnitCode { get; set; }

    /// <summary>
    /// Gets or sets equipmentNumber
    /// </summary>
    /// <value></value>
    public string EquipmentNumber { get; set; }

    /// <summary>
    /// Gets or sets equipmentCategory
    /// </summary>
    /// <value></value>
    public string EquipmentCategory { get; set; }

    /// <summary>
    /// Gets or sets customerCode
    /// </summary>
    /// <value></value>
    public string CustomerCode { get; set; }

    /// <summary>
    /// Gets or sets customerName
    /// </summary>
    /// <value></value>
    public string CustomerName { get; set; }

    /// <summary>
    /// Gets or sets plantCode
    /// </summary>
    /// <value></value>
    public string PlantCode { get; set; }

    /// <summary>
    /// Gets or sets plantDescription
    /// </summary>
    /// <value></value>
    public string PlantDescription { get; set; }

    /// <summary>
    /// Gets or sets workCenterCode
    /// </summary>
    /// <value></value>
    public string WorkCenterCode { get; set; }

    /// <summary>
    /// Gets or sets brandCode
    /// </summary>
    /// <value></value>
    public string BrandCode { get; set; }

    /// <summary>
    /// Gets or sets engineModel
    /// </summary>
    /// <value></value>
    public string EngineModel { get; set; }

    /// <summary>
    /// Gets or sets engineSerialNumber
    /// </summary>
    /// <value></value>
    public string EngineSerialNumber { get; set; }

    /// <summary>
    /// Gets or sets masterWarranty
    /// </summary>
    /// <value></value>
    public string MasterWarranty { get; set; }

    /// <summary>
    /// Gets or sets warrantyStartDate
    /// </summary>
    /// <value></value>
    public DateTimeOffset? WarrantyStartDate { get; set; }

    /// <summary>
    /// Gets or sets warrantyEndDate
    /// </summary>
    /// <value></value>
    public DateTimeOffset? WarrantyEndDate { get; set; }

    /// <summary>
    /// Gets or sets lastOperationDate
    /// </summary>
    /// <value></value>
    public DateTimeOffset? LastOperationDate { get; set; }

    /// <summary>
    /// Gets or sets sMRValuePerDayInMinutes
    /// </summary>
    /// <value></value>
    public float? SMRValuePerDayInMinutes { get; set; }

    /// <summary>
    /// Gets or sets sMRTotalInMinutes
    /// </summary>
    /// <value></value>
    public float? SMRTotalInMinutes { get; set; }

    /// <summary>
    /// Gets or sets sMRLastValueDate
    /// </summary>
    /// <value></value>
    public DateTimeOffset? SMRLastValueDate { get; set; }

    /// <summary>
    /// Gets or sets cautionCounter
    /// </summary>
    /// <value></value>
    public string CautionCounter { get; set; }

    /// <summary>
    /// Gets or sets deliveryDate
    /// </summary>
    /// <value></value>
    public DateTimeOffset? DeliveryDate { get; set; }

    /// <summary>
    /// Gets or sets KomtraxMeterReading
    /// </summary>
    /// <value></value>
    public float? KomtraxMeterReading { get; set; }

    /// <summary>
    /// Gets or sets KomtraxMeterReadingDate
    /// </summary>
    /// <value></value>
    public DateTimeOffset? KomtraxMeterReadingDate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether IsProductUT
    /// </summary>
    /// <value></value>
    public bool IsProductUT { get; set; }

    /// <summary>
    /// Gets or sets AttachmentType
    /// </summary>
    public string AttachmentType { get; set; }

    /// <summary>
    /// Gets or sets AttachmentModel
    /// </summary>
    public string AttachmentModel { get; set; }

    /// <summary>
    /// Gets or sets IsAllFleet
    /// </summary>
    public bool IsAllFleet { get; set; } = true;

    /// <summary>
    /// Gets or sets equipmentIdentity
    /// </summary>
    /// <value></value>
    public ICollection<EquipmentIdentity> EquipmentValues { get; set; }

    /// <summary>
    /// Gets or sets customer
    /// </summary>
    [IgnoreDataMember]
    public virtual Customer Customer { get; set; }
}
