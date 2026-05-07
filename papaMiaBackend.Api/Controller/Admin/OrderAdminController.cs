using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

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
}
