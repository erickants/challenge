using System.Collections.Generic;
using System.Threading.Tasks;
using src.back.Challenge.Domain.Core.Repositories;
using src.back.Challenge.Domain.Entities;
using src.back.Challenge.Domain.Enums;

namespace src.back.Challenge.Domain.Repositories
{
    public interface IBankAccountRepository
        : IRepository<BankAccount>
    {
        Task<BankAccount> Find(long id);
        Task<BankAccount> FindByBranchAccount(string branch, string accountNumber);
        Task<IEnumerable<BankAccount>> GetByBankAccountType(BankAccountTypes type);
    }
}