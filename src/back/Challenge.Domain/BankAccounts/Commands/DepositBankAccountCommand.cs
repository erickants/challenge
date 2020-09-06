using src.back.Challenge.Domain.BankAccounts.CommandResults;
using src.back.Challenge.Domain.Core.Commands;

namespace src.back.Challenge.Domain.BankAccounts.Commands
{
    public class DepositBankAccountCommand
        : Command<DepositBankAccountCommandResult>
    {
        public string Branch { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}