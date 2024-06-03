using Microsoft.EntityFrameworkCore;

namespace Erotion.API.Infrastructure.Database
{
    public class ErotionContext: DbContext
    {
        public ErotionContext(DbContextOptions<ErotionContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Base call  
            base.OnModelCreating(builder);
        }


    }
}
