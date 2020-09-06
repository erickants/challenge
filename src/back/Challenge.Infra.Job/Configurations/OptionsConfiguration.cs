using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using src.back.Challenge.Infra.Job.Options;

namespace src.back.Challenge.Infra.Job.Configurations
{
    public static class OptionsConfiguration
    {
        public static IServiceCollection AddScheduleOptionsConfiguration(this IServiceCollection services
            , IConfiguration configuration)
            => services.Configure<ScheduleOption>(configuration.GetSection("ScheduleOptions"));
    }
}