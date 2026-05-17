using papaMiaBackend.Domain.Models.Order;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IOrderAction
{
    List<OrderDto> GetAllOrdersAction();
    OrderDto? GetOrderByIdAction(int id);
    OrderDto? CreateOrderAction(OrderCreateDto dto, int? userId);
    OrderDto? UpdateOrderAction(int id, OrderUpdateDto dto);
    bool DeleteOrderAction(int id);
}
