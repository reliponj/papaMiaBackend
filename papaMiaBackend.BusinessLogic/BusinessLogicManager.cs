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
    private readonly CartContext _cartDb;

    public BusinessLogicManager(IMapper mapper, UserContext userDb, ProductContext productDb, CartContext cartDb)
    {
        _mapper = mapper;
        _userDb = userDb;
        _productDb = productDb;
        _cartDb = cartDb;
    }

    public IUserAction UserAction()
    {
        return new UserActionExecution(_mapper, _userDb);
    }

    public IAuthAction AuthAction()
    {
        return new AuthActionExecution(_userDb, _mapper);
    }

    public IProductAction ProductAction()
    {
        return new ProductActionExecution(_mapper, _productDb);
    }

    public ICartAction CartAction()
    {
        return new CartActionExecution(_mapper, _cartDb);
    }
}
