using AutoMapper;
using papaMiaBackend.Domain.Entities.Promocode;
using papaMiaBackend.Domain.Models.Promocode;

namespace papaMiaBackend.BusinessLogic.Mapping;

public class PromocodeMappingProfile : Profile
{
    public PromocodeMappingProfile()
    {
        CreateMap<Promocode, PromocodeDto>();  
        CreateMap<PromocodeCreateDto, Promocode>()
            .ForMember(d => d.Id, o => o.Ignore());
    }
}