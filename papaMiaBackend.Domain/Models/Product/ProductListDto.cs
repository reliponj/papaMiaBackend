namespace papaMiaBackend.Domain.Models.Product;

public class ProductListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int Weight { get; set; }
    public string WeightType { get; set; } = string.Empty;
    public string Allergens { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public int CategoryId { get; set; }
}
