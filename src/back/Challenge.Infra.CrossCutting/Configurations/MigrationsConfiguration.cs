using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using src.back.Challenge.Infra.Data.Context;

namespace src.back.Challenge.Infra.CrossCutting.Configurations
{
    public static class MigrationsConfiguration
    {
        public static void UseUpdateMigrations(this IApplicationBuilder applicationBuilder)
        {
            var scopeFactory = applicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>();
            var scopedContainer = scopeFactory.CreateScope().ServiceProvider;
            var context = scopedContainer.GetRequiredService<ChallengeContext>();
            var migrationsAssembly = context.GetService<IMigrationsAssembly>();
            var historyRepository = context.GetService<IHistoryRepository>();

            var all = migrationsAssembly.Migrations.Keys;
            var applied = historyRepository.GetAppliedMigrations().Select(r => r.MigrationId);
            var pending = all.Except(applied);

            if (pending.Any())
                context.Database.Migrate();
        }
    }
}