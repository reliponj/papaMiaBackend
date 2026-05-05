using AutoMapper;
using papaMiaBackend.Domain.Entities.Product;
using papaMiaBackend.Domain.Models.Product;

namespace papaMiaBackend.BusinessLogic.Mapping;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<Product, ProductListDto>();

        CreateMap<ProductCreateDto, Product>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Category, o => o.Ignore())
            .ForMember(d => d.AllergenLinks, o => o.Ignore());

        CreateMap<ProductUpdateDto, Product>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Category, o => o.Ignore())
            .ForMember(d => d.AllergenLinks, o => o.Ignore());
    }
}

