using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
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

    [SwaggerBearer]
    [HttpGet]
    public IActionResult GetMyOrders()
    {
        if (!_currentUser.TryGetUserId(out var userId))
            return Unauthorized();

        var orders = _order.GetOrdersByUserAction(userId);
        return Ok(orders);
    }

    [SwaggerBearer]
    [HttpGet("{id:int}")]
    public IActionResult GetMyOrderById(int id)
    {
        if (!_currentUser.TryGetUserId(out var userId))
            return Unauthorized();

        var order = _order.GetOrderForUserAction(id, userId);
        if (order is null)
            return NotFound(new { message = "order_not_found" });

        return Ok(order);
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
