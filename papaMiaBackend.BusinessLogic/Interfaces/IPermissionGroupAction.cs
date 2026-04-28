using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IPermissionGroupAction
{
    List<PermissionGroupDto> GetAllPermissionGroupsAction();
    List<PermissionDto>? GetPermissionsByGroupIdAction(int id);
    PermissionDto? AddPermissionToGroupAction(int id, PermissionCreateDto permissionCreateDto);
    PermissionGroupDto? CreatePermissionGroupAction(PermissionGroupCreateDto permissionGroupCreateDto);
    bool DeletePermissionGroupAction(int id);
}
