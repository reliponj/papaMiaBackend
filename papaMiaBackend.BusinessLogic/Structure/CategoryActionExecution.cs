using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;

namespace papaMiaBackend.BusinessLogic.Structure;
public class CategoryActionExecution : CategoryActions, ICategoryAction
{
    public CategoryActionExecution(IMapper mapper, ProductContext db)
        : base(mapper, db)
    {
    }
}

