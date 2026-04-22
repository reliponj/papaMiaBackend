namespace papaMiaBackend.Domain.Models.Product;
public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; } = 0;
    public string ImageUrl { get; set; } = string.Empty;
    public int Weight { get; set; } = 0;
    public string WeightType { get; set; } = string.Empty;
    public string Allergens { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

}
