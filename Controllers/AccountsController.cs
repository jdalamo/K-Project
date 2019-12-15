using System;
using System.Collections.Generic;
using System.Linq;
using fa19projectgroup16.DAL;
using fa19projectgroup16.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fa19projectgroup16.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace fa19projectgroup16.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly AppDbContext _context;

        public AccountsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Manager") || User.IsInRole("Employee"))
            {
                return RedirectToAction("Index", "ManageUsers");
            }

            ViewBag.StockPortfolioTotalBalance = GetTotalStockBalance();

            if (Utilities.CheckAccounts.UserHasAccounts(_context, User.Identity.Name) == false)
            {
                return RedirectToAction("Selector", "Accounts");
            }

            if (Utilities.CheckAccounts.AccountsHaveTransactions(_context, User.Identity.Name) == false)
            {
                int accountID = Utilities.CheckAccounts.GetAccountWithoutTransaction(_context, User.Identity.Name);
                return RedirectToAction("Deposit", "Transactions", new { accountID });
            }

            StockPortfolio portfolio = _context.StockPortfolios
                .Include(p => p.AppUser)
                .FirstOrDefault(p => p.AppUser.Email == User.Identity.Name);

            //ViewBag.AccountNum = portfolio.AccountNumberLastFour;

            List<Account> accounts = new List<Account>();
            accounts = _context.Accounts.Include(a => a.AppUser).Where(a => a.AppUser.Email == User.Identity.Name).ToList();

            Int32 numOverdraftAccounts = HasOverdraft();

            if (numOverdraftAccounts > 0)
            {
                ViewBag.Error = "You have overdraft account. Please fix this. Or else...";
            }

            AppUser user = _context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            if (user.Is_enabled == true)
            {
                ViewBag.Enabled = true;
            }
            else
            {
                ViewBag.Enabled = false;
            }

            /*else
            {
                ViewBag.HasOverdraft = null;
            }

            return ViewBag.HasOverdraft; 


             ViewBag.HasOverdraft = HasOverdraft();

            if (ViewBag.HasOverdraft = "True")
            {
                ViewBag.Error = "You have overdraft account. Please fix this. Or else...";
            }*/
            /*else
            {
                ViewBag.Error = null;
            }*/

            ViewBag.hasIRA = HasIRA(accounts);
            ViewBag.Younger = Younger();
            ViewBag.hasStockPortfolio = HasStockPortfolio(accounts);

            return View(accounts);
        }

        [HttpPost]
        public IActionResult Index(string accountType, string transactionType)
        {
           

            if (accountType != null)
            {
                if (accountType == "Checkings" || accountType == "Savings")
                {
                    return RedirectToAction("Create", "StandardAccounts", new { accountType = accountType });
                }
                else if (accountType == "IRA")
                {
                    return RedirectToAction("Create", "IRAAccounts");
                }
                else
                {
                    return RedirectToAction("Create", "StockPortfolios");
                }
            
            }

            if (transactionType != null)
            {
                if (transactionType == "Deposit")
                {
                    return RedirectToAction("Deposit", "Transactions");
                }
                else if (transactionType == "Withdrawal")
                {
                    return RedirectToAction("Withdrawal", "Transactions");
                }
                else if (transactionType == "Transfer")
                {
                    return RedirectToAction("Transfer", "Transactions");
                }
                else
                {
                    return RedirectToAction("Payment", "Transactions");
                }
            }
            return View();
        }

        //GET: Accounts/Selector
        public IActionResult Selector()
        {
            AppUser user = _context.Users.FirstOrDefault(a => a.Email == User.Identity.Name);

            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(user.Birthday).Ticks).Year - 1;

            if (Years >= 70)
            {
                ViewBag.Age = "Old";
            }
            else
            {
                ViewBag.Age = "Young";
            }

            return View();
        }


        //POST: Accounts/AccountSelector
        [HttpPost]
        public IActionResult Selector(string accountType)
        {
            if (accountType == "Checkings" || accountType == "Savings")
            {
                return RedirectToAction("Create", "StandardAccounts", new { accountType = accountType });
            }
            else if (accountType == "IRA")
            {
                return RedirectToAction("Create", "IRAAccounts");
            }
            else
            {
                return RedirectToAction("Create", "StockPortfolios");
            }
        }

        private Boolean HasIRA(List<Account> accounts)
        {
            foreach (Account a in accounts)
            {
                if (a.AccountType == AccountType.IRA)
                {
                    return true;
                }
            }

            return false;
        }

        private Boolean HasStockPortfolio(List<Account> accounts)
        {
            foreach (Account a in accounts)
            {
                if (a.AccountType == AccountType.Stock)
                {
                    return true;
                }
            }

            return false;
        }

        private Decimal GetTotalStockBalance()
        {
            StockPortfolio portfolio = _context.StockPortfolios
                .Include(p => p.StockTransactions)
                .ThenInclude(st => st.Stock)
                .Include(p => p.AppUser)
                .Where(p => p.AppUser.Email == User.Identity.Name)
                .FirstOrDefault();

            if (portfolio != null)
            {
                Decimal stockBalance = 0m;
                foreach (StockTransaction st in portfolio.StockTransactions)
                {
                    Stock stock = _context.Stocks
                        .FirstOrDefault(s => s.StockID == st.Stock.StockID);

                    stockBalance += st.NumberOfShares * stock.StockPrice;
                }

                return stockBalance + portfolio.Balance;
            }
            else
            {
                return -1m;
            }
        }

        private Int32 HasOverdraft()
        {

            List<Account> accountList = _context.Accounts.Where(a => a.AppUser.Email == User.Identity.Name).ToList();

            Int32 numOverdraftAccounts = 0;

            foreach (Account a in accountList)
            {
                if (a.Balance < 0)
                {
                    numOverdraftAccounts += 1;
                }
            }

            return numOverdraftAccounts;

/*            if (numOverdraftAccounts > 1)
            {
                ViewBag.HasOverdraft = "True";
            }
            else
            {
                ViewBag.HasOverdraft = null;
            }

            return ViewBag.HasOverdraft;*/

        }

        public bool Younger()
        {
            AppUser appUser = _context.Users.FirstOrDefault(a => a.Email == User.Identity.Name);

            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(appUser.Birthday).Ticks).Year - 1;

            if (Years < 70)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}