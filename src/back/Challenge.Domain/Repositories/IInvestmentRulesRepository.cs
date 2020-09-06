using System.Threading.Tasks;
using src.back.Challenge.Domain.Core.Repositories;
using src.back.Challenge.Domain.Entities;
using src.back.Challenge.Domain.Enums;

namespace src.back.Challenge.Domain.Repositories
{
    public interface IInvestmentRulesRepository
        : IRepository<InvestmentRule>
    {
        Task<InvestmentRule> GetByBankAccountType(BankAccountTypes bankAccountType);
    }
}