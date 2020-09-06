using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using src.back.Challenge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace src.back.Challenge.Infra.CrossCutting.Configurations
{
    public static class DatabasesConfiguration
    {
        public static IServiceCollection AddDatabasesConfiguration(this IServiceCollection services
            , IConfiguration configuration)
            => services.AddDbContext<ChallengeContext>(options =>
            {
                options.UseMySql(configuration.GetSection("Database:ConnectionString").Value);
            }, ServiceLifetime.Transient);

    }
}