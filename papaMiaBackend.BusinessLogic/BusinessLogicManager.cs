using AutoMapper;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.BusinessLogic.Structure;
using papaMiaBackend.DataAccess.Context;

namespace papaMiaBackend.BusinessLogic;

public class BusinessLogicManager
{
    private readonly IMapper _mapper;
    private readonly UserContext _db;

    public BusinessLogicManager(IMapper mapper, UserContext db)
    {
        _mapper = mapper;
        _db = db;
    }

    public IUserAction UserAction()
    {
        return new UserActionExecution(_mapper, _db);
    }

    public IProductAction ProductAction()
    {
        return new ProductActionExecution(_mapper, _db);
    }
}
