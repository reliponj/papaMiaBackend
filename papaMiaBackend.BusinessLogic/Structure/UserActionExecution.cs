using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Structure;

public class UserActionExecution : UserActions, IUserAction
{
    public List<UserDto> GetAllUsersAction()
    {
        return GetAllUsersActionExecution();
    }
}
