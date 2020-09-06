using System.Threading.Tasks;
using src.back.Challenge.Domain.BankAccounts.CommandResults;
using src.back.Challenge.Domain.BankAccounts.Commands;
using src.back.Challenge.Domain.Core.Commands;
using src.back.Challenge.Domain.Entities;
using src.back.Challenge.Domain.Enums;
using src.back.Challenge.Domain.Repositories;

namespace src.back.Challenge.Domain.BankAccounts.CommandHandlers
{
    public class CreateBankAccountCommandHandler
        : CommandHandler
        , ICommandHandler<CreateBankAccountCommand, CreateBankAccountCommandResult>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public CreateBankAccountCommandHandler(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<CreateBankAccountCommandResult> Handle(CreateBankAccountCommand input)
        {
            var bankAccount = new BankAccount
            {
                Branch = input.Branch,
                AccountNumber = input.AccountNumber,
                CustomerId = input.CustomerId,
                Type = input.BankAccountType.ToLower() == "poupanca" ? BankAccountTypes.Poupanca
                    : BankAccountTypes.Corrente
            };

            await _bankAccountRepository.Add(bankAccount);

            return new CreateBankAccountCommandResult();
        }
    }
}