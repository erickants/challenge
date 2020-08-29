using src.back.Challenge.Domain.Core.Entities;
using src.back.Challenge.Domain.Enums;

namespace src.back.Challenge.Domain.Entities
{
    public class InvestmentRules : BaseEntity
    {
        public int Id { get; set; }
        public decimal IncomePercentual { get; set; }
        public BankAccountTypes BankAccountType { get; set; }
    }
}