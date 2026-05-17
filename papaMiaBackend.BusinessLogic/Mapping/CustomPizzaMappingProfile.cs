using AutoMapper;
using PizzaNs = papaMiaBackend.Domain.Entities.CustomPizza;
using papaMiaBackend.Domain.Models.CustomPizza;

namespace papaMiaBackend.BusinessLogic.Mapping;

public class CustomPizzaMappingProfile : Profile
{
    public CustomPizzaMappingProfile()
    {
        CreateMap<CustomPizzaCreateDto, PizzaNs.CustomPizza>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Ingridients, o => o.Ignore());

        CreateMap<PizzaNs.CustomPizza, CustomPizzaDto>()
            .ForMember(d => d.IngridientIds, o => o.MapFrom(s => s.Ingridients.Select(i => i.Id).ToList()));
    }
}
