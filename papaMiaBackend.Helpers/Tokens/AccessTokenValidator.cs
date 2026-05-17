using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using papaMiaBackend.Domain.Models.Auth;

namespace papaMiaBackend.Helpers.Tokens;

public static class AccessTokenValidator
{
    private static readonly JwtSecurityTokenHandler Handler = new() { MapInboundClaims = false };

    public static int? TryGetUserId(string accessToken, JwtGenerationSettings? settings)
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
            var principal = Handler.ValidateToken(accessToken, parameters, out _);
            var sub = principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            return int.TryParse(sub, out var id) ? id : null;
        }
        catch
        {
            return null;
        }
    }
}
