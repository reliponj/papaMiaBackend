using Microsoft.EntityFrameworkCore;
using PizzaNs = papaMiaBackend.Domain.Entities.CustomPizza;
using IngNs = papaMiaBackend.Domain.Entities.Ingridient;

namespace papaMiaBackend.DataAccess.Context;

public class CustomPizzaContext : DbContext
{
    public CustomPizzaContext(DbContextOptions<CustomPizzaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PizzaNs.CustomPizza> CustomPizzas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IngNs.Ingridient>(entity =>
        {
            entity.ToTable("Ingridients", t => t.ExcludeFromMigrations());
        });

        modelBuilder.Entity<PizzaNs.CustomPizza>()
            .HasMany(p => p.Ingridients)
            .WithMany(i => i.CustomPizzas)
            .UsingEntity(j => j.ToTable("CustomPizzaIngridients"));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DbSession.ConnectionString);
        }
    }
}
