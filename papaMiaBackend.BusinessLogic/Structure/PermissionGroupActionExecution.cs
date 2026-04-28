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
}
