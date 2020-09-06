using System.Threading.Tasks;
using src.back.Challenge.Domain.BankAccounts.CommandResults;
using src.back.Challenge.Domain.BankAccounts.Commands;
using src.back.Challenge.Domain.Core.Commands;
using src.back.Challenge.Domain.Repositories;

namespace src.back.Challenge.Domain.BankAccounts.CommandHandlers
{
    public class GetBankAccountStatementsCommandHandler
        : CommandHandler
        , ICommandHandler<GetBankAccountStatementsCommand, GetBankAccountStatementsCommandResult>
    {
        private readonly IBankAccountStatementRepository _bankAccountStatementRepository;

        public GetBankAccountStatementsCommandHandler(IBankAccountStatementRepository bankAccountStatementRepository)
        {
            _bankAccountStatementRepository = bankAccountStatementRepository;
        }

        public async Task<GetBankAccountStatementsCommandResult> Handle(GetBankAccountStatementsCommand input)
        {
            var bankAccountStatments = await _bankAccountStatementRepository.List(input.BankAccountId);

            return new GetBankAccountStatementsCommandResult(bankAccountStatments);
        }
    }
}