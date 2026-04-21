using papaMiaBackend.Domain.Models.Auth;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IAuthAction
{
    AuthTokenPair Register(RegisterRequestDto request);

    AuthTokenPair? Login(LoginRequestDto request, string clientIp);

    AuthTokenPair? RefreshTokens(string refreshToken);
}
