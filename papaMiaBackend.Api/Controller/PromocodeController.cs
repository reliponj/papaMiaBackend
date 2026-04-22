using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Promocode;

namespace papaMiaBackend.Api.Controller;

[Route("api/promocode")]
[ApiController]
public class PromocodeController : ControllerBase
{
    internal IPromocodeAction _promocode;
    public PromocodeController(BusinessLogicManager bl)
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