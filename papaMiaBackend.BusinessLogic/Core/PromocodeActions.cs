using AutoMapper;
using papaMiaBackend.DataAccess.Context;

namespace papaMiaBackend.BusinessLogic.Core;
public class PromocodeActions
{
    protected readonly IMapper Mapper;
    protected readonly PromocodeContext Db;
    public PromocodeActions(IMapper mapper, PromocodeContext db)
    {
        Mapper = mapper;
        Db = db;
    }
}