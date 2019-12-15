using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fa19projectgroup16.DAL;
using fa19projectgroup16.Models;

namespace fa19projectgroup16.Utilities
{
    public static class CheckAccounts
    {
        public static bool UserHasAccounts(AppDbContext _context, string name)
        {
            bool hasAccounts = _context.Accounts
                .Include(a => a.AppUser)
                .Where(a => a.AppUser.Email == name).Any();

            return hasAccounts;
        }

        public static bool AccountsHaveTransactions(AppDbContext _context, string name)
        {
            List<Account> accounts = _context.Accounts
                .Include(a => a.Transactions)
                .Include(a => a.AppUser)
                .Where(a => a.AppUser.Email == name).ToList();

            foreach (Account a in accounts)
            {
                if (a.Transactions.Count == 0 || a.Transactions == null)
                {
                    return false;
                }
            }

            return true;
        }

        public static int GetAccountWithoutTransaction(AppDbContext _context, string name)
        {
            List<Account> accounts = _context.Accounts
                .Include(a => a.AppUser)
                .Where(a => a.AppUser.Email == name).ToList();

            foreach (Account a in accounts)
            {
                if (a.Transactions.Count == 0 || a.Transactions == null)
                {
                    return a.AccountID;
                }
            }

            return 0;
        }
    }
}
