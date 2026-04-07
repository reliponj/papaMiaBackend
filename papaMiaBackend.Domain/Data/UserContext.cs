using Microsoft.EntityFrameworkCore;
using papaMiaBackend.Domain.Entities.User;

namespace papaMiaBackend.Domain.Data;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UDbTable> Users { get; set; }
}
