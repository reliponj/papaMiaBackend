using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

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
}
