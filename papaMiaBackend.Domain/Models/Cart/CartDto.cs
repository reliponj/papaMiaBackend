namespace papaMiaBackend.Domain.Models.Cart;

public class CartDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<CartItemDto> Items { get; set; } = new();
}
