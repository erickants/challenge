using src.back.Challenge.Infra.CrossCutting.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace src.back.Challenge.Infra.CrossCutting.Configurations
{
    public static class OptionsConfiguration
    {
        public static IServiceCollection AddOptionsConfiguration(this IServiceCollection services
            , IConfiguration configuration)
            => services.Configure<DatabaseOption>(configuration.GetSection("Database"));
    }
}