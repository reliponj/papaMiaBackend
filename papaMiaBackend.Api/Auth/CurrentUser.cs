using Microsoft.Extensions.Options;
using papaMiaBackend.Domain.Models.Auth;
using papaMiaBackend.Helpers.Tokens;

namespace papaMiaBackend.Api.Auth;

public sealed class CurrentUser : ICurrentUser
{
    private const string Bearer = "Bearer ";

    private readonly IHttpContextAccessor _http;
    private readonly JwtGenerationSettings _jwt;

    public CurrentUser(IHttpContextAccessor http, IOptions<JwtGenerationSettings> jwt)
    {
        _http = http;
        _jwt = jwt.Value;
    }

    public int? UserId => Resolve(_http.HttpContext?.Request, _jwt);

    public bool TryGetUserId(out int userId)
    {
        var id = UserId;
        userId = id ?? 0;
        return id.HasValue;
    }

    private static int? Resolve(HttpRequest? request, JwtGenerationSettings jwt)
    {
        var header = request?.Headers.Authorization.ToString();
        if (string.IsNullOrEmpty(header) || !header.StartsWith(Bearer, StringComparison.OrdinalIgnoreCase))
            return null;

        var token = header[Bearer.Length..].Trim();
        return string.IsNullOrEmpty(token) ? null : AccessTokenValidator.TryGetUserId(token, jwt);
    }
}
