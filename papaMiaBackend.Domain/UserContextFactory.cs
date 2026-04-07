using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using papaMiaBackend.Domain.Data;

namespace papaMiaBackend.Domain;

public class UserContextFactory : IDesignTimeDbContextFactory<UserContext>
{
    public UserContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
        optionsBuilder.UseSqlite("Data Source=papamia.db");
        return new UserContext(optionsBuilder.Options);
    }
}
