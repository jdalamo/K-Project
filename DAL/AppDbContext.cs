using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using fa19projectgroup16.Models;


namespace fa19projectgroup16.DAL
{
    // This class definition references the user class for this project
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Additional Dbsets needed are below
        public DbSet<Dispute> Disputes { get; set; }
        public DbSet<Payee> Payees { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<StandardAccount> StandardAccount { get; set; }
        public DbSet<IRAAccount> IRAAccounts { get; set; }
        public DbSet<StockPortfolio> StockPortfolios { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }

    }
}