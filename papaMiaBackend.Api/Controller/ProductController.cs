using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    internal IProductAction _product;

    public ProductController(BusinessLogicManager bl)
    {
        _product = bl.ProductAction();
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = _product.GetAllProductsAction();
        return Ok(products);
    }

    [HttpGet]
    public IActionResult GetProductById(int id)
    {
        var product = _product.GetProductByIdAction(id);
        if (product == null)
        {
            return NotFound(new { message = "product_not_found" });
        }
        return Ok(product);
    }


}

