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
        var tokens = _auth.Register(request);
        return Ok(tokens);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto request)
    {
        var clientIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
        var tokens = _auth.Login(request, clientIp);
        if (tokens is null)
            return Unauthorized();

        return Ok(tokens);
    }

    [HttpPost("refresh")]
    public IActionResult Refresh([FromBody] RefreshRequestDto request)
    {
        var tokens = _auth.RefreshTokens(request.RefreshToken);
        if (tokens is null)
            return Unauthorized();

        return Ok(tokens);
    }
}
