using AutoMapper;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.BusinessLogic.Structure;
using papaMiaBackend.DataAccess.Context;

namespace papaMiaBackend.BusinessLogic;

public class BusinessLogicManager
{
    private readonly IMapper _mapper;
    private readonly UserContext _userDb;
    private readonly ProductContext _productDb;

    public BusinessLogicManager(IMapper mapper, UserContext userDb, ProductContext productDb)
    {
        _mapper = mapper;
        _userDb = userDb;
        _productDb = productDb;
    }

    public IUserAction UserAction()
    {
        return new UserActionExecution(_mapper, _userDb);
    }

    public IProductAction ProductAction()
    {
        return new ProductActionExecution(_mapper, _productDb);
    }
    public ICategoryAction CategoryAction()
    {
        return new CategoryActionExecution(_mapper, _productDb);
    }
}
