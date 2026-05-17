using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Promocode;

namespace papaMiaBackend.Api.Controller;

[AdminMod]
[SwaggerBearer]
[Route("api/admin/promocode")]
[ApiController]
public class PromocodeAdminController : ControllerBase
{
    internal IPromocodeAction _promocode;
    public PromocodeAdminController(BusinessLogicManager bl)
    {
        _promocode = bl.PromocodeAction();
    }

    [HttpGet]
    public IActionResult GetAllPromocodes()
    {
        var promocodes = _promocode.GetAllPromocodesAction();
        return Ok(promocodes);
    }
    [HttpGet("{id}")]
    public IActionResult GetPromocodeById(int id)
    {
        var promocode = _promocode.GetPromocodeByIdAction(id);
        if (promocode == null)
        {
            return NotFound(new { message = "promocode_not_found" });
        }
        return Ok(promocode);
    }
    [HttpPost]
    public IActionResult CreatePromocode(PromocodeCreateDto promocodeCreateDto)
    {
        var promocode = _promocode.CreatePromocodeAction(promocodeCreateDto);
        return Ok(promocode);
    }
    [HttpPut("{id}")]
    public IActionResult UpdatePromocode(int id, PromocodeUpdateDto promocodeUpdateDto)
    {
        var promocode = _promocode.UpdatePromocodeAction(id, promocodeUpdateDto);
        if (promocode == null)
        {
            return NotFound(new { message = "promocode_not_found" });
        }
        return Ok(promocode);
    }
    [HttpDelete("{id}")]
    public IActionResult DeletePromocode(int id)
    {
        var result = _promocode.DeletePromocodeAction(id);
        if (!result)
        {
            return NotFound(new { message = "promocode_not_found" });
        }
        return NoContent();
    }
}