using Microsoft.AspNetCore.Mvc;
namespace App.API.Configurations
{
public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services)
        {

            services.AddControllers();

            // services.AddCors(options =>
            // {
            //     options.AddPolicy("AllowAngularOrigins",
            //         // builder =>
            //         //     builder
            //         //         .AllowAnyOrigin()
            //         //         .AllowAnyMethod()
            //         //         .AllowAnyHeader());
            // });

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAngularOrigins");

            app.UseAuthConfiguration();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}