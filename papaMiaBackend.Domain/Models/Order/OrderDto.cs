using papaMiaBackend.Domain.Entities.Order;

namespace papaMiaBackend.Domain.Models.Order;

public class OrderDto
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public int? PromocodeId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? Note { get; set; }
    public OrderPaymentKind PaymentKind { get; set; }
    public OrderCardProvider? CardProvider { get; set; }
    public DateTime CreatedAt { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItemDto> Items { get; set; } = [];
}
