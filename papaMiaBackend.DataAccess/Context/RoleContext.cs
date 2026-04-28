using Microsoft.EntityFrameworkCore;
using papaMiaBackend.Domain.Entities.Role;
using papaMiaBackend.Domain.Entities.User;

namespace papaMiaBackend.DataAccess.Context;

public class RoleContext : DbContext
{
    public RoleContext(DbContextOptions<RoleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Permission> Permissions { get; set; }
    public virtual DbSet<PermissionGroup> PermissionGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<User>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DbSession.ConnectionString);
        }
    }
}
