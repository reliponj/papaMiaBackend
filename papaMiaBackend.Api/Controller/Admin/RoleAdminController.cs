using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

[Route("api/admin/role")]
[ApiController]
public class RoleAdminController : ControllerBase
{
    internal IRoleAction _role;

    public RoleAdminController(BusinessLogicManager bl)
    {
        _role = bl.RoleAction();
    }

    [HttpGet]
    public IActionResult GetAllRoles()
    {
        var roles = _role.GetAllRolesAction();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public IActionResult GetRoleById(int id)
    {
        var role = _role.GetRoleByIdAction(id);
        if (role == null)
        {
            return NotFound(new { message = "role_not_found" });
        }

        return Ok(role);
    }
}
