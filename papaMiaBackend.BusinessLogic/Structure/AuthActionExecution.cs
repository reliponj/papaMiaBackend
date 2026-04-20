using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.Auth;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Structure;

public class AuthActionExecution : AuthActions, IAuthAction
{
    public AuthActionExecution(UserContext db, IMapper mapper)
        : base(db, mapper)
    {
    }

    public UserDto Register(RegisterRequestDto request)
    {
        return RegisterActionExecution(request);
    }
}
