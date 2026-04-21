using AutoMapper;
using Microsoft.AspNetCore.Identity;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Models.Auth;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Core;

public class AuthActions
{
    protected readonly UserContext Db;
    protected readonly IMapper Mapper;
    protected readonly IPasswordHasher<User> PasswordHasher;

    public AuthActions(UserContext db, IMapper mapper, IPasswordHasher<User> passwordHasher)
    {
        Db = db;
        Mapper = mapper;
        PasswordHasher = passwordHasher;
    }

    internal UserDto RegisterActionExecution(RegisterRequestDto request)
    {
        var entity = new User
        {
            Username = request.Username,
            Email = request.Email,
            LastLogin = DateTime.UtcNow,
            LastIp = string.Empty,
            Level = URole.User
        };

        entity.Password = PasswordHasher.HashPassword(entity, request.Password);

        Db.Users.Add(entity);
        Db.SaveChanges();

        return Mapper.Map<UserDto>(entity);
    }

    internal UserDto? LoginActionExecution(LoginRequestDto request, string clientIp)
    {
        var user = Db.Users.FirstOrDefault(u => u.Email == request.Email);
        if (user is null)
            return null;

        var verification = PasswordHasher.VerifyHashedPassword(user, user.Password, request.Password);
        if (verification == PasswordVerificationResult.Failed)
            return null;

        user.LastLogin = DateTime.UtcNow;
        user.LastIp = clientIp;
        Db.SaveChanges();

        return Mapper.Map<UserDto>(user);
    }
}
