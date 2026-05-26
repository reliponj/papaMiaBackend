using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using papaMiaBackend.Domain.Models.Auth;

namespace papaMiaBackend.Helpers.Tokens;

public static class AccessTokenValidator
{
    private static readonly JwtSecurityTokenHandler Handler = new() { MapInboundClaims = false };

    public static int? TryGetUserId(string accessToken, JwtGenerationSettings? settings) =>
        TryGetPrincipal(accessToken, settings) is { } principal
            && int.TryParse(principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value, out var id)
            ? id
            : null;

    public static HashSet<string>? TryGetPermissions(string accessToken, JwtGenerationSettings? settings)
    {
        var principal = TryGetPrincipal(accessToken, settings);
        if (principal is null)
            return null;

        return principal.FindAll("permission")
            .Select(c => c.Value)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
    }

    private static ClaimsPrincipal? TryGetPrincipal(string accessToken, JwtGenerationSettings? settings)
    {
        if (string.IsNullOrWhiteSpace(accessToken)
            || settings?.Secret is not { Length: >= 32 } secret)
            return null;

        var parameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
            ValidateIssuer = true,
            ValidIssuer = settings.Issuer,
            ValidateAudience = true,
            ValidAudience = settings.Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(1)
        };

        try
        {
            return Handler.ValidateToken(accessToken, parameters, out _);
        }
        catch
        {
            return null;
        }
    }
}
