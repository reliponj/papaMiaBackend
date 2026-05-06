using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.Api.Controller;

[AdminMod]
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

    [HttpPost]
    public IActionResult CreateRole(RoleCreateDto roleCreateDto)
    {
        var role = _role.CreateRoleAction(roleCreateDto);
        if (role == null)
        {
            return BadRequest(new { message = "role_code_already_exists" });
        }

        return Ok(role);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRole(int id, RoleUpdateDto roleUpdateDto)
    {
        var existing = _role.GetRoleByIdAction(id);
        if (existing == null)
        {
            return NotFound(new { message = "role_not_found" });
        }

        var role = _role.UpdateRoleAction(id, roleUpdateDto);
        if (role == null)
        {
            return BadRequest(new { message = "role_code_already_exists" });
        }

        return Ok(role);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRole(int id)
    {
        var result = _role.DeleteRoleAction(id);
        if (!result)
        {
            return NotFound(new { message = "role_not_found" });
        }

        return NoContent();
    }
}
