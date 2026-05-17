using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Order;

namespace papaMiaBackend.Api.Controller;

[Route("api/order")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderAction _order;
    private readonly ICurrentUser _currentUser;

    public OrderController(BusinessLogicManager bl, ICurrentUser currentUser)
    {
        _order = bl.OrderAction();
        _currentUser = currentUser;
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] OrderCreateDto dto)
    {
        var userId = _currentUser.UserId;
        var order = _order.CreateOrderAction(dto, userId);
        if (order is null)
            return BadRequest(new { message = "invalid_order_items" });

        return Ok(order);
    }
}
