using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Category;

namespace papaMiaBackend.BusinessLogic.Structure;
public class CategoryActionExecution : CategoryActions, ICategoryAction
{
    public CategoryActionExecution(IMapper mapper, ProductContext db)
        : base(mapper, db)
    {
    }

    public List<CategoryDto> GetAllCategoriesAction()
    {
        return GetAllCategoriesActionExecution();
    }
}

