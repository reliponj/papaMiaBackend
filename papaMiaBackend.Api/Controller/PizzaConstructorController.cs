using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.CustomPizza;

namespace papaMiaBackend.Api.Controller;

[Route("api/pizza-constructor")]
[ApiController]
public class PizzaConstructorController : ControllerBase
{
    private readonly IIngridientAction _ingridient;
    private readonly ICustomPizzaAction _customPizza;

    public PizzaConstructorController(BusinessLogicManager bl)
    {
        _ingridient = bl.IngridientAction();
        _customPizza = bl.CustomPizzaAction();
    }

    [HttpGet("ingridients")]
    public IActionResult GetAllIngridients()
    {
        var items = _ingridient.GetActiveIngridientsAction();
        return Ok(items);
    }

    [HttpPost("custom-pizza")]
    public IActionResult CreateCustomPizza([FromBody] CustomPizzaCreateDto dto)
    {
        var customPizza = _customPizza.CreateCustomPizzaAction(dto);
        if (customPizza is null)
            return BadRequest(new { message = "invalid_ingridients" });

        return Ok(customPizza);
    }

    [HttpGet("custom-pizza/{id:int}")]
    public IActionResult GetCustomPizzaById(int id)
    {
        var customPizza = _customPizza.GetCustomPizzaByIdAction(id);
        if (customPizza is null)
            return NotFound(new { message = "custom_pizza_not_found" });

        return Ok(customPizza);
    }
}
