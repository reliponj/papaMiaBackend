using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserAction _user;
    private readonly ICurrentUser _currentUser;

    public UserController(BusinessLogicManager bl, ICurrentUser currentUser)
    {
        _user = bl.UserAction();
        _currentUser = currentUser;
    }

    [SwaggerBearer]
    [HttpGet("me")]
    public IActionResult Me()
    {
        if (!_currentUser.TryGetUserId(out var id))
            return Unauthorized();

        var user = _user.GetUserByIdAction(id);
        if (user is null)
            return NotFound();

        return Ok(user);
    }
}
