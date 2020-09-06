using System.Collections.Generic;
using System.Threading.Tasks;
using src.back.Challenge.Domain.Core.Repositories;
using src.back.Challenge.Domain.Entities;

namespace src.back.Challenge.Domain.Repositories
{
    public interface IBankAccountStatementRepository
        : IRepository<BankAccountStatement>
    {
        Task<IEnumerable<BankAccountStatement>> List(long bankAccountId);
    }
}