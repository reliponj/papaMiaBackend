using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IUserAction
{
    List<UserDto> GetAllUsersAction();
    UserDto GetUserByIdAction(int id);
    UserDto CreateUserAction(UserCreateDto userCreateDto);
    UserDto UpdateUserAction(int id, UserUpdateDto userUpdateDto);
    void DeleteUserAction(int id);
}
