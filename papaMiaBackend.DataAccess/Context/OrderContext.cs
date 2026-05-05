using Microsoft.EntityFrameworkCore;
using papaMiaBackend.Domain.Entities.Order;

namespace papaMiaBackend.DataAccess.Context;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DbSession.ConnectionString);
        }
    }
}
