namespace papaMiaBackend.BusinessLogic.Interfaces;

public interface IUserRoleAccessService
{
    bool UserHasAnyRole(int userId, IEnumerable<string> roleCodes);
}
