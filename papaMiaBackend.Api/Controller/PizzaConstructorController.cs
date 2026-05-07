using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

[Route("api/pizza-constructor")]
[ApiController]
public class PizzaConstructorController : ControllerBase
{
    private readonly IIngridientAction _ingridient;

    public PizzaConstructorController(BusinessLogicManager bl)
    {
        _ingridient = bl.IngridientAction();
    }

    [HttpGet("ingridients")]
    public IActionResult GetAllIngridients()
    {
        var items = _ingridient.GetAllIngridientsAction();
        return Ok(items);
    }
}
