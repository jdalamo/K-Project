using System;
using System.Collections.Generic;
using System.Linq;
using fa19projectgroup16.DAL;
using fa19projectgroup16.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fa19projectgroup16.Utilities;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace fa19projectgroup16.Controllers
{
    public class ManageUsersController : Controller
    {
        private UserManager<AppUser> _userManager;
        private PasswordValidator<AppUser> _passwordValidator;
        private readonly AppDbContext _context;

        public ManageUsersController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            
            //user manager only has one password validator
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Manager")]
        public IActionResult Disputes()
        {
            ViewBag.CurrentDisputes = GetCurrentDisputes();
            return View();
        }

        [Authorize(Roles = "Manager")]
        public IActionResult ResolveDispute(int id)
        {
            Dispute dispute = _context.Disputes.
                Include(t => t.Transaction).
                FirstOrDefault(d => d.DisputeID == id);
            return View(dispute);
        }

        [HttpPost]
        public async Task<IActionResult> ResolveDispute(int id, Status status, string ManagerComment, Decimal Amount)
        {
            Dispute dispute = _context.Disputes.
                Include(t => t.Transaction).
                FirstOrDefault(d => d.DisputeID == id);

            if (status == Status.Adjusted)
            {
                if (Amount < 0)
                {
                    ViewBag.Error = "Can not adjust amount to a negative number.";
                    return View(dispute);
                }
            }

            dispute.ManagerComment = ManagerComment;

            dispute.ManagerEmail = User.Identity.Name;

            Transaction transaction = _context.Transactions.
                Include(a => a.Account).
                FirstOrDefault(t => t.TransactionID == dispute.Transaction.TransactionID);

            if (status == Status.Accepted)
            {
                Decimal change = transaction.Amount - dispute.CorrectAmount;

                transaction.Amount = dispute.CorrectAmount;
                dispute.Status = Status.Accepted;

                if (transaction.TransactionType == TransactionType.Fee
                    || transaction.TransactionType == TransactionType.Payment
                    || transaction.TransactionType == TransactionType.Withdrawal)
                {
                    if (change >= 0)
                    {
                        transaction.Account.Withdraw(change);
                    }
                    else
                    {
                        transaction.Account.Deposit(change * -1);
                    }
                }
                else
                {
                    if (change <= 0)
                    {
                        transaction.Account.Deposit(change * -1);
                    }
                    else
                    {
                        transaction.Account.Withdraw(change);
                    }
                }
                _context.Update(transaction.Account);
            }
            else if (status == Status.Rejected)
            {
                dispute.Status = Status.Rejected;

            }
            else
            {
                Decimal change = transaction.Amount - Amount;

                transaction.Amount = Amount;
                dispute.Status = Status.Adjusted;

                if (transaction.TransactionType == TransactionType.Fee
                    || transaction.TransactionType == TransactionType.Payment
                    || transaction.TransactionType == TransactionType.Withdrawal)
                {
                    if (change >= 0)
                    {
                        transaction.Account.Withdraw(change);
                    }
                    else
                    {
                        transaction.Account.Deposit(change * -1);
                    }
                }
                else
                {
                    if (change <= 0)
                    {
                        transaction.Account.Deposit(change * -1);
                    }
                    else
                    {
                        transaction.Account.Withdraw(change);
                    }
                }
                _context.Update(transaction.Account);
            }
            transaction.Description = "Dispute " + Convert.ToString(status) + " " + transaction.Description;

            /*MailAddress to = new MailAddress(transaction.Account.AppUser.Email);
            MailAddress from = new MailAddress("bevobankandtrustgroup16@gmail.com");
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = "Team 16: Dispute Resolved Message";
            mail.Body = "Dispute have been resolved. Check your account to see what happened. Ooooooh, mystery. This saves us code.";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("bevobankandtrustgroup16@gmail.com", "Abc123!!");
            smtp.EnableSsl = true;
            smtp.Send(mail);*/


            _context.Update(transaction);
            _context.Update(dispute);
            await _context.SaveChangesAsync();
            return RedirectToAction("Confirmation");
        }

        public IActionResult LargeDeposits()
        {
            List<Transaction> largeDeposits = _context.Transactions.Where(t => t.Amount >5000 && t.TransactionStatus == TransactionStatus.Pending).ToList();
            ViewBag.LargeDeposits = largeDeposits;

            return View();
        }

        public IActionResult Accept(int id)
        {
            Transaction transaction = _context.Transactions.
                Include(a => a.Account).
                FirstOrDefault(t => t.TransactionID == id);

            transaction.Account.Deposit(transaction.Amount);

            transaction.TransactionStatus = TransactionStatus.Accepted;

            _context.Accounts.Update(transaction.Account);

            _context.SaveChanges();

            /*MailAddress to = new MailAddress(transaction.Account.AppUser.Email);
            MailAddress from = new MailAddress("bevobankandtrustgroup16@gmail.com");
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = "Team 16: Large Deposit Approved Message";
            mail.Body = "Your deposit of over $5000 was approved. You rich rich now.";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("bevobankandtrustgroup16@gmail.com", "Abc123!!");
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return RedirectToAction("LargeDeposits");*/
            return RedirectToAction("LargeDeposits");
        }

        public IActionResult Reject(int id)
        {
            Transaction transaction = _context.Transactions.
                Include(a => a.Account).
                FirstOrDefault(t => t.TransactionID == id);

            _context.Remove(transaction);
            _context.SaveChanges();
            return RedirectToAction("LargeDeposits");
        }

        [Authorize(Roles = "Manager")]
        public IActionResult EmployeeRegister()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            return View(rvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmployeeRegister(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    //TODO: Add the rest of the custom user fields here
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    MiddleInitial = rvm.MiddleInit,
                    Street = rvm.Street,
                    City = rvm.City,
                    State = rvm.State,
                    Zip = rvm.Zip,
                    Birthday = rvm.Birthday,
                    SSN = rvm.SSN,
                    Is_Employed = true

                };

                IdentityResult result = await _userManager.CreateAsync(user, rvm.Password);
                if (result.Succeeded)
                {
                    //TODO: Add user to desired role. This example adds the user to the customer role
                    await _userManager.AddToRoleAsync(user, "Employee");

                    return RedirectToAction("Index", "ManageUsers");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(rvm);
        }

        public IActionResult ManageCustomers()
        {
            ViewBag.AllCustomers = GetAllCustomers();
            return View();
        }
        public async Task<IActionResult> Enable(string email)
        {
            AppUser customer = _context.Users.FirstOrDefault(u => u.Email == email);

            customer.Is_enabled = true;

            _context.Update(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("ManageCustomers");
        }

        public async Task<IActionResult> Disable(string email)
        {
            AppUser customer = _context.Users.FirstOrDefault(u => u.Email == email);

            customer.Is_enabled = false;

            _context.Update(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("ManageCustomers");
        }

        [Authorize(Roles = "Manager")]
        public IActionResult ManageEmployees()
        {
            ViewBag.AllEmployees = GetAllEmployees();
            return View();
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Terminate(string email)
        {
            AppUser employee = _context.Users.FirstOrDefault(u => u.Email == email);

            employee.Is_Employed = false;

            _context.Update(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("ManageEmployees");
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Rehire(string email)
        {
            AppUser employee = _context.Users.FirstOrDefault(u => u.Email == email);

            employee.Is_Employed = true;

            _context.Update(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("ManageEmployees");
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        public IActionResult AllDisputes()
        {
            ViewBag.AllDisputes = GetAllDisputes();
            return View();
        }

        public IActionResult Modify(string email)
        {
            AppUser user = _context.Users.FirstOrDefault(u => u.Email == email);

            ManageProfileViewModel model = new ManageProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City,
                MiddleInitial = user.MiddleInitial,
                Street = user.Street,
                State = user.State,
                Zip = user.Zip,
                PhoneNumber = user.PhoneNumber,
                SSN = user.SSN,
                Email = user.Email

            };

            foreach (AppUser u in GetAllCustomers())
            {
                if (user == u)
                {
                    ViewBag.UserRole = "Customer";
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Modify(ManageProfileViewModel mpvm)
        {
            if (ModelState.IsValid)
            {
                AppUser user = _context.Users.FirstOrDefault(u => u.Email == mpvm.Email);

                user.FirstName = mpvm.FirstName;
                user.LastName = mpvm.LastName;
                user.City = mpvm.City;
                user.MiddleInitial = mpvm.MiddleInitial;
                user.Street = mpvm.Street;
                user.State = mpvm.State;
                user.Zip = mpvm.Zip;
                user.PhoneNumber = mpvm.PhoneNumber;
                foreach (AppUser u in GetAllCustomers())
                {
                    if (user == u)
                    {
                        user.SSN = mpvm.SSN;
                    }
                }

                _context.Update(user);
                _context.SaveChanges();
                foreach (AppUser u in GetAllCustomers())
                {
                    if (user == u)
                    {
                        return RedirectToAction("ManageCustomers");
                    }
                }
                return RedirectToAction("ManageEmployees");

            }
            

            return View(mpvm);
        }

        public IActionResult ProcessPortfolios()
        {
            List<StockPortfolio> portfolios = _context.StockPortfolios
                .Include(p => p.StockTransactions)
                .ThenInclude(st => st.Stock)
                .ToList();

            foreach (StockPortfolio sp in portfolios)
            {
                if (GetBalancedStatus(sp))
                {
                    Transaction transaction = new Transaction()
                    {
                        Amount = GetTotalStockBalance(sp) / 10,
                        TransactionType = TransactionType.Deposit,
                        Date = DateTime.Now,
                        Description = "Balanced Portfolio Bonus",
                        Account = sp
                    };

                    _context.Transactions.Add(transaction);
                    sp.Transactions.Add(transaction);
                    sp.Deposit(transaction.Amount);
                    _context.SaveChanges();
                }
            }

            return View("Index");
        }

        public IActionResult StockCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StockCreate(Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Stocks.Add(stock);
                _context.SaveChanges();

                return View("Index");
            }

            return View(stock);
        }

        public IActionResult StockList()
        {
            List<Stock> stocks = _context.Stocks.ToList();
            return View(stocks);
        }

        public IActionResult StockEdit(int stockID)
        {
            ViewBag.StockID = stockID;
            return View();
        }

        [HttpPost]
        public IActionResult StockEdit(int stockID, Decimal newPrice)
        {
            Stock stock = _context.Stocks
                .FirstOrDefault(s => s.StockID == stockID);

            stock.StockPrice = newPrice;
            _context.SaveChanges();

            return View("Index");
        }

        private Decimal GetTotalStockBalance(StockPortfolio portfolio)
        {
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

            return -1m;

        }

        private bool GetBalancedStatus(StockPortfolio portfolio)
        {
            int numOrdinary = 0;
            int numIndex = 0;
            int numMutual = 0;

            foreach (StockTransaction st in portfolio.StockTransactions)
            {
                switch (st.Stock.StockType)
                {
                    case StockType.Ordinary:
                        numOrdinary += st.NumberOfShares;
                        break;
                    case StockType.Index_Fund:
                        numIndex += st.NumberOfShares;
                        break;
                    case StockType.Mutual_Fund:
                        numMutual += st.NumberOfShares;
                        break;
                }
            }

            return (numOrdinary >= 2 && numIndex >= 1 && numMutual >= 1);
        }

        public List<Dispute> GetCurrentDisputes()
        {
            List<Dispute> currentDisputes = _context.Disputes.Where(d => d.Status == Status.Submitted).
                Include(t => t.Transaction).
                ThenInclude(a => a.Account).
                ThenInclude(u => u.AppUser).ToList();
            return currentDisputes;
        }

        public List<Dispute> GetAllDisputes()
        {
            List<Dispute> disputes = _context.Disputes.
                Include(t => t.Transaction).
                ThenInclude(a => a.Account).
                ThenInclude(u => u.AppUser).ToList();
            return disputes;
        }

        public List<AppUser> GetAllEmployees()
        {

            List<string> userids = _context.UserRoles.Where(a => a.RoleId == "d244674c-2d18-4741-9b2c-90d77b83bbf7").Select(b => b.UserId).Distinct().ToList();
            //The first step: get all user id collection as userids based on role from db.UserRoles

            List<AppUser> employees = _context.Users.Where(a => userids.Any(c => c == a.Id)).ToList();

            return employees;

        }

        public List<AppUser> GetAllCustomers()
        {
            List<string> userids = _context.UserRoles.Where(a => a.RoleId == "d26befd1-36fc-49a0-85d3-12d201178715").Select(b => b.UserId).Distinct().ToList();
            //The first step: get all user id collection as userids based on role from db.UserRoles

            List<AppUser> customers = _context.Users.Where(a => userids.Any(c => c == a.Id)).ToList();

            return customers;
        }
    }
}