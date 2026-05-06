using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Product;

namespace papaMiaBackend.Api.Controller;

[AdminMod]
[SwaggerBearer]
[Route("api/admin/allergen")]
[ApiController]
public class AllergenAdminController : ControllerBase
{
    internal IAllergenAction _allergen;

    public AllergenAdminController(BusinessLogicManager bl)
    {
        _allergen = bl.AllergenAction();
    }

    [HttpGet]
    public IActionResult GetAllAllergens()
    {
        var items = _allergen.GetAllAllergensAction();
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAllergenById(int id)
    {
        var item = _allergen.GetAllergenByIdAction(id);
        if (item is null)
            return NotFound(new { message = "allergen_not_found" });

        return Ok(item);
    }

    [HttpPost]
    public IActionResult CreateAllergen([FromBody] AllergenCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            return BadRequest(new { message = "allergen_name_required" });

        var created = _allergen.CreateAllergenAction(dto);
        return Ok(created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAllergen(int id, [FromBody] AllergenUpdateDto dto)
    {
        var existing = _allergen.GetAllergenByIdAction(id);
        if (existing is null)
            return NotFound(new { message = "allergen_not_found" });

        var updated = _allergen.UpdateAllergenAction(id, dto);
        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAllergen(int id)
    {
        if (!_allergen.DeleteAllergenAction(id))
            return NotFound(new { message = "allergen_not_found" });

        return NoContent();
    }
}
