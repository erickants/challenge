using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.back.Challenge.Domain.Entities;
using src.back.Challenge.Domain.Enums;
using src.back.Challenge.Domain.Repositories;
using src.back.Challenge.Infra.Data.Context;

namespace src.back.Challenge.Infra.Data.Repositories
{
    public class BankAccountRepository : BaseRepository<BankAccount>
        , IBankAccountRepository
    {
        public BankAccountRepository(ChallengeContext context) : base(context)
        {
        }

        public Task<BankAccount> Find(long id)
            => Context.BankAccounts.FirstOrDefaultAsync(p => p.Id == id);

        public Task<BankAccount> FindByBranchAccount(string branch, string accountNumber)
            => Context.BankAccounts.FirstOrDefaultAsync(p => p.Branch == branch && p.AccountNumber == accountNumber);

        public async Task<IEnumerable<BankAccount>> GetByBankAccountType(BankAccountTypes type)
            => await Context.BankAccounts.Where(p => p.Type == type)
                .ToArrayAsync();
    }
}