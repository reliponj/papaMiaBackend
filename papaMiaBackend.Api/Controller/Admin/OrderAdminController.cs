using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Order;

namespace papaMiaBackend.Api.Controller;

[AdminMod]
[SwaggerBearer]
[Route("api/admin/order")]
[ApiController]
public class OrderAdminController : ControllerBase
{
    internal IOrderAction _order;

    public OrderAdminController(BusinessLogicManager bl)
    {
        _order = bl.OrderAction();
    }

    [HttpGet]
    public IActionResult GetAllOrders()
    {
        var items = _order.GetAllOrdersAction();
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOrderById(int id)
    {
        var item = _order.GetOrderByIdAction(id);
        if (item is null)
            return NotFound(new { message = "order_not_found" });

        return Ok(item);
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] OrderCreateDto dto)
    {
        var created = _order.CreateOrderAction(dto, null);
        if (created is null)
            return BadRequest(new { message = "invalid_order_data" });

        return Ok(created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateOrder(int id, [FromBody] OrderUpdateDto dto)
    {
        var existing = _order.GetOrderByIdAction(id);
        if (existing is null)
            return NotFound(new { message = "order_not_found" });

        var updated = _order.UpdateOrderAction(id, dto);
        if (updated is null)
            return BadRequest(new { message = "invalid_order_data" });

        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteOrder(int id)
    {
        if (!_order.DeleteOrderAction(id))
            return NotFound(new { message = "order_not_found" });

        return NoContent();
    }
}
