using AutoMapper;
using papaMiaBackend.DataAccess.Context;

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
}

