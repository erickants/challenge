using src.back.Challenge.Domain.Core.Commands;

namespace src.back.Challenge.Domain.Customers.CommandResults
{
    public class FindCustomerCommandResult : CommandResult
    {
        public FindCustomerCommandResult(object data): base(data)
        {
        }
    }
}