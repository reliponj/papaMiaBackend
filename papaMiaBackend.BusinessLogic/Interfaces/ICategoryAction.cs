using papaMiaBackend.Domain.Models.Category;

namespace papaMiaBackend.BusinessLogic.Interfaces;
public interface ICategoryAction
{
    List<CategoryDto> GetAllCategoriesAction();
}

