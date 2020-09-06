using System;
using System.Threading.Tasks;

namespace src.back.Challenge.Domain.Core.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Task Begin();
        void Commit();
        void Rollback();
        Task SaveChanges();
    }
}