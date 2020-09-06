using System.ComponentModel.DataAnnotations;
using src.back.Challenge.Domain.BankAccounts.Commands;

namespace src.back.Challenge.Api.Models
{
    public class CreateBankAccountModel
    {
        [Required]
        public string Branch { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public long? CustomerId { get; set; }

        [Required]
        public string BankAccountType { get; set; }

        public CreateBankAccountCommand MapToCommand()
            => new CreateBankAccountCommand
            {
                Branch = Branch,
                AccountNumber = AccountNumber,
                CustomerId = CustomerId.Value,
                BankAccountType = BankAccountType
            };
    }
}