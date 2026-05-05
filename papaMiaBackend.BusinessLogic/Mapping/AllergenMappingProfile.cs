using AutoMapper;
using papaMiaBackend.Domain.Entities.Product;
using papaMiaBackend.Domain.Models.Product;

namespace papaMiaBackend.BusinessLogic.Mapping;

public class AllergenMappingProfile : Profile
{
    public AllergenMappingProfile()
    {
        CreateMap<Allergen, AllergenDto>();
    }
}
