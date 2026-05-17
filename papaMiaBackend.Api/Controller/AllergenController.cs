using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

[Route("api/allergen")]
[ApiController]
public class AllergenController : ControllerBase
{
    private readonly IAllergenAction _allergen;

    public AllergenController(BusinessLogicManager bl)
    {
        _allergen = bl.AllergenAction();
    }

    [HttpGet]
    public IActionResult GetAllAllergens()
    {
        var items = _allergen.GetAllAllergensAction();
        return Ok(items);
    }
}
