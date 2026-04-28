using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.BusinessLogic.Structure;

public class RoleActionExecution : RoleActions, IRoleAction
{
    public RoleActionExecution(IMapper mapper, RoleContext db)
        : base(mapper, db)
    {
    }

    public List<RoleDto> GetAllRolesAction()
    {
        return GetAllRolesActionExecution();
    }
}
