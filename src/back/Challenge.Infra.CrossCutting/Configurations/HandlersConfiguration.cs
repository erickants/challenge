using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using src.back.Challenge.Domain.BankAccounts.CommandHandlers;
using src.back.Challenge.Domain.BankAccounts.CommandResults;
using src.back.Challenge.Domain.BankAccounts.Commands;
using src.back.Challenge.Domain.Core.Commands;
using src.back.Challenge.Domain.Core.Handlers;
using src.back.Challenge.Domain.Customers.CommandHandlers;
using src.back.Challenge.Domain.Customers.CommandResults;
using src.back.Challenge.Domain.Customers.Commands;
using src.back.Challenge.Domain.InvestmentRules.CommandHandlers;
using src.back.Challenge.Domain.InvestmentRules.CommandResults;
using src.back.Challenge.Domain.InvestmentRules.Commands;
using src.back.Challenge.Infra.CrossCutting.Handlers;

namespace src.back.Challenge.Infra.CrossCutting.Configurations
{
    public static partial class CommandHandlersConfiguration
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            ConfigureHandlers(services as object);

            return services;
        }

        public static void ConfigureHandlers(this IHub hub)
        {
            ConfigureHandlers(hub as object);
        }

        public static void ConfigureHandlers(object service)
        {
            ConfigureCommandHandlers(service);
        }


        private static void AddCommandHandler<H, I, O>(object service)
            where H : class, ICommandHandler<I, O>
            where I : ICommand<O>
            where O : ICommandResult
        {
            AddHandler<H, I, Task<O>>(service, true);
        }

        private static void AddHandler<H, I, O>(object service, bool ensureUnique)
            where H : class, IHandler<I, O>
        {
            if (service is IServiceCollection services)
            {
                services.AddTransient<H>();
            }
            else if (service is IHub hub)
            {
                hub.AddHandler<H, I, O>(ensureUnique);
            }
            else
            {
                throw new ArgumentException("Dude... what are you trying to do ?");
            }
        }

        private static void ConfigureCommandHandlers(object service)
        {
            AddCommandHandler<CreateCustomerCommandHandler
            , CreateCustomerCommand
            , CreateCustomerCommandResult>(service);
            
            AddCommandHandler<FindCustomerCommandHandler
            , FindCustomerCommand
            , FindCustomerCommandResult>(service);
            
            AddCommandHandler<CreateInvestmentRulesCommandHandler
            , CreateInvestmentRulesCommand
            , CreateInvestmentRulesCommandResult>(service);

            AddCommandHandler<CreateBankAccountCommandHandler
            , CreateBankAccountCommand
            , CreateBankAccountCommandResult>(service);

            AddCommandHandler<DepositBankAccountCommandHandler
            , DepositBankAccountCommand
            , DepositBankAccountCommandResult>(service);

            AddCommandHandler<TransferBankAccountCommandHandler
            , TransferBankAccountCommand
            , TransferBankAccountCommandResult>(service);

            AddCommandHandler<GetBankAccountStatementsCommandHandler
            , GetBankAccountStatementsCommand
            , GetBankAccountStatementsCommandResult>(service);

            AddCommandHandler<AddIncomeCommandHandler
            , AddIncomeCommand
            , AddIncomeCommandResult>(service);
        }
    }
}