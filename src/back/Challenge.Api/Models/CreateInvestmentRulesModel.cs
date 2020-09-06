using System.ComponentModel.DataAnnotations;
using src.back.Challenge.Domain.InvestmentRules.Commands;

namespace src.back.Challenge.Api.Models
{
    public class CreateInvestmentRulesModel
    {
        [Required]
        public decimal? IncomePercentual { get; set; }

        [Required]
        public string BankAccountType { get; set; }

        public CreateInvestmentRulesCommand MapToCommand()
            => new CreateInvestmentRulesCommand
            {
                IncomePercentual = IncomePercentual.Value,
                BankAccountType = BankAccountType
            };
    }
}