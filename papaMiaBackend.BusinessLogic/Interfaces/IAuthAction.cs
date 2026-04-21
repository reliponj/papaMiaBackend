using papaMiaBackend.Domain.Models.Auth;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IAuthAction
{
    UserDto Register(RegisterRequestDto request);

    UserDto? Login(LoginRequestDto request, string clientIp);
}
