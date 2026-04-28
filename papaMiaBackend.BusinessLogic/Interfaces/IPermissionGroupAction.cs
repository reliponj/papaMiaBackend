using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IPermissionGroupAction
{
    List<PermissionGroupDto> GetAllPermissionGroupsAction();
}
