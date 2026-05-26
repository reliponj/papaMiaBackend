using Microsoft.EntityFrameworkCore;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Constants;
using papaMiaBackend.Domain.Entities.Role;
using papaMiaBackend.Domain.Entities.User;

namespace papaMiaBackend.DataAccess.Seeds;

public static class ModeratorUserSeed
{
    public static void Apply(UserContext db, string passwordHash)
    {
        const string moderatorEmail = "moderator@admin.com";

        var existing = db.Users
            .Include(u => u.Roles)
            .FirstOrDefault(u => u.Email.ToLower() == moderatorEmail.ToLower());

        if (existing?.Roles.Any(r => r.Code == RoleCodes.Moderator) == true)
            return;

        var moderatorRole = db.Set<Role>().FirstOrDefault(r => r.Code == RoleCodes.Moderator);
        if (moderatorRole is null)
            return;

        var user = existing;
        if (user is null)
        {
            user = new User
            {
                Username = "moderator",
                Email = moderatorEmail,
                LastLogin = DateTime.UtcNow,
                LastIp = string.Empty
            };
            user.Password = passwordHash;
            db.Users.Add(user);
        }

        if (user.Roles.All(r => r.Id != moderatorRole.Id))
            user.Roles.Add(moderatorRole);

        db.SaveChanges();
    }
}
