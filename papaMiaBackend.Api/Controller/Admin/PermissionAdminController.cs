using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.Api.Controller;

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
}
