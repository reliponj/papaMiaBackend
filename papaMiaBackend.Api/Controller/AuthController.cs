using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Auth;
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

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto request)
    {
        var clientIp = HttpContext.Connection.RemoteIpAddress?.ToString();
        var user = _auth.Login(request, clientIp);
        if (user is null)
            return Unauthorized();

        return Ok(user);
    }
}
