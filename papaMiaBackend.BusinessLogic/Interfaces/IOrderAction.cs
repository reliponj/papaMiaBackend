using papaMiaBackend.Domain.Models.Order;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IOrderAction
{
    OrderDto? CreateOrderAction(OrderCreateDto dto, int? userId);
}
