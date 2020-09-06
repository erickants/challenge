using System.Threading.Tasks;
using src.back.Challenge.Domain.Core.Commands;
using src.back.Challenge.Domain.Customers.CommandResults;
using src.back.Challenge.Domain.Customers.Commands;
using src.back.Challenge.Domain.Repositories;

namespace src.back.Challenge.Domain.Customers.CommandHandlers
{
    public class FindCustomerCommandHandler
        : CommandHandler
        , ICommandHandler<FindCustomerCommand, FindCustomerCommandResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public FindCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<FindCustomerCommandResult> Handle(FindCustomerCommand input)
        {
            var result = await _customerRepository.Find(input.Id);

            return new FindCustomerCommandResult(result);
        }
    }
}