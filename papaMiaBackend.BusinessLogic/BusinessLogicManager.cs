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
    private readonly RoleContext _roleDb;
    private readonly BannerContext _bannerDb;
    private readonly PromocodeContext _promocodeDb;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IOptions<JwtGenerationSettings> _jwtOptions;

    public BusinessLogicManager(
        IMapper mapper,
        UserContext userDb,
        ProductContext productDb,
        RoleContext roleDb,
        BannerContext bannerDb,
        PromocodeContext promocodeDb,
        IPasswordHasher<User> passwordHasher,
        IOptions<JwtGenerationSettings> jwtOptions)
    {
        _mapper = mapper;
        _userDb = userDb;
        _productDb = productDb;
        _roleDb = roleDb;
        _bannerDb = bannerDb;
        _promocodeDb = promocodeDb;
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
    public IRoleAction RoleAction()
    {
        return new RoleActionExecution(_mapper, _roleDb);
    }
    public IPermissionGroupAction PermissionGroupAction()
    {
        return new PermissionGroupActionExecution(_mapper, _roleDb);
    }
    public ICategoryAction CategoryAction()
    {
        return new CategoryActionExecution(_mapper, _productDb);
    }
    public IBannerAction BannerAction()
    {
        return new BannerActionExecution(_mapper, _bannerDb);
    }
    public IPromocodeAction PromocodeAction()
    {
        return new PromocodeActionExecution(_mapper, _promocodeDb);
    }
}
