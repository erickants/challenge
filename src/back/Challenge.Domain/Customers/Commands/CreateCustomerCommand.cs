using src.back.Challenge.Domain.Core.Commands;
using src.back.Challenge.Domain.Customers.CommandResults;

namespace src.back.Challenge.Domain.Customers.Commands
{
    public class CreateCustomerCommand
        : Command<CreateCustomerCommandResult>
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
    }
}