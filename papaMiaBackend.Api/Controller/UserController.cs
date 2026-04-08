using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic.Interfaces;

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
}
