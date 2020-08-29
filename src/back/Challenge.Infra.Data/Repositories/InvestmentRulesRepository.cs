using src.back.Challenge.Domain.Entities;
using src.back.Challenge.Domain.Repositories;
using src.back.Challenge.Infra.Data.Context;

namespace src.back.Challenge.Infra.Data.Repositories
{
    public class InvestmentRulesRepository : BaseRepository<InvestmentRules>
        , IInvestmentRulesRepository
    {
        public InvestmentRulesRepository(ChallengeContext context) : base(context)
        {
        }
    }
}