using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Models.Auth;
using papaMiaBackend.Domain.Models.User;
using papaMiaBackend.BusinessLogic.Structure;

namespace papaMiaBackend.BusinessLogic.Core;

public class AuthActions
{
    private static readonly AccessRefreshTokenGenerator TokenGenerator = new();

    protected readonly UserContext Db;
    protected readonly IMapper Mapper;
    protected readonly IPasswordHasher<User> PasswordHasher;
    protected readonly RoleContext RoleDb;
    protected readonly JwtGenerationSettings JwtSettings;

    public AuthActions(
        UserContext db,
        RoleContext roleDb,
        IMapper mapper,
        IPasswordHasher<User> passwordHasher,
        IOptions<JwtGenerationSettings> jwtOptions)
    {
        Db = db;
        RoleDb = roleDb;
        Mapper = mapper;
        PasswordHasher = passwordHasher;
        JwtSettings = jwtOptions.Value;
    }

    internal AuthTokenPair RegisterActionExecution(RegisterRequestDto request)
    {
        var entity = new User
        {
            Username = request.Username,
            Email = request.Email,
            LastLogin = DateTime.UtcNow,
            LastIp = string.Empty
        };

        entity.Password = PasswordHasher.HashPassword(entity, request.Password);

        Db.Users.Add(entity);
        entity.Roles.Add(UserRoleDefaults.ResolveDefaultUserRole(Db));
        Db.SaveChanges();

        return CreateAndPersistTokenPair(entity.Id);
    }

    internal AuthTokenPair? LoginActionExecution(LoginRequestDto request, string clientIp)
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

        return CreateAndPersistTokenPair(user.Id);
    }

    internal AuthTokenPair? RefreshTokensExecution(string refreshToken)
    {
        if (string.IsNullOrWhiteSpace(refreshToken))
            return null;

        var hash = RefreshTokenHasher.Hash(refreshToken);
        var now = DateTime.UtcNow;
        var row = Db.RefreshTokens.FirstOrDefault(x =>
            x.TokenHash == hash && x.RevokedAtUtc == null && x.ExpiresAtUtc > now);

        if (row is null)
            return null;

        row.RevokedAtUtc = now;
        Db.SaveChanges();

        return CreateAndPersistTokenPair(row.UserId);
    }

    private AuthTokenPair CreateAndPersistTokenPair(int userId)
    {
        var permissionCodes = UserPermissions.GetCodes(Db, RoleDb, userId);
        var pair = TokenGenerator.CreatePair(JwtSettings, userId, permissionCodes);
        var hash = RefreshTokenHasher.Hash(pair.RefreshToken);
        Db.RefreshTokens.Add(new RefreshToken
        {
            UserId = userId,
            TokenHash = hash,
            ExpiresAtUtc = pair.RefreshTokenExpiresAtUtc.UtcDateTime,
            CreatedAtUtc = DateTime.UtcNow
        });
        Db.SaveChanges();
        return pair;
    }
}
