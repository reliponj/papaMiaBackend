using AutoMapper;
using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Models.Product;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Core;

public class FavoriteActions
{
    protected readonly IMapper Mapper;
    protected readonly UserContext UserDb;
    protected readonly ProductContext ProductDb;

    public FavoriteActions(IMapper mapper, UserContext userDb, ProductContext productDb)
    {
        Mapper = mapper;
        UserDb = userDb;
        ProductDb = productDb;
    }

    internal List<ProductListDto> GetFavoriteProductsActionExecution(int userId)
    {
        var productIds = UserDb.UserFavorites
            .Where(f => f.UserId == userId)
            .OrderByDescending(f => f.CreatedAt)
            .Select(f => f.ProductId)
            .ToList();

        if (productIds.Count == 0)
            return [];

        var products = ProductDb.Products
            .Where(p => productIds.Contains(p.Id) && p.IsActive)
            .ToList();

        var byId = products.ToDictionary(p => p.Id);
        return productIds
            .Where(byId.ContainsKey)
            .Select(id => Mapper.Map<ProductListDto>(byId[id]))
            .ToList();
    }

    internal FavoriteToggleResultDto? ToggleFavoriteActionExecution(int userId, int productId)
    {
        if (productId <= 0)
            return null;

        if (!ProductDb.Products.Any(p => p.Id == productId && p.IsActive))
            return null;

        var favorite = UserDb.UserFavorites
            .FirstOrDefault(f => f.UserId == userId && f.ProductId == productId);

        if (favorite is null)
        {
            UserDb.UserFavorites.Add(new UserFavorite
            {
                UserId = userId,
                ProductId = productId,
                CreatedAt = DateTime.UtcNow
            });
            UserDb.SaveChanges();
            return new FavoriteToggleResultDto { IsFavorite = true };
        }

        UserDb.UserFavorites.Remove(favorite);
        UserDb.SaveChanges();
        return new FavoriteToggleResultDto { IsFavorite = false };
    }
}
