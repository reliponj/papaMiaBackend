using AutoMapper;
using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.Role;
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

    internal RoleDto? CreateRoleActionExecution(RoleCreateDto roleCreateDto)
    {
        var codeExists = Db.Roles.Any(r => r.Code == roleCreateDto.Code);
        if (codeExists)
        {
            return null;
        }

        var entity = Mapper.Map<Role>(roleCreateDto);
        var permissions = Db.Permissions
            .Where(p => roleCreateDto.PermissionIds.Contains(p.Id))
            .ToList();
        entity.Permissions = permissions;

        Db.Roles.Add(entity);
        Db.SaveChanges();

        var created = Db.Roles
            .Include(r => r.Permissions)
            .First(r => r.Id == entity.Id);
        return Mapper.Map<RoleDto>(created);
    }

    internal RoleDto? UpdateRoleActionExecution(int id, RoleUpdateDto roleUpdateDto)
    {
        var entity = Db.Roles
            .Include(r => r.Permissions)
            .FirstOrDefault(r => r.Id == id);
        if (entity == null)
        {
            return null;
        }

        var codeExists = Db.Roles.Any(r => r.Code == roleUpdateDto.Code && r.Id != id);
        if (codeExists)
        {
            return null;
        }

        Mapper.Map(roleUpdateDto, entity);
        var permissions = Db.Permissions
            .Where(p => roleUpdateDto.PermissionIds.Contains(p.Id))
            .ToList();
        entity.Permissions = permissions;

        Db.SaveChanges();

        var updated = Db.Roles
            .Include(r => r.Permissions)
            .First(r => r.Id == id);
        return Mapper.Map<RoleDto>(updated);
    }

    internal bool DeleteRoleActionExecution(int id)
    {
        var entity = Db.Roles.FirstOrDefault(r => r.Id == id);
        if (entity == null)
        {
            return false;
        }

        Db.Roles.Remove(entity);
        Db.SaveChanges();
        return true;
    }
}
