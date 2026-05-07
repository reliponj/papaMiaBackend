using Microsoft.EntityFrameworkCore;
using papaMiaBackend.Domain.Entities.Ingridient;

namespace papaMiaBackend.DataAccess.Context;

public class IngridientContext : DbContext
{
    public IngridientContext(DbContextOptions<IngridientContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingridient> Ingridients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DbSession.ConnectionString);
        }
    }
}
