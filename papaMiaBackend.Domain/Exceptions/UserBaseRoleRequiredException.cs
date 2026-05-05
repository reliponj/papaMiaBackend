namespace papaMiaBackend.Domain.Exceptions;

public sealed class UserBaseRoleRequiredException : Exception
{
    public UserBaseRoleRequiredException()
        : base("The base user role must be included in role assignments.")
    {
    }
}
