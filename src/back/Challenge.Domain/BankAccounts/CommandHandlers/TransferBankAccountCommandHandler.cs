using System.Collections.Generic;
using System.Threading.Tasks;
using src.back.Challenge.Domain.BankAccounts.CommandResults;
using src.back.Challenge.Domain.BankAccounts.Commands;
using src.back.Challenge.Domain.Core.Commands;
using src.back.Challenge.Domain.Core.UoW;
using src.back.Challenge.Domain.Entities;
using src.back.Challenge.Domain.Repositories;

namespace src.back.Challenge.Domain.BankAccounts.CommandHandlers
{
    public class TransferBankAccountCommandHandler
        : CommandHandler
        , ICommandHandler<TransferBankAccountCommand, TransferBankAccountCommandResult>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IBankAccountStatementRepository _bankAccountStatementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TransferBankAccountCommandHandler(IBankAccountRepository bankAccountRepository
            , IBankAccountStatementRepository bankAccountStatementRepository
            , IUnitOfWork unitOfWork)
        {
            _bankAccountRepository = bankAccountRepository;
            _bankAccountStatementRepository = bankAccountStatementRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TransferBankAccountCommandResult> Handle(TransferBankAccountCommand input)
        {
            var sourceBankAccount = await _bankAccountRepository.Find(input.SourceBankAccountId);

            var destinationBankAccount = await _bankAccountRepository
                .FindByBranchAccount(input.DestinationBranch, input.DestinationAccountNumber);

            if (sourceBankAccount.Balance >= input.Amount)
            {
                sourceBankAccount.AddAmount(input.Amount * -1) ;
                destinationBankAccount.AddAmount(input.Amount);

                var bankAccountStatement = new BankAccountStatement
                {
                    SourceBankAccount = sourceBankAccount,
                    DestinationBankAccount = destinationBankAccount,
                    Description = $"Bank transfer done",
                    Type = (Enums.StatementTypes)2,
                    Amount = input.Amount
                };

                await _unitOfWork.Begin();

                try
                {
                    var bankAccountToUpdate = new List<BankAccount>
                    {
                        sourceBankAccount,
                        destinationBankAccount
                    };

                    await _bankAccountRepository.UpdateRange(bankAccountToUpdate);
                    await _bankAccountStatementRepository.Add(bankAccountStatement);

                    _unitOfWork.Commit();
                }
                catch
                {
                    _unitOfWork.Rollback();
                }
            }

            return new TransferBankAccountCommandResult(sourceBankAccount);
        }
    }
}