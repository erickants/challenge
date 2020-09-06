using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using src.back.Challenge.Api.Configurations;
using src.back.Challenge.Infra.CrossCutting.Configurations;
using src.back.Challenge.Infra.Job.Configurations;

namespace challenge.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services.AddOptionsConfiguration(Configuration)
                .AddRepositories()
                .AddDatabasesConfiguration(Configuration)
                .AddCommandHandlers()
                .AddSwaggerGen()
                .AddSchedules()
                .AddScheduleOptionsConfiguration(Configuration)
                .AddCoreConfiguration();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseUpdateMigrations();
            app.UseSwagger();
            app.UseSchedules();
            app.UseSwaggerUI(p => 
            {
                p.SwaggerEndpoint("/swagger/v1/swagger.json", "Challenge Warren API");
                p.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
