using System.Collections.Generic;
using System.Threading.Tasks;
using src.back.Challenge.Domain.Core.Repositories;
using src.back.Challenge.Infra.Data.Context;

namespace src.back.Challenge.Infra.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
        protected readonly ChallengeContext Context;
        private bool _skipSaveChanges;

        public BaseRepository(ChallengeContext context)
        {
            Context = context;
            _skipSaveChanges = false;
        }

        public Task Add(T entity)
            => AddRange(new[] { entity });

        public Task AddRange(IEnumerable<T> centrosDeCusto)
        {
            Context.Set<T>().AddRange(centrosDeCusto);

            return SaveChanges();
        }

        public Task Remove(T entity)
        {
            Context.Set<T>().Remove(entity);

            return SaveChanges();
        }

        public Task RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);

            return SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            if (_skipSaveChanges) return 0;

            return await Context.SaveChangesAsync();
        }

        public void SkipSaveChanges(bool skip = true)
        {
            _skipSaveChanges = skip;
        }

        public Task Update(T entity)
        {
            Context.Set<T>().Update(entity);

            return SaveChanges();
        }

        public Task UpdateRange(IEnumerable<T> objs)
        {
            Context.Set<T>().UpdateRange(objs);

            return SaveChanges();
        }
    }
}