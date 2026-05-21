using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

[Route("api/location")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocationAction _location;

    public LocationController(BusinessLogicManager bl)
    {
        _location = bl.LocationAction();
    }

    [HttpGet]
    public IActionResult GetAllLocations()
    {
        var items = _location.GetAllLocationsAction();
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetLocationById(int id)
    {
        var item = _location.GetLocationByIdAction(id);
        if (item is null)
            return NotFound(new { message = "location_not_found" });

        return Ok(item);
    }
}
