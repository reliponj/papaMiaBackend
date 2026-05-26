using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Ingridient;

namespace papaMiaBackend.Api.Controller;

[AdminPermission("ingridients")]
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

    [HttpPost]
    public IActionResult CreateIngridient([FromBody] IngridientCreateDto dto)
    {
        var created = _ingridient.CreateIngridientAction(dto);
        return Ok(created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateIngridient(int id, [FromBody] IngridientUpdateDto dto)
    {
        var existing = _ingridient.GetIngridientByIdAction(id);
        if (existing is null)
            return NotFound(new { message = "ingridient_not_found" });

        var updated = _ingridient.UpdateIngridientAction(id, dto);
        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteIngridient(int id)
    {
        if (!_ingridient.DeleteIngridientAction(id))
            return NotFound(new { message = "ingridient_not_found" });

        return NoContent();
    }
}
