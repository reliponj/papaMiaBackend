using Microsoft.EntityFrameworkCore;
using papaMiaBackend.Domain.Entities.Promocode;

namespace papaMiaBackend.DataAccess.Context;

public class PromocodeContext : DbContext
{
    public PromocodeContext(DbContextOptions<PromocodeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Promocode> Promocodes { get; set; }

    public virtual DbSet<PromocodeUsage> PromocodeUsages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PromocodeUsage>()
            .HasOne(u => u.Promocode)
            .WithMany()
            .HasForeignKey(u => u.PromocodeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PromocodeUsage>()
            .HasIndex(u => new { u.UserId, u.PromocodeId })
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
