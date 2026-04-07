using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using papaMiaBackend.Domain.Entities.Location;

namespace papaMiaBackend.DataAccess.Context;
public class LocationContext : DbContext
{
    public LocationContext(DbContextOptions<LocationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Location> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DbSession.ConnectionString);
        }
    }
}