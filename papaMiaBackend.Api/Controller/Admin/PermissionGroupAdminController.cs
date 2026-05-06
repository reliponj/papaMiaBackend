using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.Api.Controller;

[AdminMod]
[Route("api/admin/permission-group")]
[ApiController]
public class PermissionGroupAdminController : ControllerBase
{
    internal IPermissionGroupAction _permissionGroup;

    public PermissionGroupAdminController(BusinessLogicManager bl)
    {
        _permissionGroup = bl.PermissionGroupAction();
    }

    [HttpGet("all")]
    public IActionResult GetAllPermissionGroups()
    {
        var groups = _permissionGroup.GetAllPermissionGroupsAction();
        return Ok(groups);
    }

    [HttpPost]
    public IActionResult CreatePermissionGroup(PermissionGroupCreateDto permissionGroupCreateDto)
    {
        var group = _permissionGroup.CreatePermissionGroupAction(permissionGroupCreateDto);
        if (group == null)
        {
            return BadRequest(new { message = "permission_group_code_already_exists" });
        }

        return Ok(group);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePermissionGroup(int id, PermissionGroupUpdateDto permissionGroupUpdateDto)
    {
        var group = _permissionGroup.UpdatePermissionGroupAction(id, permissionGroupUpdateDto);
        if (group == null)
        {
            return NotFound(new { message = "permission_group_not_found" });
        }

        return Ok(group);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePermissionGroup(int id)
    {
        var result = _permissionGroup.DeletePermissionGroupAction(id);
        if (!result)
        {
            return NotFound(new { message = "permission_group_not_found" });
        }

        return NoContent();
    }
}
