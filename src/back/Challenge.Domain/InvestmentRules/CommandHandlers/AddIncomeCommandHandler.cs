using System.Collections.Generic;
using System.Threading.Tasks;
using src.back.Challenge.Domain.Core.Commands;
using src.back.Challenge.Domain.Entities;
using src.back.Challenge.Domain.Enums;
using src.back.Challenge.Domain.InvestmentRules.CommandResults;
using src.back.Challenge.Domain.InvestmentRules.Commands;
using src.back.Challenge.Domain.Repositories;

namespace src.back.Challenge.Domain.InvestmentRules.CommandHandlers
{
    public class AddIncomeCommandHandler
        : CommandHandler
        , ICommandHandler<AddIncomeCommand, AddIncomeCommandResult>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IBankAccountStatementRepository _bankAccountStatementRepository;
        private readonly IInvestmentRulesRepository _investmentRulesRepository;

        public AddIncomeCommandHandler(IBankAccountRepository bankAccountRepository
            , IBankAccountStatementRepository bankAccountStatementRepository
            , IInvestmentRulesRepository investmentRulesRepository)
        {
            _bankAccountRepository = bankAccountRepository;
            _bankAccountStatementRepository = bankAccountStatementRepository;
            _investmentRulesRepository = investmentRulesRepository;
        }

        public async Task<AddIncomeCommandResult> Handle(AddIncomeCommand input)
        {
            var investmentRule = await _investmentRulesRepository.GetByBankAccountType(BankAccountTypes.Corrente);
            var bankAccounts = await _bankAccountRepository.GetByBankAccountType(BankAccountTypes.Corrente);
            var bankStatements = new List<BankAccountStatement>();

            foreach (var bankAccount in bankAccounts)
            {
                var incomeAmount = (investmentRule.IncomePercentual/100) * bankAccount.Balance;

                bankAccount.AddAmount(incomeAmount);

                bankStatements.Add(new BankAccountStatement
                {
                    DestinationBankAccountId = bankAccount.Id,
                    Description = "Daily income",
                    Type = StatementTypes.Income,
                    Amount = incomeAmount
                });
            }

            var taskList = new List<Task>();

            taskList.Add(_bankAccountRepository.UpdateRange(bankAccounts));
            taskList.Add(_bankAccountStatementRepository.AddRange(bankStatements));

            await Task.WhenAll(taskList);

            return new AddIncomeCommandResult();
        }
    }
}