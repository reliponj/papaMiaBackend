using AutoMapper;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Models.Auth;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Core;

public class AuthActions
{
    protected readonly UserContext Db;
    protected readonly IMapper Mapper;

    public AuthActions(UserContext db, IMapper mapper)
    {
        Db = db;
        Mapper = mapper;
    }

    internal UserDto RegisterActionExecution(RegisterRequestDto request)
    {
        var entity = new User
        {
            Username = request.Username,
            Email = request.Email,
            Password = request.Password,
            LastLogin = DateTime.UtcNow,
            LastIp = string.Empty,
            Level = URole.User
        };

        Db.Users.Add(entity);
        Db.SaveChanges();

        return Mapper.Map<UserDto>(entity);
    }
}
