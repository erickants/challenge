using System;
using src.back.Challenge.Domain.Core.Entities;
using src.back.Challenge.Domain.Enums;

namespace src.back.Challenge.Domain.Entities
{
    public class BankAccountStatement : BaseEntity
    {
        public long Id { get; set; }
        public long? SourceBankAccountId { get; set; }
        public BankAccount SourceBankAccount { get; set; }
        public long DestinationBankAccountId { get; set; }
        public BankAccount DestinationBankAccount { get; set; }
        public string Description { get; set; }
        public StatementTypes Type { get; set; }
        public decimal Amount { get; set; }
    }
}