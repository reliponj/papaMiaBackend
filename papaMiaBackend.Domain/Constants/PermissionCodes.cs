namespace papaMiaBackend.Domain.Constants;

public static class PermissionCodes
{
    public static readonly string[] Moderator =
    [
        "products.view", "products.update",
        "categories.view", "categories.update",
        "allergens.view",
        "orders.view", "orders.update",
        "articles.view", "articles.update",
        "banners.view", "banners.update",
        "promocodes.view",
        "locations.view",
        "ingridients.view", "ingridients.update",
        "reviews.view", "reviews.update"
    ];
}
