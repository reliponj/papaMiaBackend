using papaMiaBackend.Domain.Models.Product;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IFavoriteAction
{
    List<ProductListDto> GetFavoriteProductsAction(int userId);
    FavoriteToggleResultDto? ToggleFavoriteAction(int userId, int productId);
}
