using Microsoft.EntityFrameworkCore;
using papaMiaBackend.Domain.Entities.Review;

namespace papaMiaBackend.DataAccess.Context;

public class ReviewContext : DbContext
{
    public ReviewContext(DbContextOptions<ReviewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Review>()
            .HasIndex(r => r.UserId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DbSession.ConnectionString);
        }
    }
}
