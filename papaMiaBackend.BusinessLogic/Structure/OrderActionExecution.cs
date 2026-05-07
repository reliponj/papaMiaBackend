using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Order;

namespace papaMiaBackend.BusinessLogic.Structure;

public class OrderActionExecution : OrderActions, IOrderAction
{
    public OrderActionExecution(IMapper mapper, OrderContext db)
        : base(mapper, db)
    {
    }

    public List<OrderDto> GetAllOrdersAction()
    {
        return GetAllOrdersActionExecution();
    }

    public OrderDto? GetOrderByIdAction(int id)
    {
        return GetOrderByIdActionExecution(id);
    }

    public OrderDto? CreateOrderAction(OrderCreateDto dto, int? userId)
    {
        return CreateOrderActionExecution(dto, userId);
    }
}
