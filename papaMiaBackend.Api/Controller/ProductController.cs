using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ICategoryAction _category;
    private readonly IProductAction _product;

    public ProductController(BusinessLogicManager bl)
    {
        _category = bl.CategoryAction();
        _product = bl.ProductAction();
    }

    [HttpGet("categories")]
    public IActionResult GetAllCategories()
    {
        var categories = _category.GetAllCategoriesAction();
        return Ok(categories);
    }

    [HttpGet("category/{categoryId:int}")]
    public IActionResult GetProductsByCategory(int categoryId)
    {
        if (_category.GetCategoryByIdAction(categoryId) is null)
            return NotFound(new { message = "category_not_found" });

        var products = _product.GetAllProductsAction(categoryId);
        return Ok(products);
    }
}
