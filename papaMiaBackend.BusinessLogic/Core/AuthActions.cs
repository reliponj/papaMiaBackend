using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Models.Auth;
using papaMiaBackend.Domain.Models.User;
using papaMiaBackend.Helpers.Tokens;

namespace papaMiaBackend.BusinessLogic.Core;

public class AuthActions
{
    private static readonly AccessRefreshTokenGenerator TokenGenerator = new();

    protected readonly UserContext Db;
    protected readonly IMapper Mapper;
    protected readonly IPasswordHasher<User> PasswordHasher;
    protected readonly JwtGenerationSettings JwtSettings;

    public AuthActions(
        UserContext db,
        IMapper mapper,
        IPasswordHasher<User> passwordHasher,
        IOptions<JwtGenerationSettings> jwtOptions)
    {
        Db = db;
        Mapper = mapper;
        PasswordHasher = passwordHasher;
        JwtSettings = jwtOptions.Value;
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

    internal AuthTokenPair? RefreshTokensExecution(string refreshToken)
    {
        if (!refreshToken)
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
        var pair = TokenGenerator.CreatePair(JwtSettings, userId);
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
