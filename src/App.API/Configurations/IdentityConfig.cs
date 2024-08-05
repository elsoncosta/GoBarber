using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Configurations
{        
    public static class IdentityConfig
    {
        public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //     .AddRoles<IdentityRole>()
            //     .AddErrorDescriber<IdentityMensagensPortugues>()
            //     .AddEntityFrameworkStores<ContextBase>()
            //     .AddDefaultTokenProviders();
            services.AddJwtConfiguration(configuration);
        }
    }
}