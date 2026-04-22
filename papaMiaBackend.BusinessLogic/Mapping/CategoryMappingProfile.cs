using AutoMapper;
using papaMiaBackend.Domain.Entities.Category;
using papaMiaBackend.Domain.Models.Category;

namespace papaMiaBackend.BusinessLogic.Mapping;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryDto>();

        CreateMap<CategoryCreateDto, Category>()
            .ForMember(d => d.Id, o => o.Ignore());
    }
}