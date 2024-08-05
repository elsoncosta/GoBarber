using App.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetCore.Infra.Common.Interfaces;

namespace App.API.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            
            string connectionString = configuration.GetConnectionString("ConnectionString")!;
            services.AddDbContextPool<ContextBase>(options =>
                options.UseNpgsql(connectionString));
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }
}