using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.back.Challenge.Domain.Entities;
using src.back.Challenge.Domain.Repositories;
using src.back.Challenge.Infra.Data.Context;

namespace src.back.Challenge.Infra.Data.Repositories
{
    public class BankAccountStatementRepository : BaseRepository<BankAccountStatement>
        , IBankAccountStatementRepository
    {
        public BankAccountStatementRepository(ChallengeContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BankAccountStatement>> List(long bankAccountId)
            => await Context.BankAccountStatements.Where(p => p.SourceBankAccountId == bankAccountId
                || p.DestinationBankAccountId == bankAccountId).ToArrayAsync();
    }
}