using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Location;

namespace papaMiaBackend.Api.Controller;

[AdminMod]
[SwaggerBearer]
[Route("api/admin/location")]
[ApiController]
public class LocationAdminController : ControllerBase
{
    private readonly ILocationAction _location;

    public LocationAdminController(BusinessLogicManager bl)
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

    [HttpPost]
    public IActionResult CreateLocation([FromBody] LocationCreateDto dto)
    {
        var created = _location.CreateLocationAction(dto);
        if (created is null)
            return BadRequest(new { message = "invalid_location" });

        return Ok(created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateLocation(int id, [FromBody] LocationUpdateDto dto)
    {
        if (_location.GetLocationByIdAction(id) is null)
            return NotFound(new { message = "location_not_found" });

        var updated = _location.UpdateLocationAction(id, dto);
        if (updated is null)
            return BadRequest(new { message = "invalid_location" });

        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteLocation(int id)
    {
        if (!_location.DeleteLocationAction(id))
            return NotFound(new { message = "location_not_found" });

        return NoContent();
    }
}
