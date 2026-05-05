using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IPermissionGroupAction
{
    List<PermissionGroupDto> GetAllPermissionGroupsAction();
    List<PermissionDto>? GetPermissionsByGroupIdAction(int id);
    PermissionDto? AddPermissionToGroupAction(int id, PermissionCreateDto permissionCreateDto);
    PermissionDto? UpdatePermissionAction(int id, PermissionUpdateDto permissionUpdateDto);
    bool DeletePermissionAction(int id);
    PermissionGroupDto? CreatePermissionGroupAction(PermissionGroupCreateDto permissionGroupCreateDto);
    PermissionGroupDto? UpdatePermissionGroupAction(int id, PermissionGroupUpdateDto permissionGroupUpdateDto);
    bool DeletePermissionGroupAction(int id);
}
