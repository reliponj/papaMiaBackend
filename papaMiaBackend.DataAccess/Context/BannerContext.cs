using Microsoft.EntityFrameworkCore;
using papaMiaBackend.Domain.Entities.Banner;
using System;
using System.Collections.Generic;
using System.Text;

namespace papaMiaBackend.DataAccess.Context;
public class BannerContext : DbContext
{
    public BannerContext(DbContextOptions<BannerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banner> Banners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DbSession.ConnectionString);
        }
    }
}
