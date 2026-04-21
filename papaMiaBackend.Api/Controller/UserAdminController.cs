using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.Api.Controller;

[Route("api/admin/user")]
[ApiController]
public class UserAdminController : ControllerBase
{
    internal IUserAction _user;

    private IActionResult UserNotFound() => NotFound(new { message = "user_not_found" });

    public UserAdminController(BusinessLogicManager bl)
    {
        _user = bl.UserAction();
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _user.GetAllUsersAction();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _user.GetUserByIdAction(id);
        if (user is null)
        {
            return UserNotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser(UserCreateDto userCreateDto)
    {
        var user = _user.CreateUserAction(userCreateDto);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, UserUpdateDto userUpdateDto)
    {
        var user = _user.UpdateUserAction(id, userUpdateDto);
        if (user is null)
        {
            return UserNotFound();
        }

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var result = _user.DeleteUserAction(id);
        if (!result)
        {
            return UserNotFound();
        }

        return NoContent();
    }
}
