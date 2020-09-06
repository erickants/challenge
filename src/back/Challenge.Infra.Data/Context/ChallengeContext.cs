using Microsoft.EntityFrameworkCore;
using src.back.Challenge.Domain.Entities;
using src.back.Challenge.Infra.Data.Mappings;

namespace src.back.Challenge.Infra.Data.Context
{
    public class ChallengeContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankAccountStatement> BankAccountStatements { get; set; }
        public DbSet<InvestmentRule> InvestmentRules { get; set; }

        public ChallengeContext(DbContextOptions<ChallengeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().Map();
            modelBuilder.Entity<BankAccount>().Map();
            modelBuilder.Entity<BankAccountStatement>().Map();
            modelBuilder.Entity<InvestmentRule>().Map();
        }
    }
}