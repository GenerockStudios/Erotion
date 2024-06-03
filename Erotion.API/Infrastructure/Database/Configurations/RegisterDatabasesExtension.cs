using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Erotion.API.Infrastructure.Database.Configurations
{
    public static class RegisterDatabasesExtension
    {
       public static IServiceCollection AddDatabaseErotionContext(this IServiceCollection services, IConfiguration configuration)
        {
            string cs = configuration.GetConnectionString("erotion_context_postgresql")!;
            services.AddDbContext<ErotionContext>(options =>
            {
                options.UseNpgsql(cs, c => c.MigrationsAssembly("Erotion.API"));
            }
           );
            return services;
       }
    }
}
