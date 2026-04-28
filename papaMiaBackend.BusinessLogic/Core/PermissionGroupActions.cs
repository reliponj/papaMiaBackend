using AutoMapper;
using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.BusinessLogic.Core;

public class PermissionGroupActions
{
    protected readonly IMapper Mapper;
    protected readonly RoleContext Db;

    public PermissionGroupActions(IMapper mapper, RoleContext db)
    {
        Mapper = mapper;
        Db = db;
    }

    internal List<PermissionGroupDto> GetAllPermissionGroupsActionExecution()
    {
        var entities = Db.PermissionGroups
            .Include(g => g.Permissions)
            .ToList();
        return Mapper.Map<List<PermissionGroupDto>>(entities);
    }
}
