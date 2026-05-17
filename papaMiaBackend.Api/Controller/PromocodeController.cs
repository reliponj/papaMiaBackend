using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Promocode;

namespace papaMiaBackend.Api.Controller;

[Route("api/promocode")]
[ApiController]
public class PromocodeController : ControllerBase
{
    private readonly IPromocodeAction _promocode;
    private readonly ICurrentUser _currentUser;

    public PromocodeController(BusinessLogicManager bl, ICurrentUser currentUser)
    {
        _promocode = bl.PromocodeAction();
        _currentUser = currentUser;
    }

    [SwaggerBearer]
    [HttpPost("validate")]
    public IActionResult Validate([FromBody] PromocodeValidateRequestDto dto)
    {
        if (!_currentUser.TryGetUserId(out var userId))
            return Unauthorized();

        var code = dto?.Code ?? string.Empty;
        var result = _promocode.ValidatePromocodeForUserAction(code, userId);

        return result.Status switch
        {
            PromocodeValidationStatus.Ok => Ok(result.Promocode),
            PromocodeValidationStatus.NotFound => NotFound(new { message = "promocode_not_found" }),
            PromocodeValidationStatus.Inactive => BadRequest(new { message = "promocode_inactive" }),
            PromocodeValidationStatus.Expired => BadRequest(new { message = "promocode_expired" }),
            PromocodeValidationStatus.AlreadyUsedByUser => Conflict(new { message = "promocode_already_used" }),
            _ => BadRequest()
        };
    }
}
