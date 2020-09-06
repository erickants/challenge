using System.Threading.Tasks;
using src.back.Challenge.Domain.BankAccounts.CommandResults;
using src.back.Challenge.Domain.BankAccounts.Commands;
using src.back.Challenge.Domain.Core.Commands;
using src.back.Challenge.Domain.Core.UoW;
using src.back.Challenge.Domain.Entities;
using src.back.Challenge.Domain.Repositories;

namespace src.back.Challenge.Domain.BankAccounts.CommandHandlers
{
    public class DepositBankAccountCommandHandler
        : CommandHandler
        , ICommandHandler<DepositBankAccountCommand, DepositBankAccountCommandResult>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IBankAccountStatementRepository _bankAccountStatementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepositBankAccountCommandHandler(IBankAccountRepository bankAccountRepository
            , IBankAccountStatementRepository bankAccountStatementRepository
            , IUnitOfWork unitOfWork)
        {
            _bankAccountRepository = bankAccountRepository;
            _bankAccountStatementRepository = bankAccountStatementRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DepositBankAccountCommandResult> Handle(DepositBankAccountCommand input)
        {
            var bankAccount = await _bankAccountRepository.FindByBranchAccount(input.Branch, input.AccountNumber);

            bankAccount.AddAmount(input.Amount);

            var bankAccountStatement = new BankAccountStatement
                {
                    DestinationBankAccount = bankAccount,
                    Description = $"Bank deposit done",
                    Type = 0,
                    Amount = input.Amount
                };

            await _unitOfWork.Begin();

            try
            {
                
                await _bankAccountRepository.Update(bankAccount);
                await _bankAccountStatementRepository.Add(bankAccountStatement);

                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
            }

            return new DepositBankAccountCommandResult(bankAccount);
        }
    }
}