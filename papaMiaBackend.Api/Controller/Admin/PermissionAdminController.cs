using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.Api.Controller;

[AdminMod]
[SwaggerBearer]
[Route("api/admin/permission")]
[ApiController]
public class PermissionAdminController : ControllerBase
{
    internal IPermissionGroupAction _permissionGroup;

    public PermissionAdminController(BusinessLogicManager bl)
    {
        _permissionGroup = bl.PermissionGroupAction();
    }

    [HttpGet("group/{groupId}")]
    public IActionResult GetPermissionsByGroupId(int groupId)
    {
        var permissions = _permissionGroup.GetPermissionsByGroupIdAction(groupId);
        if (permissions == null)
        {
            return NotFound(new { message = "permission_group_not_found" });
        }

        return Ok(permissions);
    }

    [HttpPost("group/{groupId}")]
    public IActionResult AddPermissionToGroup(int groupId, PermissionCreateDto permissionCreateDto)
    {
        var permissions = _permissionGroup.GetPermissionsByGroupIdAction(groupId);
        if (permissions == null)
        {
            return NotFound(new { message = "permission_group_not_found" });
        }

        var permission = _permissionGroup.AddPermissionToGroupAction(groupId, permissionCreateDto);
        if (permission == null)
        {
            return BadRequest(new { message = "permission_code_already_exists" });
        }

        return Ok(permission);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePermission(int id, PermissionUpdateDto permissionUpdateDto)
    {
        var permission = _permissionGroup.UpdatePermissionAction(id, permissionUpdateDto);
        if (permission == null)
        {
            return NotFound(new { message = "permission_not_found" });
        }

        return Ok(permission);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePermission(int id)
    {
        var result = _permissionGroup.DeletePermissionAction(id);
        if (!result)
        {
            return NotFound(new { message = "permission_not_found" });
        }

        return NoContent();
    }
}
