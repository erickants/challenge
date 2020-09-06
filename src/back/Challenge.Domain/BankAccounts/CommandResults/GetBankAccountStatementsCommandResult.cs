using src.back.Challenge.Domain.Core.Commands;

namespace src.back.Challenge.Domain.BankAccounts.CommandResults
{
    public class GetBankAccountStatementsCommandResult : CommandResult
    {
        public GetBankAccountStatementsCommandResult(object data) : base(data)
        {
            
        }
    }
}