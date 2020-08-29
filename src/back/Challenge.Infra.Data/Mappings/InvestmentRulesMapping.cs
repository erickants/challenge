using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.back.Challenge.Domain.Entities;

namespace src.back.Challenge.Infra.Data.Mappings
{
    public static class InvestmentRulesMapping
    {
        public static void Map(this EntityTypeBuilder<InvestmentRules> builder)
        {
            builder.ToTable("InvestmentRules");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IncomePercentual)
                .HasColumnType("decimal(4,2)");

            builder.Property(p => p.BankAccountType)
                .HasMaxLength(1);
        }
    }
}