using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fa19projectgroup16.DAL;
using fa19projectgroup16.Models;
using fa19projectgroup16.Utilities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using fa19projectgroup16.Models.ViewModels;
using System.Collections;

namespace fa19projectgroup16.Controllers
{
    public class StandardAccountsController : Controller
    {
        private readonly AppDbContext _context;

        public StandardAccountsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StandardAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.StandardAccount.ToListAsync());
        }

        // GET: StandardAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StandardAccount standardAccount = await _context.StandardAccount
                .Include(t => t.Transactions)
                .Include(a => a.AppUser)
                .FirstOrDefaultAsync(m => m.AccountID == id);

            if (standardAccount == null)
            {
                return NotFound();
            }

            return View(standardAccount);
        }

        // POST: StandardAccounts/Create
        public async Task<IActionResult> Create(string accountType)
        {
            StandardAccount standardAccount = new StandardAccount();
            AppUser appUser = _context.Users.FirstOrDefault(a => a.Email == User.Identity.Name);
            standardAccount.AppUser = appUser;

            standardAccount.Balance = 0;
            standardAccount.Is_Active = true;
            if (accountType == "Checkings")
            {
                standardAccount.AccountType = AccountType.Checking;
                standardAccount.AccountName = "Longhorn Checking";
            }
            else
            {
                standardAccount.AccountType = AccountType.Savings;
                standardAccount.AccountName = "Longhorn Savings";
            }
            standardAccount.AccountNumber = Utilities.GenerateAccountNumber.GetNextAccountNumber(_context);
            standardAccount.Date = new DateTime();


            if (ModelState.IsValid)
            {
                _context.Add(standardAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction("Deposit", "Transactions", new { accountID = standardAccount.AccountID });
            }
            return View(standardAccount);
        }

        // GET: StandardAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standardAccount = await _context.StandardAccount.FindAsync(id);
            if (standardAccount == null)
            {
                return NotFound();
            }
            return View(standardAccount);
        }

        // POST: StandardAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountID,AccountName")] StandardAccount standardAccount)
        {
            if (id != standardAccount.AccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Account DBAcc = _context.Accounts.Find(standardAccount.AccountID);
                    DBAcc.AccountName = standardAccount.AccountName;
                    _context.Update(DBAcc);
                    await _context.SaveChangesAsync();

                    /*_context.Update(standardAccount);
                    await _context.SaveChangesAsync();*/
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StandardAccountExists(standardAccount.AccountID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Accounts");
            }
            return View(standardAccount);
        }

        // GET: StandardAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standardAccount = await _context.StandardAccount
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (standardAccount == null)
            {
                return NotFound();
            }

            return View(standardAccount);
        }

        // POST: StandardAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var standardAccount = await _context.StandardAccount.FindAsync(id);
            _context.StandardAccount.Remove(standardAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Accounts");
        }

        private bool StandardAccountExists(int id)
        {
            return _context.StandardAccount.Any(e => e.AccountID == id);
        }

        // Kevin doesn't see this as necessary, but we shall see
        private IList GetAllTransactions(int accountID)
        {
            List<Transaction> transactionList = _context.Transactions.Where(t => t.Account.AccountID == accountID).ToList();

            /*Transaction SelectNone = new Transaction() { TransactionID = 0, Description = "All Transactions" };
            transactionList.Add(SelectNone);

            SelectList transactionSelectList = new SelectList(transactionList.OrderBy(m => m.TransactionID), "TransactionID", "Trasaction Type");*/

            return transactionList;
        }

        /*// Kevin commented out a lot of stuff
        public IActionResult SearchTransactions(int accountID)
        {
            *//*ViewBag.AllTransactions = GetAllTransactions();*//*   //Kevin says this only needs to be done if going to drop down which it is not    


            //List<Transaction> transactionList = _context.Transactions.Where(t => t.Account.AccountID == accountID).ToList();     Kevin did this for fun I guess, it's late

            SearchViewModel svm = new SearchViewModel();
            //svm.DateSelection = DateSelectionType.AllAvailable;        //to be uncommented when migration and radio buttons present

            return View(svm);



        }


        public IActionResult DisplaySearchResults(SearchViewModel svm, int accountID)
        {

            var query = from t in _context.Transactions                         // this pops up with 0 results???
                                            select t;
            *//*var query = from t in _context.Transactions
                        where *//*

            //query = query.Where(t => t.Account.AccountID == accountID);             //new to insert account id... maybe... accountID is null/has nothing in it, so welp

            if (!string.IsNullOrEmpty(svm.SearchDescription))
            {
                query = query.Where(t => t.Description.Contains(svm.SearchDescription));
            }

            if (!string.IsNullOrEmpty(svm.SelectedTransactionNumber))
            {
                query = query.Where(t => t.TransactionID.ToString() == svm.SelectedTransactionNumber);
            }

            if (svm.SearchType != Models.ViewModels.TransactionType.All)
            {
                query = query.Where(t => t.TransactionType.ToString() == svm.SearchType.ToString());
            }

           *//* if (svm.SearchPrice != null)
            {
                TryValidateModel(svm);
                if (ModelState.IsValid == false)
                {
                    ViewBag.PriceMessage = svm.SearchPrice + " is not a valid number. Please try again.";
                    return View("DetailedSearch", svm);
                }

                switch (svm.SearchAmount)
                {
                    case Amount.ZeroToHundred:
                        query = query.Where(t => (svm.SearchPrice) >=0 || (svm.SearchPrice)<=100);
                        break;
                    case Amount.HundredToTwoHundred:
                        query = query.Where(t => (svm.SearchPrice) >= 100 || (svm.SearchPrice) <= 200);
                        break;
                    case Amount.TwoHundredToThreeHundred:
                        query = query.Where(t => (svm.SearchPrice) >=200 || (svm.SearchPrice) <=300);
                        break;
                    case Amount.ThreeHundredPlus:
                        query = query.Where(t => (svm.SearchPrice) >= 300);
                        break;
                    case Amount.Custom:
                        query = query.Where(t => t.Amount == (svm.SearchPrice));
                        break;
                    default:
                        break;

                }

            }*//*

            if (svm.SelectedDate != null)
            {
                query = query.Where(t => t.Date >= (svm.SelectedDate));
            }

            List<Transaction> SelectedTransactions = query.ToList();

            ViewBag.AllTransactionsCount = _context.Transactions.Where(t => t.Account.AccountID == accountID).Count();
            ViewBag.SelectedTransactionsCount = SelectedTransactions.Count();



            *//*StandardAccount standardAccount = await _context.StandardAccount
                .Include(t => t.Transactions.Equals(SelectedTransactions))                           // This chunk of code is causing the errors
                .Include(a => a.AppUser)
                .FirstOrDefaultAsync(m => m.AccountID == accountID);*//*

            //return View("Details", standardAccount);

            return RedirectToAction("Index", "Transactions", SelectedTransactions);

            //return View("Details", SelectedTransactions.OrderByDescending(t => t.Amount));
        }*/
    }
}
