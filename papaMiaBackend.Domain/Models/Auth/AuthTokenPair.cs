namespace papaMiaBackend.Domain.Models.Auth;

public sealed record AuthTokenPair(
    string AccessToken,
    string RefreshToken,
    DateTimeOffset AccessTokenExpiresAtUtc,
    DateTimeOffset RefreshTokenExpiresAtUtc);
