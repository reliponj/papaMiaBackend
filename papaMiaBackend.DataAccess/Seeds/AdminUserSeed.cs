using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Constants;
using papaMiaBackend.Domain.Entities.Role;
using papaMiaBackend.Domain.Entities.User;

namespace papaMiaBackend.DataAccess.Seeds;

public static class AdminUserSeed
{
    public static void Apply(UserContext db, string passwordHash)
    {
        var hasAdminUser = db.Users
            .Any(u => u.Roles.Any(r => r.Code == RoleCodes.Admin));
        if (hasAdminUser)
            return;

        var adminRole = db.Set<Role>().FirstOrDefault(r => r.Code == RoleCodes.Admin);
        if (adminRole is null)
            return;

        var adminEmail = "admin@admin.com";
        var user = db.Users
            .Include(u => u.Roles)
            .FirstOrDefault(u => u.Email.ToLower() == adminEmail.ToLower());

        if (user is null)
        {
            user = new User
            {
                Username = "admin",
                Email = adminEmail,
                LastLogin = DateTime.UtcNow,
                LastIp = string.Empty
            };
            user.Password = passwordHash;
            db.Users.Add(user);
        }

        if (user.Roles.All(r => r.Id != adminRole.Id))
            user.Roles.Add(adminRole);

        db.SaveChanges();
    }
}
