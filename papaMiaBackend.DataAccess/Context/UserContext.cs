using Microsoft.EntityFrameworkCore;
using papaMiaBackend.Domain.Entities.Role;
using papaMiaBackend.Domain.Entities.User;

namespace papaMiaBackend.DataAccess.Context;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<UserFavorite> UserFavorites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Permission>();
        modelBuilder.Ignore<PermissionGroup>();

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Ignore(r => r.Permissions);
            entity.ToTable("Roles", t => t.ExcludeFromMigrations());
        });

        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity(j => j.ToTable("UserRoles"));

        modelBuilder.Entity<UserFavorite>()
            .HasIndex(f => new { f.UserId, f.ProductId })
            .IsUnique();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DbSession.ConnectionString);
        }
    }
}
