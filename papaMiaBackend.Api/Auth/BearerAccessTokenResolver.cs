using System.Diagnostics.CodeAnalysis;
using papaMiaBackend.Domain.Models.Auth;
using papaMiaBackend.Helpers.Tokens;

namespace papaMiaBackend.Api.Auth;

public static class BearerAccessTokenResolver
{
    private const string BearerPrefix = "Bearer ";

    public static bool TryGetBearerToken(HttpRequest? request, [NotNullWhen(true)] out string? token)
    {
        token = null;
        var header = request?.Headers.Authorization.ToString();
        if (string.IsNullOrEmpty(header) || !header.StartsWith(BearerPrefix, StringComparison.OrdinalIgnoreCase))
            return false;

        var raw = header[BearerPrefix.Length..].Trim();
        if (string.IsNullOrEmpty(raw))
            return false;

        token = raw;
        return true;
    }

    public static int? TryGetUserId(HttpRequest? request, JwtGenerationSettings jwtSettings) =>
        TryGetBearerToken(request, out var accessToken)
            ? AccessTokenValidator.TryGetUserId(accessToken, jwtSettings)
            : null;

    public static HashSet<string>? TryGetPermissions(HttpRequest? request, JwtGenerationSettings jwtSettings) =>
        TryGetBearerToken(request, out var accessToken)
            ? AccessTokenValidator.TryGetPermissions(accessToken, jwtSettings)
            : null;
}
