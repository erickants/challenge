using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.back.Challenge.Domain.Entities;

namespace src.back.Challenge.Infra.Data.Mappings
{
    public static class BankAccountStatementMapping
    {
        public static void Map(this EntityTypeBuilder<BankAccountStatement> builder)
        {
            builder.ToTable("BankAccountStatement");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Description)
                .HasMaxLength(4000);

            builder.Property(p => p.Type)
                .HasMaxLength(1);

            builder.Property(p => p.Amount)
                .HasColumnType("decimal(14,2)");

            builder.HasOne(p => p.SourceBankAccount)
                .WithMany()
                .HasForeignKey(p => p.SourceBankAccountId);

            
            builder.HasOne(p => p.DestinationBankAccount)
                .WithMany()
                .HasForeignKey(p => p.DestinationBankAccountId);
        }
    }
}