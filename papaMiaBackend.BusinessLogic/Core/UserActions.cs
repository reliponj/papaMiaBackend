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
        if (user == null)
        {
            throw new Exception("User not found");
        }
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

    internal UserDto UpdateUserActionExecution(int id, UserUpdateDto userUpdateDto)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        user.Username = userUpdateDto.Username;
        user.Email = userUpdateDto.Email;
        return user;
    }

    internal void DeleteUserActionExecution(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        users.Remove(user);
    }
}
