using src.back.Challenge.Domain.Core.Commands;
using src.back.Challenge.Domain.InvestmentRules.CommandResults;

namespace src.back.Challenge.Domain.InvestmentRules.Commands
{
    public class CreateInvestmentRulesCommand
        : Command<CreateInvestmentRulesCommandResult>
    {
        public decimal IncomePercentual { get; set; }
        public string BankAccountType { get; set; }
    }
}