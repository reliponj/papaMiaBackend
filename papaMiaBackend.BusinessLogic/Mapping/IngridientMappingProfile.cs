using AutoMapper;
using papaMiaBackend.Domain.Entities.Ingridient;
using papaMiaBackend.Domain.Models.Ingridient;

namespace papaMiaBackend.BusinessLogic.Mapping;

public class IngridientMappingProfile : Profile
{
    public IngridientMappingProfile()
    {
        CreateMap<Ingridient, IngridientDto>();
        CreateMap<IngridientCreateDto, Ingridient>()
            .ForMember(d => d.Id, o => o.Ignore());
        CreateMap<IngridientUpdateDto, Ingridient>()
            .ForMember(d => d.Id, o => o.Ignore());
    }
}
