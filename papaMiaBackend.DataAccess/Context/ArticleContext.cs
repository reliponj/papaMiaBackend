using Microsoft.EntityFrameworkCore;
using papaMiaBackend.Domain.Entities.Article;

namespace papaMiaBackend.DataAccess.Context;

public class ArticleContext : DbContext
{
    public ArticleContext(DbContextOptions<ArticleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DbSession.ConnectionString);
        }
    }
}
