using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Core;

public class UserActions
{
    public UserActions() { }

    internal List<UserDto> users = new List<UserDto>();

    internal List<UserDto> GetAllUsersActionExecution()
    {
        return users;
    }

    internal UserDto GetUserByIdActionExecution(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        return user;
    }

    internal UserDto CreateUserActionExecution(UserCreateDto userCreateDto)
    {
        var user = new UserDto
        {
            Username = userCreateDto.Username,
            Email = userCreateDto.Email,
        };
        users.Add(user);
        return user;
    }
}
