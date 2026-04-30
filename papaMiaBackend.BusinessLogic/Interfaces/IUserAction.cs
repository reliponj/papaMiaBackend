using papaMiaBackend.Domain.Models.User;
using papaMiaBackend.Domain.Models.Role;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IUserAction
{
    List<UserDto> GetAllUsersAction();
    UserDto? GetUserByIdAction(int id);
    List<RoleListDto>? GetUserRolesAction(int id);
    UserDto CreateUserAction(UserCreateDto userCreateDto);
    UserDto? UpdateUserAction(int id, UserUpdateDto userUpdateDto);
    bool DeleteUserAction(int id);
}
