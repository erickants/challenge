using System.ComponentModel.DataAnnotations;
using src.back.Challenge.Domain.BankAccounts.Commands;

namespace src.back.Challenge.Api.Models
{
    public class DepositBankAccountModel
    {
        [Required]
        public string Branch { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public decimal? Amount { get; set; }

        public DepositBankAccountCommand MapToCommand()
            => new DepositBankAccountCommand
            {
                Branch = Branch,
                AccountNumber = AccountNumber,
                Amount = Amount.Value
            };
    }
}