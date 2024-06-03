using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Erotion.API.Infrastructure.Database.Initializers
{
    /// <summary>
    /// This extension Initialize Erotion database
    /// </summary>
    public static class InitializeErotionContextExtension
    {
        /// <summary>
        /// This extension Initialize Erotion database
        /// </summary>
        /// <param name="serviceProvider">Service provider of scope, of your application</param>
        /// <returns></returns>
        public async static Task<IServiceProvider> InitializeErotionContext(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ErotionContext>();
            await context.Database.MigrateAsync();
            return serviceProvider;
        }
    }
}
