using AutoMapper;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Category;
using papaMiaBackend.Domain.Entities.Category;
using papaMiaBackend.Domain.Models.Product;

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
    internal CategoryDto? GetCategoryByIdActionExecution(int id)
    {
        var entity = Db.Categories.FirstOrDefault(c => c.Id == id);
        if (entity == null)
        {
            return null;
        }
        return Mapper.Map<CategoryDto>(entity);
    }
    internal CategoryDto CreateCategoryActionExecution(CategoryCreateDto categoryCreateDto)
    {
        var entity = Mapper.Map<Category>(categoryCreateDto);
        Db.Categories.Add(entity);
        Db.SaveChanges();
        return Mapper.Map<CategoryDto>(entity);
    }
    internal CategoryDto? UpdateCategoryActionExecution(int id, CategoryUpdateDto categoryUpdateDto)
    {
        var entity = Db.Categories.FirstOrDefault(c => c.Id == id);
        if (entity == null)
        {
            return null;
        }
        entity.Name = categoryUpdateDto.Name;
        entity.Description = categoryUpdateDto.Description;
        entity.Icon = categoryUpdateDto.Icon;
        entity.Sort = categoryUpdateDto.Sort;
        Db.SaveChanges();
        return Mapper.Map<CategoryDto>(entity);
    }
}

