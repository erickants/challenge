using src.back.Challenge.Domain.Core.Commands;

namespace src.back.Challenge.Domain.BankAccounts.CommandResults
{
    public class TransferBankAccountCommandResult
        : CommandResult
    {
        public TransferBankAccountCommandResult(object data) : base(data)
        {
            
        }
    }
}