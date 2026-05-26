using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using papaMiaBackend.Domain.Models.Auth;

namespace papaMiaBackend.Helpers.Tokens;

public sealed class AccessRefreshTokenGenerator
{
    public AuthTokenPair CreatePair(JwtGenerationSettings settings, int userId, IEnumerable<string> permissions)
    {
        ArgumentNullException.ThrowIfNull(settings);
        if (string.IsNullOrWhiteSpace(settings.Secret) || settings.Secret.Length < 32)
            throw new ArgumentException(null, nameof(settings));

        var accessExpiresAt = DateTimeOffset.UtcNow.AddMinutes(settings.AccessTokenLifetimeMinutes);
        var refreshExpiresAt = DateTimeOffset.UtcNow.AddDays(settings.RefreshTokenLifetimeDays);

        var accessToken = CreateAccessToken(settings, userId, permissions, accessExpiresAt);
        var refreshToken = CreateRefreshTokenValue();

        return new AuthTokenPair(accessToken, refreshToken, accessExpiresAt, refreshExpiresAt);
    }

    private static string CreateAccessToken(
        JwtGenerationSettings settings,
        int userId,
        IEnumerable<string> permissions,
        DateTimeOffset accessExpiresAtUtc)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString())
        };

        foreach (var permission in permissions)
            claims.Add(new Claim("permission", permission));

        var token = new JwtSecurityToken(
            settings.Issuer,
            settings.Audience,
            claims,
            null,
            accessExpiresAtUtc.UtcDateTime,
            creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string CreateRefreshTokenValue()
    {
        var bytes = new byte[32];
        RandomNumberGenerator.Fill(bytes);
        return Base64UrlEncoder.Encode(bytes);
    }
}
