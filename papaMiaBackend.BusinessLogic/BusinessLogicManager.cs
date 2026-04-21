using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.BusinessLogic.Structure;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Models.Auth;

namespace papaMiaBackend.BusinessLogic;

public class BusinessLogicManager
{
    private readonly IMapper _mapper;
    private readonly UserContext _userDb;
    private readonly ProductContext _productDb;
    private readonly CartContext _cartDb;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IOptions<JwtGenerationSettings> _jwtOptions;

    public BusinessLogicManager(
        IMapper mapper,
        UserContext userDb,
        ProductContext productDb,
        CartContext cartDb,
        IPasswordHasher<User> passwordHasher,
        IOptions<JwtGenerationSettings> jwtOptions)
    {
        _mapper = mapper;
        _userDb = userDb;
        _productDb = productDb;
        _cartDb = cartDb;
        _passwordHasher = passwordHasher;
        _jwtOptions = jwtOptions;
    }

    public IUserAction UserAction()
    {
        return new UserActionExecution(_mapper, _userDb);
    }

    public IAuthAction AuthAction()
    {
        return new AuthActionExecution(_userDb, _mapper, _passwordHasher, _jwtOptions);
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
