// -----------------------------------------------------------------------------------
// AuditTableConfiguration.cs 2023
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using MSCoip.Application.Common.Mappings;

namespace MSCoip.Application.Dtos;

/// <summary>
/// EquipmentDto
/// </summary>
public class EquipmentDto : IMapFrom<Equipment>
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets CustomerId
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Gets or sets AttachmentType
    /// </summary>
    public string AttachmentType { get; set; }

    /// <summary>
    /// Gets or sets AttachmentModel
    /// </summary>
    public string AttachmentModel { get; set; }

    /// <summary>
    /// Gets or sets UnitCode
    /// </summary>
    public string UnitCode { get; set; }

    /// <summary>
    /// Gets or sets UnitModel
    /// </summary>
    public string UnitModel { get; set; }

    /// <summary>
    /// Gets or sets SerialNumber
    /// </summary>
    public string SerialNumber { get; set; }

    /// <summary>
    /// Gets or sets DeliveryDate
    /// </summary>
    public DateTimeOffset? DeliveryDate { get; set; }

    /// <summary>
    /// Gets or sets IsAllFleet
    /// </summary>
    public bool IsAllFleet { get; set; }

    /// <summary>
    /// Gets or sets UnitStatus
    /// </summary>
    public bool UnitStatus { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Equipment, EquipmentDto>()
            .ForMember(x => x.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
            .ForMember(dest => dest.UnitStatus, opt => opt.MapFrom(src => src.IsActive))
            .ReverseMap();
    }
}

/// <summary>
/// EquipmentDownloadDto
/// </summary>
public class EquipmentDownloadDto : IMapFrom<Equipment>
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets CustomerId
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Gets or sets CustomerName
    /// </summary>
    public string CustomerName { get; set; }

    /// <summary>
    /// Gets or sets AttachmentType
    /// </summary>
    public string AttachmentType { get; set; }

    /// <summary>
    /// Gets or sets AttachmentModel
    /// </summary>
    public string AttachmentModel { get; set; }

    /// <summary>
    /// Gets or sets UnitCode
    /// </summary>
    public string UnitCode { get; set; }

    /// <summary>
    /// Gets or sets UnitModel
    /// </summary>
    public string UnitModel { get; set; }

    /// <summary>
    /// Gets or sets SerialNumber
    /// </summary>
    public string SerialNumber { get; set; }

    /// <summary>
    /// Gets or sets DeliveryDate
    /// </summary>
    public DateTimeOffset? DeliveryDate { get; set; }

    /// <summary>
    /// Gets or sets EquipmentNumber
    /// </summary>
    public string EquipmentNumber { get; set; }

    /// <summary>
    /// Gets or sets CustomerGroup
    /// </summary>
    public string CustomerGroup { get; set; }

    /// <summary>
    /// Gets or sets CustomerGroupName
    /// </summary>
    public string CustomerGroupName { get; set; }

    /// <summary>
    /// Gets or sets PlantCode
    /// </summary>
    public string PlantCode { get; set; }

    /// <summary>
    /// Gets or sets PlantDescription
    /// </summary>
    public string PlantDescription { get; set; }

    /// <summary>
    /// Gets or sets WorkCenterCode
    /// </summary>
    public string WorkCenterCode { get; set; }

    /// <summary>
    /// Gets or sets WorkCenterDesc
    /// </summary>
    public string WorkCenterDesc { get; set; }

    /// <summary>
    /// Gets or sets BrandCode
    /// </summary>
    public string BrandCode { get; set; }

    /// <summary>
    /// Gets or sets BrandName
    /// </summary>
    public string BrandName { get; set; }

    /// <summary>
    /// Gets or sets IsAllFleet
    /// </summary>
    public bool IsAllFleet { get; set; }

    /// <summary>
    /// Gets or sets UnitStatus
    /// </summary>
    public bool UnitStatus { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Equipment, EquipmentDownloadDto>()
            .ForMember(dst => dst.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
            .ForMember(dest => dest.UnitStatus, opt => opt.MapFrom(src => src.IsActive))
            .ReverseMap();
    }
}

/// <summary>
/// EquipmentUpdateDto
/// </summary>
public class EquipmentUpdateDto : IMapFrom<Equipment>
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    public string Id { get; set; }

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
    public bool IsAllFleet { get; set; }

    /// <summary>
    /// Gets or sets UnitStatus
    /// </summary>
    public bool UnitStatus { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Equipment, EquipmentUpdateDto>()
            .ReverseMap();
    }
}

/// <summary>
/// UploadUnitPopulationExcelDto
/// </summary>
/// <value></value>
public class UploadUnitPopulationExcelDto : IMapFrom<Equipment>
{
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
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Equipment, UploadUnitPopulationExcelDto>()
            .ReverseMap();
    }
}

/// <summary>
/// TemplateUnitPopulationExcelDto
/// </summary>
/// <value></value>
public class TemplateUnitPopulationExcelDto : IMapFrom<Equipment>
{
    /// <summary>
    /// Gets or sets a value indicating whether the product is UT.
    /// </summary>
    /// <value></value>
    public bool IsProductUT { get; set; }

    /// <summary>
    /// Gets or sets customerName
    /// </summary>
    /// <value></value>
    public string CustomerName { get; set; }

    /// <summary>
    /// Gets or sets customerCode
    /// </summary>
    /// <value></value>
    public string CustomerCode { get; set; }

    /// <summary>
    /// Gets or sets plant
    /// </summary>
    /// <value></value>
    public string Plant { get; set; }

    /// <summary>
    /// Gets or sets brandCode
    /// </summary>
    /// <value></value>
    public string BrandCode { get; set; }

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
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Equipment, TemplateUnitPopulationExcelDto>()
            .ForMember(x => x.Plant, opt => opt.MapFrom(src => src.PlantCode))
            .ReverseMap();
    }
}
