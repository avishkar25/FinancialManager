using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinancialManager.Models;

namespace FinancialManager.Data
{
    public class FinancialManagerContext : IdentityDbContext<FinancialManagerUser>
    {
        public FinancialManagerContext(DbContextOptions<FinancialManagerContext> options)
            : base(options)
        {
        }

        // ✅ Add a parameterless constructor for EF Core
        public FinancialManagerContext() { }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Asset> Assets { get; set; }
    }
}
