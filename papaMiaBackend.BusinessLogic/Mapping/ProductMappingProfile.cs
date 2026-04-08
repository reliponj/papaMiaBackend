using AutoMapper;
using papaMiaBackend.Domain.Entities.Product;
using papaMiaBackend.Domain.Models.Product;

namespace papaMiaBackend.BusinessLogic.Mapping;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}

