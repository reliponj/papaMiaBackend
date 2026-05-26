using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Product;

namespace papaMiaBackend.Api.Controller;

[AdminPermission("products")]
[SwaggerBearer]
[Route("api/admin/product")]
[ApiController]
public class ProductAdminController : ControllerBase
{
    internal IProductAction _product;

    public ProductAdminController(BusinessLogicManager bl)
    {
        _product = bl.ProductAction();
    }

    [HttpGet]
    public IActionResult GetAllProducts([FromQuery] int? categoryId)
    {
        var products = _product.GetAllProductsAction(categoryId);
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetProductById(int id)
    {
        var product = _product.GetProductByIdAction(id);
        if (product == null)
        {
            return NotFound(new { message = "product_not_found" });
        }
        return Ok(product);
    }

    [HttpPost]
    public IActionResult CreateProduct(ProductCreateDto productCreateDto)
    {
        var product = _product.CreateProductAction(productCreateDto);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, ProductUpdateDto productUpdateDto)
    {
        var product = _product.UpdateProductAction(id, productUpdateDto);
        if (product == null)
        {
            return NotFound(new { message = "product_not_found" });
        }
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var result = _product.DeleteProductAction(id);
        if (!result)
        {
            return NotFound(new { message = "product_not_found" });
        }
        return NoContent();
    }
}
