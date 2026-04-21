using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

[Route("api/cart")]
[ApiController]
public class CartController : ControllerBase
{
    internal ICartAction _cart;

    public CartController(BusinessLogicManager bl)
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
