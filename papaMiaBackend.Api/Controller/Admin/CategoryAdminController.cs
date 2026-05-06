using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Category;

namespace papaMiaBackend.Api.Controller;

[AdminMod]
[SwaggerBearer]
[Route("api/admin/category")]
[ApiController]
public class CategoryAdminController : ControllerBase
{
    internal ICategoryAction _category;

    public CategoryAdminController(BusinessLogicManager bl)
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

    [HttpPost]
    public IActionResult CreateCategory(CategoryCreateDto categoryCreateDto)
    {
        var category = _category.CreateCategoryAction(categoryCreateDto);
        return Ok(category);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto)
    {
        var category = _category.UpdateCategoryAction(id, categoryUpdateDto);
        if (category == null)
        {
            return NotFound(new { message = "category_not_found" });
        }
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var result = _category.DeleteCategoryAction(id);
        if (!result)
        {
            return NotFound(new { message = "category_not_found" });
        }
        return NoContent();
    }
}

