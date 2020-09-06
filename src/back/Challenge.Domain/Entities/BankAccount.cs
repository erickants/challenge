using src.back.Challenge.Domain.Core.Entities;
using src.back.Challenge.Domain.Enums;

namespace src.back.Challenge.Domain.Entities
{
    public class BankAccount : BaseEntity
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Branch { get; set; }
        public string AccountNumber { get; set; }
        public BankAccountTypes Type { get; set; }
        public decimal Balance { get; private set; }

        public void AddAmount(decimal amount)
            => Balance += amount;
    }
}