using Microsoft.AspNetCore.Mvc;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Controller;

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
}
