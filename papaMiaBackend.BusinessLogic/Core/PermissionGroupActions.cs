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

    internal PermissionGroupDto? CreatePermissionGroupActionExecution(PermissionGroupCreateDto permissionGroupCreateDto)
    {
        var exists = Db.PermissionGroups.Any(g => g.Code == permissionGroupCreateDto.Code);
        if (exists)
        {
            return null;
        }

        var entity = Mapper.Map<Domain.Entities.Role.PermissionGroup>(permissionGroupCreateDto);

        Db.PermissionGroups.Add(entity);
        Db.SaveChanges();
        return Mapper.Map<PermissionGroupDto>(entity);
    }

    internal bool DeletePermissionGroupActionExecution(int id)
    {
        var entity = Db.PermissionGroups.FirstOrDefault(g => g.Id == id);
        if (entity == null)
        {
            return false;
        }

        Db.PermissionGroups.Remove(entity);
        Db.SaveChanges();
        return true;
    }
}
