using src.back.Challenge.Domain.BankAccounts.CommandResults;
using src.back.Challenge.Domain.Core.Commands;

namespace src.back.Challenge.Domain.BankAccounts.Commands
{
    public class GetBankAccountStatementsCommand
        : Command<GetBankAccountStatementsCommandResult>
    {
        public long BankAccountId { get; set; }
    }
}