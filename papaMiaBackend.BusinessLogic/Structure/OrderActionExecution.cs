using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Order;

namespace papaMiaBackend.BusinessLogic.Structure;

public class OrderActionExecution : OrderActions, IOrderAction
{
    public OrderActionExecution(IMapper mapper, OrderContext db, PromocodeContext promocodeDb)
        : base(mapper, db, promocodeDb)
    {
    }

    public List<OrderDto> GetAllOrdersAction()
    {
        return GetAllOrdersActionExecution();
    }

    public List<OrderDto> GetOrdersByUserAction(int userId)
    {
        return GetOrdersByUserActionExecution(userId);
    }

    public OrderDto? GetOrderByIdAction(int id)
    {
        return GetOrderByIdActionExecution(id);
    }

    public OrderDto? GetOrderForUserAction(int orderId, int userId)
    {
        return GetOrderForUserActionExecution(orderId, userId);
    }

    public OrderDto? CreateOrderAction(OrderCreateDto dto, int? userId)
    {
        return CreateOrderActionExecution(dto, userId);
    }

    public OrderDto? UpdateOrderAction(int id, OrderUpdateDto dto)
    {
        return UpdateOrderActionExecution(id, dto);
    }

    public bool DeleteOrderAction(int id)
    {
        return DeleteOrderActionExecution(id);
    }
}
