using Microsoft.EntityFrameworkCore;

namespace WebApp
{
    public static class DependencyInjection
    {
        public static IHost MigrateDatabase<T>(this IHost host, IConfiguration configuration) where T : DbContext
        {
            if(!Convert.ToBoolean(configuration["DockerMigration"]))
                return host;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var db = services.GetRequiredService<T>();
                    db.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }
            return host;
        }
    }
}
