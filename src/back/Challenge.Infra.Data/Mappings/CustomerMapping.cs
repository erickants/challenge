using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using src.back.Challenge.Domain.Entities;

namespace src.back.Challenge.Infra.Data.Mappings
{
    public static class CustomerMapping
    {
        public static void Map(this EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .HasMaxLength(300);

            builder.Property(p => p.Cpf)
                .HasMaxLength(11);
        }
    }
}