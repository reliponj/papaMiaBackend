using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Core;

public class UserActions
{
    public UserActions() { }

    internal List<UserDto> GetAllUsersActionExecution()
    {
        var users = new List<UserDto>();

        var user = new UserDto
        {
            Id = 1,
            Username = "TestUser",
            Email = "test@example.com",
            LastLogin = DateTime.UtcNow,
            LastIp = "127.0.0.1",
            Level = URole.User
        };

        users.Add(user);
        return users;
    }
}
