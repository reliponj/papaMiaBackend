using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Constants;

namespace papaMiaBackend.BusinessLogic.Core;

public static class UserPermissions
{
    public static List<string> GetCodes(UserContext userDb, RoleContext roleDb, int userId)
    {
        var isAdmin = userDb.Users
            .AsNoTracking()
            .Where(u => u.Id == userId)
            .SelectMany(u => u.Roles)
            .Any(r => r.Code == RoleCodes.Admin);

        if (isAdmin)
        {
            return roleDb.Permissions
                .Select(p => p.Code)
                .ToList();
        }

        var roleIds = userDb.Users
            .Where(u => u.Id == userId)
            .SelectMany(u => u.Roles.Select(r => r.Id))
            .ToList();

        if (roleIds.Count == 0)
            return [];

        return roleDb.Roles
            .Where(r => roleIds.Contains(r.Id))
            .SelectMany(r => r.Permissions)
            .Select(p => p.Code)
            .Distinct()
            .ToList();
    }
}
