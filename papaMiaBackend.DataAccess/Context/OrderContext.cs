using Microsoft.EntityFrameworkCore;
using OrdNs = papaMiaBackend.Domain.Entities.Order;
using PromoNs = papaMiaBackend.Domain.Entities.Promocode;
using PizzaNs = papaMiaBackend.Domain.Entities.CustomPizza;

namespace papaMiaBackend.DataAccess.Context;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OrdNs.Order> Orders { get; set; }

    public virtual DbSet<OrdNs.OrderItem> OrderItems { get; set; }
    public virtual DbSet<OrdNs.OrderCustomPizzaItem> OrderCustomPizzaItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrdNs.OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PizzaNs.CustomPizza>(entity =>
        {
            entity.ToTable("CustomPizzas", t => t.ExcludeFromMigrations());
        });

        modelBuilder.Entity<OrdNs.OrderCustomPizzaItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.CustomPizzaItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrdNs.OrderCustomPizzaItem>()
            .HasOne(oi => oi.CustomPizza)
            .WithMany()
            .HasForeignKey(oi => oi.CustomPizzaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrdNs.Order>()
            .HasOne<PromoNs.Promocode>(o => o.Promocode)
            .WithMany()
            .HasForeignKey(o => o.PromocodeId)
            .OnDelete(DeleteBehavior.SetNull);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DbSession.ConnectionString);
        }
    }
}
