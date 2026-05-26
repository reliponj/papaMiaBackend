using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Constants;
using papaMiaBackend.Domain.Entities.Role;

namespace papaMiaBackend.DataAccess.Seeds;

public static class RoleSeed
{
    private static readonly (string Code, string Name, string Description)[] Roles =
    [
        (RoleCodes.User, "User", "Default user role"),
        (RoleCodes.Moderator, "Moderator", "Moderator role"),
        (RoleCodes.Admin, "Admin", "Administrator role")
    ];

    private static readonly string[] Resources =
    [
        "users", "products", "categories", "allergens", "orders", "articles",
        "banners", "promocodes", "locations", "ingridients", "reviews", "roles", "permissions"
    ];

    private static readonly string[] Actions = ["view", "create", "update", "delete"];

    public static void Apply(RoleContext db)
    {
        foreach (var (code, name, description) in Roles)
        {
            if (db.Roles.Any(r => r.Code == code))
                continue;

            db.Roles.Add(new Role
            {
                Name = name,
                Code = code,
                Description = description,
                IsSystem = true
            });
        }

        foreach (var resource in Resources)
        {
            var groupCode = $"permission.{resource}";
            var group = db.PermissionGroups.FirstOrDefault(g => g.Code == groupCode);
            if (group is null)
            {
                group = new PermissionGroup
                {
                    Code = groupCode,
                    Name = char.ToUpper(resource[0]) + resource[1..],
                    Description = $"{resource} permissions"
                };
                db.PermissionGroups.Add(group);
                db.SaveChanges();
            }

            foreach (var action in Actions)
            {
                var code = $"{resource}.{action}";
                if (db.Permissions.Any(p => p.Code == code))
                    continue;

                db.Permissions.Add(new Permission
                {
                    Code = code,
                    Name = $"{resource}.{action}",
                    Description = code,
                    PermissionGroupId = group.Id
                });
            }
        }

        db.SaveChanges();

        LinkPermissions(db, RoleCodes.Admin, db.Permissions.Select(p => p.Code));
        LinkPermissions(db, RoleCodes.Moderator, PermissionCodes.Moderator);
    }

    private static void LinkPermissions(RoleContext db, string roleCode, IEnumerable<string> permissionCodes)
    {
        var role = db.Roles
            .Include(r => r.Permissions)
            .FirstOrDefault(r => r.Code == roleCode);

        if (role is null)
            return;

        var linked = role.Permissions.Select(p => p.Id).ToHashSet();

        foreach (var permission in db.Permissions.Where(p => permissionCodes.Contains(p.Code)))
        {
            if (!linked.Contains(permission.Id))
                role.Permissions.Add(permission);
        }

        db.SaveChanges();
    }
}
