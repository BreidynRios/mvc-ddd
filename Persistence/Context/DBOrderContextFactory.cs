using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context
{
    public class DBOrderContextFactory : IDesignTimeDbContextFactory<DBOrderContext>
    {
        public DBOrderContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebApp"))
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DBOrderContext>();
            optionsBuilder.UseSqlServer(config["DbConnectionString"]);

            return new DBOrderContext(optionsBuilder.Options);
        }
    }
}
