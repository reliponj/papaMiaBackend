using Microsoft.Extensions.Options;
using papaMiaBackend.Domain.Models.Auth;

namespace papaMiaBackend.Api.Auth;

public sealed class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _http;
    private readonly JwtGenerationSettings _jwt;

    public CurrentUser(IHttpContextAccessor http, IOptions<JwtGenerationSettings> jwt)
    {
        _http = http;
        _jwt = jwt.Value;
    }

    public int? UserId => BearerAccessTokenResolver.TryGetUserId(_http.HttpContext?.Request, _jwt);

    public bool TryGetUserId(out int userId)
    {
        var id = UserId;
        userId = id ?? 0;
        return id.HasValue;
    }
}
