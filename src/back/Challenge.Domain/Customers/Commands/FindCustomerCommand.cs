using src.back.Challenge.Domain.Core.Commands;
using src.back.Challenge.Domain.Customers.CommandResults;

namespace src.back.Challenge.Domain.Customers.Commands
{
    public class FindCustomerCommand
        : Command<FindCustomerCommandResult>
    {
        public long Id { get; set; }
    }
}