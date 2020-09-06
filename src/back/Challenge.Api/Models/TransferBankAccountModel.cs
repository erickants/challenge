using System.ComponentModel.DataAnnotations;
using src.back.Challenge.Domain.BankAccounts.Commands;

namespace src.back.Challenge.Api.Models
{
    public class TransferBankAccountModel
    {
        [Required]
        public string DestinationBranch { get; set; }

        [Required]
        public string DestinationAccountNumber { get; set; }

        [Required]
        public decimal? Amount { get; set; }

        public TransferBankAccountCommand MapToCommand(long id)
            => new TransferBankAccountCommand
            {
                SourceBankAccountId = id,
                DestinationBranch = DestinationBranch,
                DestinationAccountNumber = DestinationAccountNumber,
                Amount = Amount.Value,
            };
    }
}