using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.User;

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

    [SwaggerBearer]
    [HttpPut("me")]
    public IActionResult UpdateMe([FromBody] UserUpdateDto dto)
    {
        if (!_currentUser.TryGetUserId(out var id))
            return Unauthorized();

        var user = _user.UpdateUserAction(id, dto);
        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [SwaggerBearer]
    [HttpPut("me/password")]
    public IActionResult ChangeMyPassword([FromBody] ChangePasswordDto dto)
    {
        if (!_currentUser.TryGetUserId(out var id))
            return Unauthorized();

        return _user.ChangePasswordAction(id, dto) switch
        {
            ChangePasswordResult.Success => NoContent(),
            ChangePasswordResult.UserNotFound => NotFound(),
            ChangePasswordResult.InvalidCurrentPassword => BadRequest(new { message = "invalid_current_password" })
        };
    }
}
