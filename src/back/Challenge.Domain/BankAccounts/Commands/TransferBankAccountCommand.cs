using src.back.Challenge.Domain.BankAccounts.CommandResults;
using src.back.Challenge.Domain.Core.Commands;

namespace src.back.Challenge.Domain.BankAccounts.Commands
{
    public class TransferBankAccountCommand
        : Command<TransferBankAccountCommandResult>
    {
        public long SourceBankAccountId { get; set; }
        public string DestinationBranch { get; set; }
        public string DestinationAccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}