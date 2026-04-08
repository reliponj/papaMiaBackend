using AutoMapper;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Structure;

public class UserActionExecution : UserActions, IUserAction
{
    public UserActionExecution(IMapper mapper, UserContext db)
        : base(mapper, db)
    {
    }

    public List<UserDto> GetAllUsersAction()
    {
        return GetAllUsersActionExecution();
    }

    public UserDto? GetUserByIdAction(int id)
    {
        return GetUserByIdActionExecution(id);
    }

    public UserDto CreateUserAction(UserCreateDto userCreateDto)
    {
        return CreateUserActionExecution(userCreateDto);
    }

    public UserDto? UpdateUserAction(int id, UserUpdateDto userUpdateDto)
    {
        return UpdateUserActionExecution(id, userUpdateDto);
    }

    public bool DeleteUserAction(int id)
    {
        return DeleteUserActionExecution(id);
    }
}
