using System.Threading.Tasks;
using src.back.Challenge.Domain.Core.Repositories;
using src.back.Challenge.Domain.Entities;

namespace src.back.Challenge.Domain.Repositories
{
    public interface ICustomerRepository
        : IRepository<Customer>
    {
        Task<Customer> Find(long id);
    }
}