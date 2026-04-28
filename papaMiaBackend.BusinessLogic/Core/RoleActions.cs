using AutoMapper;
using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.BusinessLogic.Core;

public class RoleActions
{
    protected readonly IMapper Mapper;
    protected readonly RoleContext Db;

    public RoleActions(IMapper mapper, RoleContext db)
    {
        Mapper = mapper;
        Db = db;
    }

    internal List<RoleListDto> GetAllRolesActionExecution()
    {
        var entities = Db.Roles.ToList();
        return Mapper.Map<List<RoleListDto>>(entities);
    }

    internal RoleDto? GetRoleByIdActionExecution(int id)
    {
        var entity = Db.Roles
            .Include(r => r.Permissions)
            .FirstOrDefault(r => r.Id == id);
        if (entity == null)
        {
            return null;
        }

        return Mapper.Map<RoleDto>(entity);
    }
}
