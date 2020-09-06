using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using src.back.Challenge.Infra.Job.Schedules;

namespace src.back.Challenge.Infra.Job.Configurations
{
    public static class ScheduleConfiguration
    {
        public static IServiceCollection AddSchedules(this IServiceCollection services)
        {
            services.AddHangfire(options => options.UseMemoryStorage());
            services.AddTransient<InvestmentSchedule>();

            return services;
        }

        public static IApplicationBuilder UseSchedules(this IApplicationBuilder app)
        {
            app.UseHangfireServer();

            var scopedContainer = app.ApplicationServices.GetService<IServiceScopeFactory>()
                                    .CreateScope().ServiceProvider;

            scopedContainer.GetRequiredService<InvestmentSchedule>()
                .AddIncome();

            return app;
        }
    }
}