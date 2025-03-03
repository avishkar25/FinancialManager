using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinancialManager.Models; // Ensure this namespace is correct

namespace FinancialManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<FinancialManagerUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Asset> Assets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Specify decimal precision
            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Debt>()
                .Property(d => d.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Asset>()
                .Property(a => a.Value)
                .HasPrecision(18, 2);
        }
    }
}
