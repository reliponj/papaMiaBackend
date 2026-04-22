using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

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

}