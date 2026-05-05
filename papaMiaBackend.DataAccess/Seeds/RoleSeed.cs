using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.Role;

namespace papaMiaBackend.DataAccess.Seeds;

public static class RoleSeed
{
    public static void Apply(RoleContext db)
    {
        if (!db.Roles.Any(r => r.Code == "user"))
        {
            db.Roles.Add(new Role
            {
                Name = "User",
                Code = "user",
                Description = "Default user role",
                IsSystem = true
            });
        }

        if (!db.Roles.Any(r => r.Code == "moderator"))
        {
            db.Roles.Add(new Role
            {
                Name = "Moderator",
                Code = "moderator",
                Description = "Moderator role",
                IsSystem = true
            });
        }

        if (!db.Roles.Any(r => r.Code == "admin"))
        {
            db.Roles.Add(new Role
            {
                Name = "Admin",
                Code = "admin",
                Description = "Administrator role",
                IsSystem = true
            });
        }

        var usersGroup = db.PermissionGroups.FirstOrDefault(g => g.Code == "permission.users");
        if (usersGroup == null)
        {
            usersGroup = new PermissionGroup
            {
                Name = "Users",
                Code = "permission.users",
                Description = "Users permissions"
            };
            db.PermissionGroups.Add(usersGroup);
            db.SaveChanges();
        }

        EnsurePermission(db, usersGroup.Id, "Users.View", "users.view", "View users");
        EnsurePermission(db, usersGroup.Id, "Users.Create", "users.create", "Create users");
        EnsurePermission(db, usersGroup.Id, "Users.Update", "users.update", "Update users");
        EnsurePermission(db, usersGroup.Id, "Users.Delete", "users.delete", "Delete users");

        db.SaveChanges();

        var adminRole = db.Roles
            .Where(r => r.Code == "admin")
            .FirstOrDefault();

        if (adminRole != null)
        {
            var usersPermissions = db.Permissions
                .Where(p => p.PermissionGroupId == usersGroup.Id)
                .ToList();

            db.Entry(adminRole).Collection(r => r.Permissions).Load();

            foreach (var permission in usersPermissions)
            {
                if (adminRole.Permissions.All(p => p.Id != permission.Id))
                    adminRole.Permissions.Add(permission);
            }

            db.SaveChanges();
        }
    }

    private static void EnsurePermission(
        RoleContext db,
        int groupId,
        string name,
        string code,
        string description)
    {
        if (db.Permissions.Any(p => p.Code == code))
            return;

        db.Permissions.Add(new Permission
        {
            Name = name,
            Code = code,
            Description = description,
            PermissionGroupId = groupId
        });
    }
}
