using Microsoft.Extensions.DependencyInjection;
using src.back.Challenge.Domain.Core.UoW;
using src.back.Challenge.Domain.Repositories;
using src.back.Challenge.Infra.Data.Repositories;
using src.back.Challenge.Infra.Data.UoW;

namespace src.back.Challenge.Infra.CrossCutting.Configurations
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
            => services.AddScoped<IBankAccountRepository, BankAccountRepository>()
                .AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<IBankAccountStatementRepository, BankAccountStatementRepository>()
                .AddScoped<IInvestmentRulesRepository, InvestmentRulesRepository>()
                .AddTransient<IUnitOfWork, UnitOfWork>();
    }
}