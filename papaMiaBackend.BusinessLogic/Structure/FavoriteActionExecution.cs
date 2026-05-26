using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Product;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Structure;

public class FavoriteActionExecution : FavoriteActions, IFavoriteAction
{
    public FavoriteActionExecution(IMapper mapper, UserContext userDb, ProductContext productDb)
        : base(mapper, userDb, productDb)
    {
    }

    public List<ProductListDto> GetFavoriteProductsAction(int userId)
    {
        return GetFavoriteProductsActionExecution(userId);
    }

    public FavoriteToggleResultDto? ToggleFavoriteAction(int userId, int productId)
    {
        return ToggleFavoriteActionExecution(userId, productId);
    }
}
