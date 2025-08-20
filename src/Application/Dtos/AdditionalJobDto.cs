using System;
using MSCoip.Application.Common.Dtos;
using MSCoip.Application.Common.Mappings;

namespace MSCoip.Application.Dtos;

/// <summary>
/// AdditionalJobDto
/// </summary>
public class AdditionalJobDto : AuditTableDto, IMapFrom<AdditionalJob>
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
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<AdditionalJob, AdditionalJobDto>().ReverseMap();
    }
}
