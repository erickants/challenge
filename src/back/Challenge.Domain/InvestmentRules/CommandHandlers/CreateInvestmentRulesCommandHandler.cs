using System.Threading.Tasks;
using src.back.Challenge.Domain.Core.Commands;
using src.back.Challenge.Domain.Entities;
using src.back.Challenge.Domain.Enums;
using src.back.Challenge.Domain.InvestmentRules.CommandResults;
using src.back.Challenge.Domain.InvestmentRules.Commands;
using src.back.Challenge.Domain.Repositories;

namespace src.back.Challenge.Domain.InvestmentRules.CommandHandlers
{
    public class CreateInvestmentRulesCommandHandler
        : CommandHandler
        , ICommandHandler<CreateInvestmentRulesCommand, CreateInvestmentRulesCommandResult>
    {
        private readonly IInvestmentRulesRepository _investmentRulesRepository;

        public CreateInvestmentRulesCommandHandler(IInvestmentRulesRepository investigationRulesRepository)
        {
            _investmentRulesRepository = investigationRulesRepository;
        }

        public async Task<CreateInvestmentRulesCommandResult> Handle(CreateInvestmentRulesCommand input)
        {
            var investmentRule = new InvestmentRule
            {
                IncomePercentual = input.IncomePercentual,
                BankAccountType = input.BankAccountType.ToLower() == "poupanca" ? BankAccountTypes.Poupanca
                    : BankAccountTypes.Corrente
            };

            await _investmentRulesRepository.Add(investmentRule);

            return new CreateInvestmentRulesCommandResult();
        }
    }
}