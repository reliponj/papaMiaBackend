using papaMiaBackend.Domain.Models.Category;

namespace papaMiaBackend.BusinessLogic.Interfaces;
public interface ICategoryAction
{
    List<CategoryDto> GetAllCategoriesAction();
    CategoryDto? GetCategoryByIdAction(int id);
    CategoryDto CreateCategoryAction(CategoryCreateDto categoryCreateDto);
    CategoryDto? UpdateCategoryAction(int id, CategoryUpdateDto categoryUpdateDto);
}

