using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Category;

namespace papaMiaBackend.Api.Controller;

[Route("api/category")]
[ApiController]
public class CategoryController : ControllerBase
{
    internal ICategoryAction _category;

    public CategoryController(BusinessLogicManager bl)
    {
        _category = bl.CategoryAction();
    }

    [HttpGet]
    public IActionResult GetAllCategories()
    {
        var categories = _category.GetAllCategoriesAction();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoryById(int id)
    {
        var category = _category.GetCategoryByIdAction(id);
        if (category == null)
        {
            return NotFound(new { message = "category_not_found" });
        }
        return Ok(category);
    }


}

