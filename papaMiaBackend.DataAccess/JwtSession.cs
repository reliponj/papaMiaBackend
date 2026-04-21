using papaMiaBackend.Domain.Models.Auth;

namespace papaMiaBackend.DataAccess;

public static class JwtSession
{
    public static JwtGenerationSettings Settings { get; set; } = null!;
}
