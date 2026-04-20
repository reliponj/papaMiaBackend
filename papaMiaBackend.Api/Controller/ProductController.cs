using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Product;

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

    [HttpGet("{id}")]
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
