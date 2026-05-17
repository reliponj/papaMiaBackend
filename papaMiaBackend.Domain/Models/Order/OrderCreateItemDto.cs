namespace papaMiaBackend.Domain.Models.Order;

public class OrderCreateItemDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
