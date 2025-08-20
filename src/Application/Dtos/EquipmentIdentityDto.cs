using System;
using MSCoip.Application.Common.Dtos;
using MSCoip.Application.Common.Mappings;

namespace MSCoip.Application.Dtos;

/// <summary>
/// EquipmentIdentityDto
/// </summary>
public class EquipmentIdentityDto : AuditTableDto, IMapFrom<EquipmentIdentity>
{
    /// <summary>
    /// Gets or sets jobId
    /// </summary>
    /// <value></value>
    public Guid? JobId { get; set; }

    /// <summary>
    /// Gets or sets equipmentId
    /// </summary>
    /// <value></value>
    public Guid? EquipmentId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether IsProductUT
    /// </summary>
    /// <value></value>
    public bool? IsProductUT { get; set; }

    /// <summary>
    /// Gets or sets malfStartTime
    /// </summary>
    /// <value></value>
    public DateTimeOffset? MalfStartTime { get; set; }

    /// <summary>
    /// Gets or sets malfEndTime
    /// </summary>
    /// <value></value>
    public DateTimeOffset? MalfEndTime { get; set; }

    /// <summary>
    /// Gets or sets sMR
    /// </summary>
    /// <value></value>
    public float? SMR { get; set; }

    /// <summary>
    /// Gets or sets hM
    /// </summary>
    /// <value></value>
    public float? HM { get; set; }

    /// <summary>
    /// Gets or sets kM
    /// </summary>
    /// <value></value>
    public float? KM { get; set; }

    /// <summary>
    /// Gets or sets location
    /// </summary>
    /// <value></value>
    public string Location { get; set; }

    /// <summary>
    /// Gets or sets specificLocation
    /// </summary>
    /// <value></value>
    public string SpecificLocation { get; set; }

    /// <summary>
    /// Gets or sets location
    /// </summary>
    /// <value></value>
    public string Sector { get; set; }

    /// <summary>
    /// Gets or sets location
    /// </summary>
    /// <value></value>
    public string[] UnitApplications { get; set; }

    /// <summary>
    /// Gets or sets location
    /// </summary>
    /// <value></value>
    public string[] Materials { get; set; }

    /// <summary>
    /// Gets or sets location
    /// </summary>
    /// <value></value>
    public string[] Methods { get; set; }

    /// <summary>
    /// Gets or sets location
    /// </summary>
    /// <value></value>
    public string[] UnitSupports { get; set; }

    /// <summary>
    /// Gets or sets location
    /// </summary>
    /// <value></value>
    public string[] TypeUnits { get; set; }

    /// <summary>
    /// Gets or sets customerOperator
    /// </summary>
    /// <value></value>
    public string CustomerOperator { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<EquipmentIdentity, EquipmentIdentityDto>()
            .ForMember(dto => dto.UnitSupports, conf => conf.Ignore());
    }
}
