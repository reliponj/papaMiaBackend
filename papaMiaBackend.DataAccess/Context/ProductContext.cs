using Microsoft.EntityFrameworkCore;
using papaMiaBackend.Domain.Entities.Product;

namespace papaMiaBackend.DataAccess.Context;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DbSession.ConnectionString);
        }
    }
}