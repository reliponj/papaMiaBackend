using AutoMapper;
using papaMiaBackend.Domain.Entities.Banner;
using papaMiaBackend.Domain.Models.Banner;
namespace papaMiaBackend.BusinessLogic.Mapping;

public class BannerMappingProfile : Profile
{
    public BannerMappingProfile()
    {
        CreateMap<Banner, BannerDto>();
        CreateMap<BannerCreateDto, Banner>()
            .ForMember(d => d.Id, o => o.Ignore());
    }
}
