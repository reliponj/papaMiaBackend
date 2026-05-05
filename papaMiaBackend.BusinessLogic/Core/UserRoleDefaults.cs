using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Constants;
using papaMiaBackend.Domain.Entities.Role;

namespace papaMiaBackend.BusinessLogic.Core;

internal static class UserRoleDefaults
{
    internal static Role ResolveDefaultUserRole(UserContext db)
    {
        var role = db.Set<Role>().FirstOrDefault(r => r.Code == RoleCodes.User);
        if (role is null)
            throw new InvalidOperationException(
                $"Default user role (code '{RoleCodes.User}') is missing. Ensure roles are seeded.");
        return role;
    }
}
