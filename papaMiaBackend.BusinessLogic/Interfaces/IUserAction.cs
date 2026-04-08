using papaMiaBackend.Domain.Models.User;

namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IUserAction
{
    List<UserDto> GetAllUsersAction();
}
