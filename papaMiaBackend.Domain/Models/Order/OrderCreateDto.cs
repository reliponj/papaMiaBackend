using papaMiaBackend.Domain.Entities.Order;

namespace papaMiaBackend.Domain.Models.Order;

public class OrderCreateDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? Note { get; set; }
    public int? PromocodeId { get; set; }
    public OrderPaymentKind PaymentKind { get; set; }
    public OrderCardProvider? CardProvider { get; set; }
    public List<OrderCreateItemDto> Items { get; set; } = [];
}
