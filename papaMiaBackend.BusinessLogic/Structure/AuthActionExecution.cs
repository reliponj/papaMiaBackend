using AutoMapper;
using Microsoft.AspNetCore.Identity;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Models.Auth;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Structure;

public class AuthActionExecution : AuthActions, IAuthAction
{
    public AuthActionExecution(UserContext db, IMapper mapper, IPasswordHasher<User> passwordHasher)
        : base(db, mapper, passwordHasher)
    {
    }

    public UserDto Register(RegisterRequestDto request)
    {
        return RegisterActionExecution(request);
    }
}
