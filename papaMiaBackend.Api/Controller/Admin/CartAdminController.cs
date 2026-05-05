using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

[Route("api/admin/cart")]
[ApiController]
public class CartAdminController : ControllerBase
{
    internal ICartAction _cart;

    public CartAdminController(BusinessLogicManager bl)
    {
        _cart = bl.CartAction();
    }

    [HttpGet]
    public IActionResult GetAllCarts()
    {
        var carts = _cart.GetAllCartsAction();
        return Ok(carts);
    }
}
