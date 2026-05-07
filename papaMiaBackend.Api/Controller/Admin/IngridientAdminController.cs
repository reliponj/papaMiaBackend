using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

[AdminMod]
[SwaggerBearer]
[Route("api/admin/ingridient")]
[ApiController]
public class IngridientAdminController : ControllerBase
{
    private readonly IIngridientAction _ingridient;

    public IngridientAdminController(BusinessLogicManager bl)
    {
        _ingridient = bl.IngridientAction();
    }

    [HttpGet]
    public IActionResult GetAllIngridients()
    {
        var items = _ingridient.GetAllIngridientsAction();
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetIngridientById(int id)
    {
        var item = _ingridient.GetIngridientByIdAction(id);
        if (item is null)
            return NotFound(new { message = "ingridient_not_found" });

        return Ok(item);
    }
}
