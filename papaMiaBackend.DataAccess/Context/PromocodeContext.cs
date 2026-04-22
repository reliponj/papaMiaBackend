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
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DbSession.ConnectionString);
        }
    }
}
