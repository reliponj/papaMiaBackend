using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Auth;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.Api.Controller;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthAction _auth;

    public AuthController(BusinessLogicManager bl)
    {
        _auth = bl.AuthAction();
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequestDto request)
    {
        var user = _auth.Register(request);
        return Ok(user);
    }
}
