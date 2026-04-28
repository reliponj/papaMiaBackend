using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IRoleAction
{
    List<RoleListDto> GetAllRolesAction();
    RoleDto? GetRoleByIdAction(int id);
}
