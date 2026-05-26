using papaMiaBackend.Domain.Models.Order;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IOrderAction
{
    List<OrderDto> GetAllOrdersAction();
    List<OrderDto> GetOrdersByUserAction(int userId);
    OrderDto? GetOrderByIdAction(int id);
    OrderDto? GetOrderForUserAction(int orderId, int userId);
    OrderDto? CreateOrderAction(OrderCreateDto dto, int? userId);
    OrderDto? UpdateOrderAction(int id, OrderUpdateDto dto);
    bool DeleteOrderAction(int id);
}
