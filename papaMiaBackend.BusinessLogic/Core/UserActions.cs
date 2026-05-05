using AutoMapper;
using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.Role;
using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Models.Role;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Core;

public class UserActions
{
    protected readonly IMapper Mapper;
    protected readonly UserContext Db;

    public UserActions(IMapper mapper, UserContext db)
    {
        Mapper = mapper;
        Db = db;
    }

    internal List<UserDto> GetAllUsersActionExecution()
    {
        var entities = Db.Users.ToList();
        return Mapper.Map<List<UserDto>>(entities);
    }

    internal UserDto? GetUserByIdActionExecution(int id)
    {
        var entity = Db.Users.FirstOrDefault(u => u.Id == id);
        if (entity == null)
        {
            return null;
        }

        return Mapper.Map<UserDto>(entity);
    }

    internal List<RoleListDto>? GetUserRolesActionExecution(int id)
    {
        var entity = Db.Users
            .Include(u => u.Roles)
            .FirstOrDefault(u => u.Id == id);
        if (entity is null)
            return null;

        return Mapper.Map<List<RoleListDto>>(entity.Roles.ToList());
    }

    internal List<RoleListDto>? SetUserRolesActionExecution(int userId, IEnumerable<int> roleIds)
    {
        var ids = roleIds.Distinct().ToList();

        var user = Db.Users
            .Include(u => u.Roles)
            .FirstOrDefault(u => u.Id == userId);
        if (user is null)
            return null;

        var roles = Db.Set<Role>()
            .Where(r => ids.Contains(r.Id))
            .ToList();

        user.Roles.Clear();
        foreach (var role in roles)
            user.Roles.Add(role);

        Db.SaveChanges();
        return Mapper.Map<List<RoleListDto>>(user.Roles.ToList());
    }

    internal UserDto CreateUserActionExecution(UserCreateDto userCreateDto)
    {
        var entity = Mapper.Map<User>(userCreateDto);
        Db.Users.Add(entity);
        Db.SaveChanges();
        return Mapper.Map<UserDto>(entity);
    }

    internal UserDto? UpdateUserActionExecution(int id, UserUpdateDto userUpdateDto)
    {
        var entity = Db.Users.FirstOrDefault(u => u.Id == id);
        if (entity == null)
        {
            return null;
        }

        entity.Username = userUpdateDto.Username;
        entity.Email = userUpdateDto.Email;
        Db.SaveChanges();
        return Mapper.Map<UserDto>(entity);
    }

    internal bool DeleteUserActionExecution(int id)
    {
        var entity = Db.Users.FirstOrDefault(u => u.Id == id);
        if (entity == null)
        {
            return false;
        }

        Db.Users.Remove(entity);
        Db.SaveChanges();
        return true;
    }
}
