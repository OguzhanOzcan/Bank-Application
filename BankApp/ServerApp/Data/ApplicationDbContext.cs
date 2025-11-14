using ServerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ServerApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<ResetCode> ResetCodes { get; set; }
        public DbSet<InterestRate> InterestRates { get; set; }
        public DbSet<CreditApplication> CreditApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CreditApplication>().ToTable("CreditApplication");
            modelBuilder.Entity<CreditApplication>().HasKey(ca => ca.ApplicationId);
            
            modelBuilder.Entity<CreditApplication>(entity =>
            {
                entity.ToTable("CreditApplication");
                entity.HasKey(e => e.ApplicationId);

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.InstallmentAmount)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.InterestRate)
                    .HasColumnType("decimal(5,2)"); 
            });

            modelBuilder.Entity<Customer>().ToTable("Customer");

            modelBuilder.Entity<Message>()
                .ToTable("Messages")
                .HasOne(m => m.Customer)
                .WithMany()
                .HasForeignKey(m => m.MessageSender)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ResetCode>()
                .ToTable("ResetCodes")
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bank>().ToTable("Bank");
            modelBuilder.Entity<Bank>().HasKey(b => b.BankId);

            modelBuilder.Entity<LoanType>().ToTable("LoanType");
            modelBuilder.Entity<LoanType>().HasKey(lt => lt.LoanTypeId);

            modelBuilder.Entity<InterestRate>()
                .ToTable("InterestRate")
                .HasKey(i => i.RateId);

            modelBuilder.Entity<InterestRate>()
                .Property(i => i.Rate)
                .HasColumnName("InterestRate")
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<InterestRate>()
                .HasOne(i => i.Bank)
                .WithMany(b => b.InterestRates)
                .HasForeignKey(i => i.BankId);

            modelBuilder.Entity<InterestRate>()
                .HasOne(i => i.LoanType)
                .WithMany(l => l.InterestRates)
                .HasForeignKey(i => i.LoanTypeId);

            modelBuilder.Entity<Balance>()
                .ToTable("Balance")
                .HasKey(b => b.BalanceId);

            modelBuilder.Entity<Balance>()
                .Property(b => b.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Balance>()
                .HasOne(b => b.Customer)
                .WithMany() 
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
