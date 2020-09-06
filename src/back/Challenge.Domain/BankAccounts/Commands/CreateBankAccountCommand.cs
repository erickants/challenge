using src.back.Challenge.Domain.BankAccounts.CommandResults;
using src.back.Challenge.Domain.Core.Commands;

namespace src.back.Challenge.Domain.BankAccounts.Commands
{
    public class CreateBankAccountCommand
        : Command<CreateBankAccountCommandResult>
    {
        public string Branch { get; set; }
        public string AccountNumber { get; set; }
        public long CustomerId { get; set; }
        public string BankAccountType { get; set; }
    }
}