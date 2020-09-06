using System.Threading.Tasks;
using src.back.Challenge.Domain.Core.Commands;
using src.back.Challenge.Domain.Customers.CommandResults;
using src.back.Challenge.Domain.Customers.Commands;
using src.back.Challenge.Domain.Entities;
using src.back.Challenge.Domain.Repositories;

namespace src.back.Challenge.Domain.Customers.CommandHandlers
{
    public class CreateCustomerCommandHandler
        : CommandHandler
        , ICommandHandler<CreateCustomerCommand, CreateCustomerCommandResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CreateCustomerCommandResult> Handle(CreateCustomerCommand input)
        {
            var customer = new Customer
            {
                Name = input.Name,
                Cpf = input.Cpf
            };

            await _customerRepository.Add(customer);
            
            return new CreateCustomerCommandResult();
        }
    }
}