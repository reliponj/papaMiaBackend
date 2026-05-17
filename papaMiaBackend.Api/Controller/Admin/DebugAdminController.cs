using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Exceptions;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.Api.Controller;

[Route("api/admin/debug")]
[ApiController]
public class DebugAdminController : ControllerBase
{
    private readonly IUserAction _user;
    private readonly IRoleAction _role;
    private readonly IWebHostEnvironment _env;

    public DebugAdminController(BusinessLogicManager bl, IWebHostEnvironment env)
    {
        _user = bl.UserAction();
        _role = bl.RoleAction();
        _env = env;
    }

    [HttpGet("roles")]
    public IActionResult GetRoles()
    {
        return Ok(_role.GetAllRolesAction());
    }

    [HttpPut("user/{id:int}/roles")]
    public IActionResult SetUserRoles(int id, [FromBody] UserRolesSaveDto? dto)
    {
        try
        {
            var roles = _user.SetUserRolesAction(id, dto?.RoleIds ?? []);
            if (roles is null)
                return NotFound(new { message = "user_not_found" });

            return Ok(roles);
        }
        catch (UserBaseRoleRequiredException)
        {
            return BadRequest(new { message = "user_role_required" });
        }
    }

}
