using DEApp.Data;
using Microsoft.EntityFrameworkCore;

namespace DEApp.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DeappContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DevConnection")));
        }
    }
}
