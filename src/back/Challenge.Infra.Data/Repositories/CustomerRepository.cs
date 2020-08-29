using src.back.Challenge.Domain.Entities;
using src.back.Challenge.Domain.Repositories;
using src.back.Challenge.Infra.Data.Context;

namespace src.back.Challenge.Infra.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
        , ICustomerRepository
    {
        public CustomerRepository(ChallengeContext context) : base(context)
        {
        }
    }
}