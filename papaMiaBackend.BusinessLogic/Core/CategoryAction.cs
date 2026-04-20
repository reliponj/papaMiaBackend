using AutoMapper;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Category;
using papaMiaBackend.Domain.Entities.Category;

namespace papaMiaBackend.BusinessLogic.Core;
public class CategoryActions
{
    protected readonly IMapper Mapper;
    protected readonly ProductContext Db;
    public CategoryActions(IMapper mapper, ProductContext db)
    {
        Mapper = mapper;
        Db = db;
    }
    internal List<CategoryDto> GetAllCategoriesActionExecution()
    {
        var entities = Db.Categories.ToList();
        return Mapper.Map<List<CategoryDto>>(entities);
    }
}

