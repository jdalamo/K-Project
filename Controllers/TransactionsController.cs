using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fa19projectgroup16.Utilities;
using fa19projectgroup16.DAL;
using fa19projectgroup16.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using fa19projectgroup16.Models.ViewModels;

namespace fa19projectgroup16.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public TransactionsController(AppDbContext context, IServiceProvider service)
        {
            _context = context;
            _userManager = service.GetRequiredService<UserManager<AppUser>>();
        }

        // GET: Transactions
        public IActionResult Index()
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

            List<Transaction> SelectedTransactions = new List<Transaction>();
            if (User.IsInRole("Manager") || User.IsInRole("Employee"))
            {
                SelectedTransactions = _context.Transactions
                    .Include(d => d.Disputes).ToList();
            }
            else //user is customer
            {
                SelectedTransactions = _context.Transactions.
                    Include(a => a.Account).
                    ThenInclude(a => a.AppUser).Where(a => a.Account.AppUser.Email == User.Identity.Name).ToList();
            }

			ViewBag.AllTransactionsCount = _context.Transactions.Count();
			ViewBag.SelectedTransactionsCount = SelectedTransactions.Count();

            AppUser user = _context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            if (user.Is_enabled == true)
            {
                ViewBag.Enabled = true;
            }
            else
            {
                ViewBag.Enabled = false;
            }

            return View(SelectedTransactions);
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(d => d.Disputes)
                .Include(a => a.Account)
                .Include(p => p.Payee)
                .FirstOrDefaultAsync(m => m.TransactionID == id);

            if (transaction == null)
            {
                return NotFound();
            }

            if (transaction.TransactionStatus == TransactionStatus.Pending)
            {
                ViewBag.Pending = true;
            }
            else
            {
                ViewBag.Pending = false;
            }

            ViewBag.FiveSimilar = FiveSimilar(transaction);

            ViewBag.numDisputes = transaction.Disputes.Count();

          
            if (transaction.TransactionType == TransactionType.Payment)
            {
                ViewBag.transactionType = "Payment";
            }
            else
            {
                ViewBag.transactionType = null;
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


            /* if (TransactionType == TransactionType.Payment)
            {
                ViewBag.TransactionType = "Payment";
            }*/


            return View(transaction);
        }

        //GET: Transactions/Deposit
        public IActionResult Deposit(int? accountID)
        {
            Transaction transaction = new Transaction();
            transaction.Date = DateTime.Now;

            if (accountID == null)
            {
                ViewBag.accountID = null;
                ViewBag.accountName = null;
                ViewBag.accountNumber = null;
            }
            else
            {
                Account account = _context.Accounts.FirstOrDefault(a => a.AccountID == accountID);
                ViewBag.accountName = account.AccountName;
                ViewBag.accountNumber = account.AccountNumber;
                ViewBag.accountID = accountID;
            }

            ViewBag.AllAccounts = GetAllAccounts();

            ViewBag.Error = null;
            ViewBag.MaxContribution = null;

            return View(transaction);
        }

        //POST: Transactions/Deposit
        [HttpPost]
        public async Task<IActionResult> Deposit([Bind("TransactionID,Amount,Date,Description,Comment")] Transaction transaction, Int32 SelectedAccount)
        {
            Account account = _context.Accounts.FirstOrDefault(a => a.AccountID == SelectedAccount);
            transaction.Account = account;

            transaction.TransactionType = TransactionType.Deposit;

            AppUser appUser = _context.Users.FirstOrDefault(a => a.Email == User.Identity.Name);

            if (transaction.Amount <= 0)
            {
                ViewBag.AllAccounts = GetAllAccounts();
                ViewBag.Error = "Invalid deposit amount. Please try again.";
                return View(transaction);
            }

            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(appUser.Birthday).Ticks).Year - 1;

            if (account.AccountType == AccountType.IRA)
            {
                IRAAccount destAccount = _context.IRAAccounts
                        .FirstOrDefault(a => a.AccountID == SelectedAccount);
                if (Years < 70)
                {
                    Decimal possContribution = destAccount.ContributionAmount + transaction.Amount;

                    if (possContribution <= 5000)
                    {
                        destAccount.ContributionAmount += transaction.Amount;
                    }
                    else
                    {
                        int accountNumber = destAccount.AccountNumber;
                        ViewBag.AllAccounts = GetAllAccounts();
                        ViewBag.Error = "This is an IRA account. You have contributed too much.";
                        ViewBag.MaxContribution = GetMaxContribution(accountNumber);
                        return View(transaction);
                    }
                }
                else
                {
                    int accountNumber = destAccount.AccountNumber;
                    ViewBag.AllAccounts = GetAllAccounts();
                    ViewBag.Error = "This is an IRA account. You must be younger than 70 to deposit in this account.";
                    ViewBag.MaxContribution = null;
                    return View(transaction);
                }
            }

            if (transaction.Amount > 5000)
            {
                transaction.TransactionStatus = TransactionStatus.Pending;
            }
            else
            {
                transaction.TransactionStatus = TransactionStatus.Accepted;

                account.Deposit(transaction.Amount);
            }

            _context.Add(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Accounts");
        }

        //GET: Transactions/Withdrawal
        public IActionResult Withdrawal()
        {
            Transaction transaction = new Transaction();
                transaction.Date = DateTime.Now;

                ViewBag.AllAccounts = GetAllAccounts();

                return View(transaction);
        }

        //POST: Transaction/Withdrawal
        [HttpPost]
        public async Task<IActionResult> Withdrawal([Bind("TransactionID,Amount,Date,Description,Comment")] Transaction transaction, Int32 SelectedAccount)
        {
            Account account = _context.Accounts.FirstOrDefault(a => a.AccountID == SelectedAccount);
            transaction.Account = account;

            transaction.TransactionType = TransactionType.Withdrawal;

            AppUser appUser = _context.Users.FirstOrDefault(a => a.Email == User.Identity.Name);

            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(appUser.Birthday).Ticks).Year - 1;

            if (account.AccountType == AccountType.IRA)
            {
                if (Years < 65)
                {
                    if (transaction.Amount > 3000)
                    {
                        ViewBag.AllAccounts = GetAllAccounts();
                        ViewBag.Error = "This distribution is unqualified. Max withdrawal including a $30 fee is $3000";
                        return View(transaction);
                    }
                    else
                    {
                        transaction.TransactionStatus = TransactionStatus.Accepted;
                        account.Withdraw(transaction.Amount);

                        _context.Add(transaction);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("FeeCreate", "Transactions", new { transactionID = transaction.TransactionID });
                    }
                }
            }

            if (account.Balance < 0)
            {
                ViewBag.AllAccounts = GetAllAccounts();
                ViewBag.Error = "This account is overdrafted. Deposit more money. We like money.";
                return View(transaction);
            }

            transaction.TransactionStatus = TransactionStatus.Accepted;
            account.Withdraw(transaction.Amount);
            _context.Add(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET: Transactions/Transfer
        public IActionResult Transfer()
        {
            Transaction transaction = new Transaction();
            transaction.Date = DateTime.Now;

            ViewBag.AllAccounts = GetAllAccounts();

            return View(transaction);
        }

        //POST: Transactions/Transfer
        [HttpPost]
        public async Task<IActionResult> Transfer([Bind("TransactionID,Amount,Date,Description,Comment")] Transaction transactionTo, Transaction transactionFrom, Int32 SelectedAccountFrom, Int32 SelectedAccountTo)
        {
            Account accountFrom = _context.Accounts.FirstOrDefault(a => a.AccountID == SelectedAccountFrom);
            transactionFrom.Account = accountFrom;

            Account accountTo = _context.Accounts.FirstOrDefault(a => a.AccountID == SelectedAccountTo);
            transactionTo.Account = accountTo;

            transactionFrom.TransactionType = TransactionType.Transfer;
            transactionTo.TransactionType = TransactionType.Transfer;

            AppUser appUser = _context.Users.FirstOrDefault(a => a.Email == User.Identity.Name);

            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(appUser.Birthday).Ticks).Year - 1;

            if (accountFrom.AccountType == AccountType.IRA)
            {
                if (Years < 65)
                {
                    if (transactionFrom.Amount > 3000)
                    {
                        ViewBag.AllAccounts = GetAllAccounts();
                        ViewBag.Error = "This distribution is unqualified. Max withdrawal including a $30 fee is $3000";
                        return View(transactionFrom);
                    }
                    else
                    {
                        transactionFrom.TransactionStatus = TransactionStatus.Accepted;
                        accountFrom.Withdraw(transactionFrom.Amount);
                        accountTo.Deposit(transactionTo.Amount);

                     

                        _context.Add(transactionFrom);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("FeeCreate", "Transactions", new { transactionID = transactionFrom.TransactionID });
                    }
                }
            }

            if (accountTo.AccountType == AccountType.IRA)
            {
                if (Years < 70)
                {
                    IRAAccount destAccount = _context.IRAAccounts
                        .FirstOrDefault(a => a.AccountID == SelectedAccountTo);

                    Decimal possContribution = destAccount.ContributionAmount + transactionTo.Amount;

                    if (possContribution <= 5000)
                    {
                        destAccount.ContributionAmount += transactionTo.Amount;
                    }
                    else
                    {
                        int accountNumber = destAccount.AccountNumber;
                        ViewBag.AllAccounts = GetAllAccounts();
                        ViewBag.Error = "This is an IRA account. You have contributed too much.";
                        ViewBag.MaxContribution = GetMaxContribution(accountNumber);
                        return View(transactionTo);
                    }
                }
            }


            if (accountFrom.Balance < 0)
            {
                ViewBag.AllAccounts = GetAllAccounts();
                ViewBag.Error = "This account is overdrafted. Deposit more money. We like money.";
                return View(transactionFrom);
            }

            if (transactionFrom.Amount > AmountBeforeOverdraft(accountFrom.AccountNumber))
            {
                ViewBag.AllAccounts = GetAllAccounts();
                ViewBag.Error = "This payment is above your balance and the allowed overdraft amount.";
                return View(transactionFrom);
            }

            if (transactionFrom.Amount >= accountFrom.Balance && transactionFrom.Amount <= AmountBeforeOverdraft(accountFrom.AccountNumber))
            {
                transactionFrom.TransactionStatus = TransactionStatus.Accepted;
                transactionTo.TransactionStatus = TransactionStatus.Accepted;
                accountFrom.Withdraw(transactionFrom.Amount);
                accountTo.Deposit(transactionTo.Amount);
                _context.Add(transactionTo);

                _context.Add(transactionFrom);
                await _context.SaveChangesAsync();

                Transaction FeeTransaction = new Transaction
                {
                    Account = transactionFrom.Account,
                    Amount = 30,
                    TransactionType = TransactionType.Fee,
                    Date = DateTime.Now
                };

                FeeTransaction.TransactionStatus = TransactionStatus.Accepted;
                transactionFrom.Account.Withdraw(FeeTransaction.Amount);

                _context.Add(FeeTransaction);
                await _context.SaveChangesAsync();

                MailAddress to = new MailAddress(accountFrom.AppUser.Email);
                MailAddress from = new MailAddress("bevobankandtrustgroup16@gmail.com");
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = "Team 16: Overdraft Message";
                mail.Body = "You have an overdraft. This confirms that. Fix it.";

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("bevobankandtrustgroup16@gmail.com", "Abc123!!");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return View("OverdraftFee");
            }

            transactionTo.TransactionStatus = TransactionStatus.Accepted;
            transactionFrom.TransactionStatus = TransactionStatus.Accepted;

            accountFrom.Withdraw(transactionFrom.Amount);
            _context.Add(transactionFrom);

            accountTo.Deposit(transactionTo.Amount);
            _context.Add(transactionTo);

            await _context.SaveChangesAsync();


            /*ViewBag.TransactionIDTo = transactionTo.TransactionID;
            ViewBag.TransactionTypeTo = transactionTo.TransactionType;
            ViewBag.AmountTo = transactionTo.Amount;
            ViewBag.DateTo = transactionTo.Date;
            ViewBag.DescriptionTo = transactionTo.Description;
            ViewBag.CommentTo = transactionTo.Comment;
            ViewBag.TransactionIDFrom = transactionFrom.TransactionID;
            ViewBag.TransactionTypeFrom = transactionFrom.TransactionType;
            ViewBag.AmountFrom = transactionFrom.Amount;
            ViewBag.DateFrom = transactionFrom.Date;
            ViewBag.DescriptionFrom = transactionFrom.Description;
            ViewBag.CommentFrom = transactionFrom.Comment;
            *//*ViewBag.transactionFrom = transactionFrom;
            ViewBag.transactionTo = transactionTo;*//*
            ViewBag.SelectedAccountFrom = SelectedAccountFrom;
            ViewBag.SelectedAccountTo = SelectedAccountTo;*/


            return View("ConfirmTransfer");
               
        }

        /*public async Task<IActionResult> ConfirmTransfer(int TransactionIDFrom, Decimal AmountFrom, DateTime DateFrom, string DescriptionFrom, String CommentFrom, int TransactionIDTo, Decimal AmountTo, DateTime DateTo, string DescriptionTo, String CommentTo, Int32 SelectedAccountFrom, Int32 SelectedAccountTo)
        {
            Account accountFrom = _context.Accounts.FirstOrDefault(a => a.AccountID == SelectedAccountFrom);
            Account accountTo = _context.Accounts.FirstOrDefault(a => a.AccountID == SelectedAccountTo);

            Transaction transactionTo = new Transaction()
            {
                TransactionID = TransactionIDTo,
                Amount = AmountTo,
                TransactionType = TransactionType.Transfer,
                Date = DateTo,
                Description = DescriptionTo,
                Account = accountTo,
                TransactionStatus = TransactionStatus.Accepted
            };

            Transaction transactionFrom = new Transaction()
            {
                TransactionID = TransactionIDFrom,
                Amount = AmountFrom,
                TransactionType = TransactionType.Transfer,
                Date = DateFrom,
                Description = DescriptionFrom,
                Account = accountFrom,
                TransactionStatus = TransactionStatus.Accepted
            };

          *//*transactionFrom.TransactionType = TransactionType.Transfer;
            transactionTo.TransactionType = TransactionType.Transfer;*//*

            AppUser appUser = _context.Users.FirstOrDefault(a => a.Email == User.Identity.Name);

            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(appUser.Birthday).Ticks).Year - 1;

            if (accountFrom.Balance < 0)
            {
                ViewBag.AllAccounts = GetAllAccounts();
                ViewBag.Error = "This account is overdrafted. Deposit more money. We like money.";
                return View(transactionFrom);
            }

            if (transactionFrom.Amount > AmountBeforeOverdraft(accountFrom.AccountNumber))
            {
                ViewBag.AllAccounts = GetAllAccounts();
                ViewBag.Error = "This payment is above your balance and the allowed overdraft amount.";
                return View(transactionFrom);
            }

            if (transactionFrom.Amount >= accountFrom.Balance && transactionFrom.Amount <= AmountBeforeOverdraft(accountFrom.AccountNumber))
            {
                transactionFrom.TransactionStatus = TransactionStatus.Accepted;
                transactionTo.TransactionStatus = TransactionStatus.Accepted;
                accountFrom.Withdraw(transactionFrom.Amount);
                accountTo.Deposit(transactionTo.Amount);
                _context.Add(transactionTo);

                _context.Add(transactionFrom);
                await _context.SaveChangesAsync();

                Transaction FeeTransaction = new Transaction
                {
                    Account = transactionFrom.Account,
                    Amount = 30,
                    TransactionType = TransactionType.Fee,
                    Date = DateTime.Now
                };

                FeeTransaction.TransactionStatus = TransactionStatus.Accepted;
                transactionFrom.Account.Withdraw(FeeTransaction.Amount);

                _context.Add(FeeTransaction);
                await _context.SaveChangesAsync();

                MailAddress to = new MailAddress(accountFrom.AppUser.Email);
                MailAddress from = new MailAddress("bevobankandtrustgroup16@gmail.com");
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = "Team 16: Overdraft Message";
                mail.Body = "You have an overdraft. This confirms that. Fix it.";

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("bevobankandtrustgroup16@gmail.com", "Abc123!!");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return View("OverdraftFee");
                
            }

            return RedirectToAction("Index", "Accounts");
        }*/


        //GET: Transaction/Payment
        [HttpGet]
        public IActionResult Payment()
        {
            Transaction transaction = new Transaction();
            transaction.Date = DateTime.Now;

            ViewBag.AllAccounts = GetAllAccounts();
            ViewBag.AllPayees = GetAllPayees();

            return View(transaction);
        }

        //POST: Transaction/Payment
        [HttpPost]
        public async Task<IActionResult> Payment([Bind("TransactionID,Amount,Date,Description,Comment")] Transaction transaction, Int32 SelectedAccount, Int32 SelectedPayee)
        {
            Account account = _context.Accounts.FirstOrDefault(a => a.AccountID == SelectedAccount);
            transaction.Account = account;

            Payee payee = _context.Payees.FirstOrDefault(a => a.PayeeID == SelectedPayee);
            transaction.Payee = payee;

            transaction.TransactionType = TransactionType.Payment;

            AppUser appUser = _context.Users.FirstOrDefault(a => a.Email == User.Identity.Name);

            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(appUser.Birthday).Ticks).Year - 1;


            if (account.Balance < 0)
            {
                ViewBag.AllAccounts = GetAllAccounts();
                ViewBag.AllPayees = GetAllPayees();
                ViewBag.Error = "This account is overdrafted. Deposit more money. We like money.";
                return View(transaction);
            }


            if (account.AccountType == AccountType.IRA)
            {
                if (Years < 65)
                {
                    if (transaction.Amount > 3000)
                    {
                        ViewBag.AllAccounts = GetAllAccounts();
                        ViewBag.AllPayees = GetAllPayees();
                        ViewBag.Error = "This distribution is unqualified. Max withdrawal including a $30 fee is $3000";
                        return View(transaction);
                    }
                    else
                    {
                        transaction.TransactionStatus = TransactionStatus.Accepted;
                        account.Withdraw(transaction.Amount);

                        _context.Add(transaction);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("FeeCreate", "Transactions", new { transactionID = transaction.TransactionID }); 
                    }
                }
            }

            if (transaction.Amount > AmountBeforeOverdraft(account.AccountNumber))
            {
                ViewBag.AllAccounts = GetAllAccounts();
                ViewBag.AllPayees = GetAllPayees();
                ViewBag.Error = "This payment is above your balance and the allowed overdraft amount.";
                return View(transaction);
            }

            if (transaction.Amount >= account.Balance && transaction.Amount <= AmountBeforeOverdraft(account.AccountNumber))
            {
                transaction.TransactionStatus = TransactionStatus.Accepted;
                account.Withdraw(transaction.Amount);

                _context.Add(transaction);
                await _context.SaveChangesAsync();

                Transaction FeeTransaction = new Transaction
                {
                    Account = transaction.Account,
                    Amount = 30,
                    TransactionType = TransactionType.Fee,
                    Date = DateTime.Now
                };

                FeeTransaction.TransactionStatus = TransactionStatus.Accepted;
                transaction.Account.Withdraw(FeeTransaction.Amount);

                _context.Add(FeeTransaction);
                await _context.SaveChangesAsync();

                MailAddress to = new MailAddress(account.AppUser.Email);
                MailAddress from = new MailAddress("bevobankandtrustgroup16@gmail.com");
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = "Team 16: Overdraft Message";
                mail.Body = "You have an overdraft. This confirms that. Fix it.";

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("bevobankandtrustgroup16@gmail.com", "Abc123!!");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return View("OverdraftFee");


            }

            transaction.TransactionStatus = TransactionStatus.Accepted;
            account.Withdraw(transaction.Amount);
            _context.Add(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET: Transactions/FeeCreate
        public IActionResult FeeCreate(int transactionID)
        {
            Transaction transaction = _context.Transactions
                .FirstOrDefault(t => t.TransactionID == transactionID);

            ViewBag.transactionID = transactionID;

            if (transaction.Amount > 2970)
            {
                ViewBag.Message = "Included";
            }
            else
            {
                ViewBag.Message = "Option";
            }

            return View(transaction);
        }
        //POST: Transactions/FeeCreate
        [HttpPost]
        public async Task<IActionResult> FeeCreate(int transactionID, string feeDecision)
        {
            Transaction oldTransaction = _context.Transactions
                                .Include(a => a.Account)
                                .FirstOrDefault(t => t.TransactionID == transactionID);
    
            Account destinationAccount = oldTransaction.Account;
            Transaction FeeTransaction = new Transaction();

            if (feeDecision == "Add")
            {
                FeeTransaction.Account = destinationAccount;
                FeeTransaction.Amount = 30;
                FeeTransaction.TransactionType = TransactionType.Fee;
                FeeTransaction.TransactionStatus = TransactionStatus.Accepted;
                destinationAccount.Withdraw(FeeTransaction.Amount);
                FeeTransaction.Date = DateTime.Now;
            }
            else
            {
                oldTransaction.Amount -= 30;
                _context.Update(oldTransaction);

                FeeTransaction.Account = destinationAccount;
                FeeTransaction.Amount = 30;
                FeeTransaction.TransactionType = TransactionType.Fee;
                FeeTransaction.Date = DateTime.Now;
                FeeTransaction.TransactionStatus = TransactionStatus.Accepted;

            }

            _context.Add(FeeTransaction);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Accounts");
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionID,Amount,TransactionType,Date,Description,Comment")] Transaction transaction)
        {
            if (id != transaction.TransactionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.TransactionID == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Kevin commented out a lot of stuff
        public IActionResult SearchTransactions()
        {
            SearchViewModel svm = new SearchViewModel();
            //svm.DateSelection = DateSelectionType.AllAvailable;        //to be uncommented when migration and radio buttons present

            return View(svm);

        }

        public IActionResult DisplaySearchResults(SearchViewModel svm)
        {
            var query = from t in _context.Transactions                         // this pops up with 0 results???
                        select t;

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

            /*if (svm.SearchPrice != null)
            {
                TryValidateModel(svm);
                if (ModelState.IsValid == false)
                {
                    ViewBag.PriceMessage = svm.SearchPrice + " is not a valid number. Please try again.";
                    return View("SearchTransactions", svm);
                }
            }*/

            if (svm.SearchAmount != Amount.AllAmounts)
            {
                switch (svm.SearchAmount)
                {
                    case Amount.ZeroToHundred:
                        query = query.Where(t => t.Amount >= 0 && t.Amount <= 100);
                        break;
                    case Amount.HundredToTwoHundred:
                        query = query.Where(t => t.Amount >= 100 && t.Amount <= 200);
                        break;
                    case Amount.TwoHundredToThreeHundred:
                        query = query.Where(t => t.Amount >= 200 && t.Amount <= 300);
                        break;
                    case Amount.ThreeHundredPlus:
                        query = query.Where(t => t.Amount >= 300);
                        break;
                    case Amount.Custom:
                        query = query.Where(t => t.Amount >= svm.SearchAmountAbove && t.Amount <= svm.SearchAmountBelow);
                        break;
                    default:
                        break;

                }
            }


            if (svm.DateSelection != DateSelectionType.AllAvailable)
            {
                switch (svm.DateSelection)
                {
                    case DateSelectionType.FifteenDays:
                        query = query.Where(t => t.Date >= DateTime.Now.AddDays(-15));
                        break;
                    case DateSelectionType.ThirtyDays:
                        query = query.Where(t => t.Date >= DateTime.Now.AddDays(-30));
                        break;
                    case DateSelectionType.SixtyDays:
                        query = query.Where(t => t.Date >= DateTime.Now.AddDays(-60));
                        break;
                    case DateSelectionType.Custom:
                        query = query.Where(t => t.Date >= svm.DateAfter && t.Date <= svm.DateBefore);
                        break;
                    default:
                        break;
                }
            }


            if (User.IsInRole("Manager") || User.IsInRole("Employee"))
            {
                List<Transaction> managerSelectedTransactions = query.Include(t => t.Account).ToList();


                ViewBag.AllTransactionsCount = _context.Transactions.Include(t => t.Account).ThenInclude(a => a.AppUser).Count();
                ViewBag.SelectedTransactionsCount = managerSelectedTransactions.Count();
                return View("Index", managerSelectedTransactions);
            }

            if (User.IsInRole("Customer"))
            {
                List<Transaction> SelectedTransactions = query.Where(t => t.Account.AppUser.Email == User.Identity.Name).Include(t => t.Account).ThenInclude(a => a.AppUser).ToList();


                ViewBag.AllTransactionsCount = _context.Transactions.Where(t => t.Account.AppUser.Email == User.Identity.Name).Include(t => t.Account).ThenInclude(a => a.AppUser).Count();
                ViewBag.SelectedTransactionsCount = SelectedTransactions.Count();
                return View("Index", SelectedTransactions);
            }
            /*List<Transaction> SelectedTransactions = query.Where(t => t.Account.AppUser.Email == User.Identity.Name).Include(t => t.Account).ThenInclude(a => a.AppUser).ToList();


            ViewBag.AllTransactionsCount = _context.Transactions.Where(t => t.Account.AppUser.Email == User.Identity.Name).Include(t => t.Account).ThenInclude(a => a.AppUser).Count();
            ViewBag.SelectedTransactionsCount = SelectedTransactions.Count();*/



            return View("Index");

            //return View("Details", SelectedTransactions.OrderByDescending(t => t.Amount));
        }


        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionID == id);
        }

        private SelectList GetAllAccounts()
        {
            List<Account> accountList = _context.Accounts.Where(a => a.AppUser.Email == User.Identity.Name).ToList();


            foreach (Account a in _context.Accounts)
            {
                String name = a.AccountName;
                String number = a.AccountNumberLastFour.ToString();
                String balance = a.Balance.ToString();
                String accountInfo = name + "  ~  " + number + "  ~  " + "Balance: $" + balance;
                a.AccountName = accountInfo;
            }

            SelectList accounts = new SelectList(accountList, "AccountID", "AccountName");

            return accounts;
        }

        private SelectList GetAllPayees()
        {
            List<Payee> payeeList = _context.Payees.ToList();

            SelectList payees = new SelectList(payeeList, "PayeeID", "PayeeName");

            return payees;
        }

        private bool GetHasOtherAccounts()
        {
            int numAccounts = _context.Accounts
                .Include(a => a.AppUser)
                .Where(a => a.AppUser.UserName == User.Identity.Name).Count();

            return numAccounts > 1;
        }

        private Decimal AmountBeforeOverdraft(int accountNumber)
        {
            Account sourceAccount = _context.Accounts
                .FirstOrDefault(a => a.AccountNumber == accountNumber);

            Decimal maxDecrease = sourceAccount.Balance + 50;

            return maxDecrease;
        }

        private String OverdraftedAccount(int accountNumber)
        {

            Account account = _context.Accounts
                .FirstOrDefault(a => a.AccountNumber == accountNumber);

            String Overdraft = null;


           if (account.Balance < 0)
            {
                Overdraft = "True";
            }




            return Overdraft;
            
        }

        private Decimal GetMaxContribution(int accountNumber)
        {
            IRAAccount destAccount = _context.IRAAccounts
                    .FirstOrDefault(a => a.AccountNumber == accountNumber);

            Decimal maxAmount = 5000 - destAccount.ContributionAmount;

            return maxAmount;
        }

        private List<Transaction> FiveSimilar(Transaction transaction)
        {
           Account account = transaction.Account;

            var query = from t in _context.Transactions
                        select t;

            query = query.Where(t => t.Account == account);

            query = query.Where(t => t.TransactionType == transaction.TransactionType);

            query = query.Where(t => t.Account.AppUser.Email == User.Identity.Name);

            query = query.OrderBy(t => t.Date);

            List<Transaction> similarTransactions = query.Include(t => t.Account).ThenInclude(t => t.AppUser).ToList();

            List<Transaction> fiveLatest = new List<Transaction>();

            for (int i=0; i < similarTransactions.Count && i < 5; i++)
            {
                fiveLatest.Add(similarTransactions[i]);
            }

            return fiveLatest;
        }

        /*public ActionResult SendEmail(string fromAddress, string toAddress, string subject, string body, int Port, bool EnableSsl, string smtpServer, string password)
        {

                MailAddress to = new MailAddress(toAddress);
                MailAddress from = new MailAddress(fromAddress);
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = subject;
                mail.Body = body;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = smtpServer;
                smtp.Port = Port;
                smtp.Credentials = new System.Net.NetworkCredential(fromAddress, password);
                smtp.EnableSsl = EnableSsl;
                smtp.Send(mail);

            return RedirectToAction("OverdraftFee");

        }*/
    }
}
