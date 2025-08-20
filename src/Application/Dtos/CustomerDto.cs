using MSCoip.Application.Common.Dtos;
using MSCoip.Application.Common.Mappings;

namespace MSCoip.Application.Dtos;

/// <summary>
/// CustomerDto
/// </summary>
public class CustomerDto : AuditTableDto, IMapFrom<Customer>
{
    /// <summary>
    /// Gets or sets Code
    /// </summary>
    /// <value></value>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets Name
    /// </summary>
    /// <value></value>
    public string Name { get; set; }

    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="profile"></param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CustomerDto, Customer>()
      .ForMember(dest => dest.IsActive, conf => conf.MapFrom(src => true))
          .ForMember(dest => dest.UpdatedBy, conf => conf.MapFrom(src => src.CreatedBy))
          .ForMember(dest => dest.UpdatedDate, conf => conf.MapFrom(src => src.CreatedDate));
        profile.CreateMap<Customer, CustomerDto>();
    }
}
