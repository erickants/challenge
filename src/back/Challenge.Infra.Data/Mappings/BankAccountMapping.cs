using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.back.Challenge.Domain.Entities;

namespace src.back.Challenge.Infra.Data.Mappings
{
    public static class BankAccountMapping
    {
        public static void Map(this EntityTypeBuilder<BankAccount> builder)
        {
            builder.ToTable("BankAccount");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Branch)
                .HasMaxLength(10);

            builder.Property(p => p.AccountNumber)
                .HasMaxLength(50);
            
            builder.HasIndex(p => p.AccountNumber)
                .IsUnique();

            builder.Property(p => p.Type)
                .HasMaxLength(1);

            builder.Property(p => p.Balance)
                .HasColumnType("decimal(14,2)");
            
            builder.HasOne(p => p.Customer)
                .WithMany(p => p.BankAccounts)
                .HasForeignKey(p => p.CustomerId);
        }
    }
}