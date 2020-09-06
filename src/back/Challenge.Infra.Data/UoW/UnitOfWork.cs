using System.Threading.Tasks;
using src.back.Challenge.Domain.Core.UoW;
using src.back.Challenge.Infra.Data.Context;

namespace src.back.Challenge.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChallengeContext _challengeContext;

        public UnitOfWork(ChallengeContext challengeContext) =>
            _challengeContext = challengeContext;

        public async Task Begin() =>
            await _challengeContext.Database.BeginTransactionAsync();

        public void Commit() =>
            _challengeContext.Database.CommitTransaction();

        public void Rollback() =>
            _challengeContext.Database.RollbackTransaction();

        public void Dispose() =>
            _challengeContext.Dispose();

        public async Task SaveChanges() => await _challengeContext.SaveChangesAsync();
    }
}