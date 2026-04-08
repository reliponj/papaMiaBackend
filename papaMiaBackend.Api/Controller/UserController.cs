using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.Api.Controller;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    internal IUserAction _user;

    public UserController()
    {
        var bl = new papaMiaBackend.BusinessLogic.BusinessLogic();
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
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _user.DeleteUserAction(id);
        return NoContent();
    }
}
