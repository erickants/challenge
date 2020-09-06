using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.back.Challenge.Domain.Entities;
using src.back.Challenge.Domain.Enums;
using src.back.Challenge.Domain.Repositories;
using src.back.Challenge.Infra.Data.Context;

namespace src.back.Challenge.Infra.Data.Repositories
{
    public class InvestmentRulesRepository : BaseRepository<InvestmentRule>
        , IInvestmentRulesRepository
    {
        public InvestmentRulesRepository(ChallengeContext context) : base(context)
        {
        }

        public Task<InvestmentRule> GetByBankAccountType(BankAccountTypes bankAccountType)
            => Context.InvestmentRules.FirstOrDefaultAsync(r => r.BankAccountType == bankAccountType);
    }
}