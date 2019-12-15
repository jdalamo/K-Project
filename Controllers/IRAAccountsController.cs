using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fa19projectgroup16.DAL;
using fa19projectgroup16.Models;
using fa19projectgroup16.Utilities;
using System.Collections.Generic;
using fa19projectgroup16.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace fa19projectgroup16.Controllers
{
    public class IRAAccountsController : Controller
    {
        private readonly AppDbContext _context;

        public IRAAccountsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: IRAAccounts
        public async Task<IActionResult> Index()
        {
            if (Utilities.CheckAccounts.UserHasAccounts(_context, User.Identity.Name) == false)
            {
                return RedirectToAction("Selector", "Accounts");
            }

            if (Utilities.CheckAccounts.AccountsHaveTransactions(_context, User.Identity.Name) == false)
            {
                int accountID = Utilities.CheckAccounts.GetAccountWithoutTransaction(_context, User.Identity.Name);
                return RedirectToAction("Deposit", "Transactions", new { accountID });
            }

            return View(await _context.IRAAccounts.ToListAsync());
        }

        // GET: IRAAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var IRAAccount = await _context.IRAAccounts
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (IRAAccount == null)
            {
                return NotFound();
            }

            return View(IRAAccount);
        }

        // GET: IRAAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IRAAccounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string AccountName)
        {
            IRAAccount IRAAccount = new IRAAccount();
            AppUser appUser = _context.Users.FirstOrDefault(a => a.Email == User.Identity.Name);
            IRAAccount.AppUser = appUser;

            IRAAccount.Balance = 0;
            
            IRAAccount.AccountType = AccountType.IRA;
            IRAAccount.AccountName = AccountName;
            IRAAccount.Is_Active = true;
            
            IRAAccount.AccountNumber = Utilities.GenerateAccountNumber.GetNextAccountNumber(_context);
            IRAAccount.Date = DateTime.Now;


            if (ModelState.IsValid)
            {
                _context.Add(IRAAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Accounts", new { accountID = IRAAccount.AccountID });
            }
            return View(IRAAccount);
        }

        
        /*// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountID,Balance,AccountName,AccountType,AccountNumber,Customer,Date")] IRAAccount IRAAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(IRAAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(IRAAccount);
        }*/

        // GET: IRAAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var IRAAccount = await _context.IRAAccounts.FindAsync(id);
            if (IRAAccount == null)
            {
                return NotFound();
            }
            return View(IRAAccount);
        }

        // POST: IRAAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountID,Balance,AccountName,AccountType,AccountNumber,Customer,Date")] IRAAccount IRAAccount)
        {
            if (id != IRAAccount.AccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Account DBAcc = _context.Accounts.Find(IRAAccount.AccountID);
                    DBAcc.AccountName = IRAAccount.AccountName;
                    _context.Update(DBAcc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IRAAccountExists(IRAAccount.AccountID))
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
            return View(IRAAccount);
        }

        // GET: IRAAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var IRAAccount = await _context.IRAAccounts
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (IRAAccount == null)
            {
                return NotFound();
            }

            return View(IRAAccount);
        }

        // POST: IRAAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var IRAAccount = await _context.IRAAccounts.FindAsync(id);
            _context.IRAAccounts.Remove(IRAAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IRAAccountExists(int id)
        {
            return _context.IRAAccounts.Any(e => e.AccountID == id);
        }

        //private SelectList GetAllTransactions()
        //{
        //    List<Transaction> transactionList = _context.Transactions.ToList();

        //    Transaction SelectNone = new Transaction() { TransactionID = 0, Description = "All Transactions" };
        //    transactionList.Add(SelectNone);

        //    SelectList transactionSelectList = new SelectList(transactionList.OrderBy(m => m.TransactionID), "TransactionID", "Trasaction Type");

        //    return transactionSelectList;
        //}

        //public IActionResult SearchTransactions()
        //{
        //    ViewBag.AllTransactions = GetAllTransactions();
        //    SearchViewModel svm = new SearchViewModel();

        //    return View(svm);

        //}

        //public IActionResult DisplaySearchResults(SearchViewModel svm)
        //{

        //    var query = from t in _context.Transactions
        //                select t;

        //    if (!string.IsNullOrEmpty(svm.SearchDescription))
        //    {
        //        query = query.Where(t => t.Description.Contains(svm.SearchDescription));
        //    }

        //    if (!string.IsNullOrEmpty(svm.SelectedTransactionNumber))
        //    {
        //        query = query.Where(t => t.TransactionID.ToString().Contains(svm.SearchDescription));
        //    }

        //    if (svm.SearchPrice != null)
        //    {
        //        TryValidateModel(svm);
        //        if (ModelState.IsValid == false)
        //        {
        //            ViewBag.PriceMessage = svm.SearchPrice + " is not a valid number. Please try again.";
        //            return View("DetailedSearch", svm);
        //        }

        //        switch (svm.SearchAmount)
        //        {
        //            case Amount.ZeroToHundred:
        //                query = query.Where(t => (svm.SearchPrice) >= 0 || (svm.SearchPrice) <= 100);
        //                break;
        //            case Amount.TwoHundredToThreeHundred:
        //                query = query.Where(t => (svm.SearchPrice) >= 100 || (svm.SearchPrice) <= 0);
        //                break;
        //            case Amount.ThreeHundredPlus:
        //                query = query.Where(t => (svm.SearchPrice) >= 300);
        //                break;
        //            case Amount.Custom:
        //                query = query.Where(t => t.Amount == (svm.SearchPrice));
        //                break;
        //            default:
        //                break;

        //        }

        //    }

        //    if (svm.SelectedDate != null)
        //    {
        //        query = query.Where(t => t.Date >= (svm.SelectedDate));
        //    }


        //    List<Transaction> SelectedTransactions = query.ToList();

        //    ViewBag.AllTransactionsCount = _context.Transactions.Count();
        //    ViewBag.SelectedTransactionsCount = SelectedTransactions.Count();

        //    return View("Details", SelectedTransactions.OrderByDescending(t => t.Amount));

        //}
    }
}

