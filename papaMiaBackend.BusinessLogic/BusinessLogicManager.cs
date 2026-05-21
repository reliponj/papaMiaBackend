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
    private readonly OrderContext _orderDb;
    private readonly IngridientContext _ingridientDb;
    private readonly CustomPizzaContext _customPizzaDb;
    private readonly RoleContext _roleDb;
    private readonly BannerContext _bannerDb;
    private readonly PromocodeContext _promocodeDb;
    private readonly ReviewContext _reviewDb;
    private readonly ArticleContext _articleDb;
    private readonly LocationContext _locationDb;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IOptions<JwtGenerationSettings> _jwtOptions;

    public BusinessLogicManager(
        IMapper mapper,
        UserContext userDb,
        ProductContext productDb,
        OrderContext orderDb,
        IngridientContext ingridientDb,
        CustomPizzaContext customPizzaDb,
        RoleContext roleDb,
        BannerContext bannerDb,
        PromocodeContext promocodeDb,
        ReviewContext reviewDb,
        ArticleContext articleDb,
        LocationContext locationDb,
        IPasswordHasher<User> passwordHasher,
        IOptions<JwtGenerationSettings> jwtOptions)
    {
        _mapper = mapper;
        _userDb = userDb;
        _productDb = productDb;
        _orderDb = orderDb;
        _ingridientDb = ingridientDb;
        _customPizzaDb = customPizzaDb;
        _roleDb = roleDb;
        _bannerDb = bannerDb;
        _promocodeDb = promocodeDb;
        _reviewDb = reviewDb;
        _articleDb = articleDb;
        _locationDb = locationDb;
        _passwordHasher = passwordHasher;
        _jwtOptions = jwtOptions;
    }

    public IUserAction UserAction()
    {
        return new UserActionExecution(_mapper, _userDb, _passwordHasher);
    }

    public IFavoriteAction FavoriteAction()
    {
        return new FavoriteActionExecution(_mapper, _userDb, _productDb);
    }

    public IAuthAction AuthAction()
    {
        return new AuthActionExecution(_userDb, _mapper, _passwordHasher, _jwtOptions);
    }

    public IProductAction ProductAction()
    {
        return new ProductActionExecution(_mapper, _productDb);
    }
    public IOrderAction OrderAction()
    {
        return new OrderActionExecution(_mapper, _orderDb, _promocodeDb);
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

    public IAllergenAction AllergenAction()
    {
        return new AllergenActionExecution(_mapper, _productDb);
    }

    public IIngridientAction IngridientAction()
    {
        return new IngridientActionExecution(_mapper, _ingridientDb);
    }

    public ICustomPizzaAction CustomPizzaAction()
    {
        return new CustomPizzaActionExecution(_mapper, _customPizzaDb);
    }

    public IReviewAction ReviewAction()
    {
        return new ReviewActionExecution(_mapper, _reviewDb);
    }

    public IArticleAction ArticleAction()
    {
        return new ArticleActionExecution(_mapper, _articleDb);
    }

    public ILocationAction LocationAction()
    {
        return new LocationActionExecution(_mapper, _locationDb);
    }
}
