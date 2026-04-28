using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.BusinessLogic.Structure;

public class PermissionGroupActionExecution : PermissionGroupActions, IPermissionGroupAction
{
    public PermissionGroupActionExecution(IMapper mapper, RoleContext db)
        : base(mapper, db)
    {
    }

    public List<PermissionGroupDto> GetAllPermissionGroupsAction()
    {
        return GetAllPermissionGroupsActionExecution();
    }

    public List<PermissionDto>? GetPermissionsByGroupIdAction(int id)
    {
        return GetPermissionsByGroupIdActionExecution(id);
    }

    public PermissionDto? AddPermissionToGroupAction(int id, PermissionCreateDto permissionCreateDto)
    {
        return AddPermissionToGroupActionExecution(id, permissionCreateDto);
    }

    public PermissionDto? UpdatePermissionAction(int id, PermissionUpdateDto permissionUpdateDto)
    {
        return UpdatePermissionActionExecution(id, permissionUpdateDto);
    }

    public bool DeletePermissionAction(int id)
    {
        return DeletePermissionActionExecution(id);
    }

    public PermissionGroupDto? CreatePermissionGroupAction(PermissionGroupCreateDto permissionGroupCreateDto)
    {
        return CreatePermissionGroupActionExecution(permissionGroupCreateDto);
    }

    public PermissionGroupDto? UpdatePermissionGroupAction(int id, PermissionGroupUpdateDto permissionGroupUpdateDto)
    {
        return UpdatePermissionGroupActionExecution(id, permissionGroupUpdateDto);
    }

    public bool DeletePermissionGroupAction(int id)
    {
        return DeletePermissionGroupActionExecution(id);
    }
}
