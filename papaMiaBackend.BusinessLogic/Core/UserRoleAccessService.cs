using Microsoft.EntityFrameworkCore;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.DataAccess.Context;

namespace papaMiaBackend.BusinessLogic.Core;

public sealed class UserRoleAccessService : IUserRoleAccessService
{
    private readonly UserContext _db;

    public UserRoleAccessService(UserContext db)
    {
        _db = db;
    }

    public bool UserHasAnyRole(int userId, IEnumerable<string> roleCodes)
    {
        var required = roleCodes
            .Where(c => !string.IsNullOrWhiteSpace(c))
            .Select(c => c.Trim())
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        if (required.Count == 0)
            return false;

        var assigned = _db.Users
            .AsNoTracking()
            .Where(u => u.Id == userId)
            .SelectMany(u => u.Roles.Select(r => r.Code))
            .ToList();

        return assigned.Any(code => required.Contains(code));
    }
}
