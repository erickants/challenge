using System.Collections.Generic;
using src.back.Challenge.Domain.Core.Entities;

namespace src.back.Challenge.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public IEnumerable<BankAccount> BankAccounts { get; set; }
    }
}