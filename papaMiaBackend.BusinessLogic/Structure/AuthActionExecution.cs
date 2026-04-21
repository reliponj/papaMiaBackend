using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Models.Auth;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Structure;

public class AuthActionExecution : AuthActions, IAuthAction
{
    public AuthActionExecution(
        UserContext db,
        IMapper mapper,
        IPasswordHasher<User> passwordHasher,
        IOptions<JwtGenerationSettings> jwtOptions)
        : base(db, mapper, passwordHasher, jwtOptions)
    {
    }

    public UserDto Register(RegisterRequestDto request)
    {
        return RegisterActionExecution(request);
    }

    public UserDto? Login(LoginRequestDto request, string clientIp)
    {
        return LoginActionExecution(request, clientIp);
    }

    public AuthTokenPair? RefreshTokens(string refreshToken)
    {
        return RefreshTokensExecution(refreshToken);
    }
}
