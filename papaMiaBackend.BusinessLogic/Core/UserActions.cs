using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.Role;
using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Exceptions;
using papaMiaBackend.Domain.Models.Role;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Core;

public class UserActions
{
    protected readonly IMapper Mapper;
    protected readonly UserContext Db;
    protected readonly IPasswordHasher<User> PasswordHasher;

    public UserActions(IMapper mapper, UserContext db, IPasswordHasher<User> passwordHasher)
    {
        Mapper = mapper;
        Db = db;
        PasswordHasher = passwordHasher;
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
        var baseUserRole = UserRoleDefaults.ResolveDefaultUserRole(Db);
        if (!ids.Contains(baseUserRole.Id))
            throw new UserBaseRoleRequiredException();

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
        entity.Roles.Add(UserRoleDefaults.ResolveDefaultUserRole(Db));
        Db.SaveChanges();
        return Mapper.Map<UserDto>(entity);
    }

    internal UserDto? UpdateUserActionExecution(int id, UserUpdateDto userUpdateDto)
    {
        var entity = Db.Users.FirstOrDefault(u => u.Id == id);
        if (entity is null)
            return null;

        var email = userUpdateDto.Email.Trim();
        if (Db.Users.Any(u => u.Id != id && u.Email.ToLower() == email.ToLower()))
            throw new InvalidOperationException("email_already_exists");


        entity.Username = userUpdateDto.Username;
        entity.Email = email;
        Db.SaveChanges();
        return Mapper.Map<UserDto>(entity);
    }

    internal ChangePasswordResult ChangePasswordActionExecution(int userId, ChangePasswordDto dto)
    {
        var entity = Db.Users.FirstOrDefault(u => u.Id == userId);
        if (entity is null)
            return ChangePasswordResult.UserNotFound;

        var verification = PasswordHasher.VerifyHashedPassword(entity, entity.Password, dto.CurrentPassword);
        if (verification == PasswordVerificationResult.Failed)
            return ChangePasswordResult.InvalidCurrentPassword;

        entity.Password = PasswordHasher.HashPassword(entity, dto.NewPassword);
        Db.SaveChanges();
        return ChangePasswordResult.Success;
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
