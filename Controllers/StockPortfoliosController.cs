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
    public class StockPortfoliosController : Controller
    {
        private readonly AppDbContext _context;

        public StockPortfoliosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StockPortfolios
        public async Task<IActionResult> Index()
        {
            return View(await _context.StockPortfolios.ToListAsync());
        }

        // GET: StockPortfolios/Details/5
        public async Task<IActionResult> Details(int? id, string message)
        {
            ViewBag.ErrorMessage = message;

            if (id == null)
            {
                return NotFound();
            }

            var stockPortfolio = await _context.StockPortfolios
                .FirstOrDefaultAsync(m => m.AccountID == id);

            if (stockPortfolio == null)
            {
                return NotFound();
            }
            //figuring out past vs current price
            //TODO: format as currency
            ViewBag.StockBalance = GetStockBalance();
            ViewBag.TotalBalance = GetStockBalance() + stockPortfolio.Balance;
            ViewBag.Is_Balanced = GetBalancedStatus();
            ViewBag.TotalFees = GetTotalFees();
            ViewBag.StockViewModels = GetStockViewModels();
            ViewBag.Transactions = GetAllTransactions(stockPortfolio.AccountID);

            return View(stockPortfolio);
        }

        // GET: StockPortfolios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockPortfolios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountName")] StockPortfolio stockPortfolio)
        {
            AppUser appUser = _context.Users.FirstOrDefault(a => a.Email == User.Identity.Name);
            stockPortfolio.AppUser = appUser;
            stockPortfolio.Balance = 0m;
            stockPortfolio.AccountType = AccountType.Stock;
            stockPortfolio.Is_Active = true;
            stockPortfolio.AccountNumber = Utilities.GenerateAccountNumber.GetNextAccountNumber(_context);
            stockPortfolio.Date = DateTime.Now;

            ViewBag.HasOtherAccounts = GetHasOtherAccounts();

            if (ModelState.IsValid)
            {
                _context.Add(stockPortfolio);
                await _context.SaveChangesAsync();
                return RedirectToAction("Deposit", "Transactions", new { accountID = stockPortfolio.AccountID });
            }
            return View(stockPortfolio);
        }

        // GET: StockPortfolios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockPortfolio = await _context.StockPortfolios.FindAsync(id);
            if (stockPortfolio == null)
            {
                return NotFound();
            }
            return View(stockPortfolio);
        }

        // POST: StockPortfolios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BalancedStatus,AccountID,Balance,AccountName,AccountType,AccountNumber,Customer,Date")] StockPortfolio stockPortfolio)
        {
            if (id != stockPortfolio.AccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Account DBAcc = _context.Accounts.Find(stockPortfolio.AccountID);
                    DBAcc.AccountName = stockPortfolio.AccountName;
                    _context.Update(DBAcc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockPortfolioExists(stockPortfolio.AccountID))
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
            return View(stockPortfolio);
        }

        // GET: StockPortfolios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockPortfolio = await _context.StockPortfolios
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (stockPortfolio == null)
            {
                return NotFound();
            }

            return View(stockPortfolio);
        }

        // POST: StockPortfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockPortfolio = await _context.StockPortfolios.FindAsync(id);
            _context.StockPortfolios.Remove(stockPortfolio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: StockPortfolios/Purchase
        public IActionResult Purchase()
        {
            ViewBag.Accounts = _context.Accounts
                .Include(a => a.AppUser)
                //TODO: Check if this is working once we can
                //create IRA accounts
                .Where(a => a.AccountType != AccountType.IRA)
                .Where(a => a.AppUser.Email == User.Identity.Name).ToList();

            IEnumerable<Stock> stocks = _context.Stocks.ToList();

            return View(stocks);
        }

        // POST: StockPortfolios/Purchase
        [HttpPost]
        public IActionResult Purchase(int? stockID, int? numShares, DateTime? date, int? accountID)
        {
            if (stockID == null || numShares == null || accountID == null || date == null)
            {
                ViewBag.Accounts = _context.Accounts
                .Include(a => a.AppUser)
                //TODO: Check if this is working once we can
                //create IRA accounts
                .Where(a => a.AccountType != AccountType.IRA)
                .Where(a => a.AppUser.Email == User.Identity.Name).ToList();

                ViewBag.ErrorMessage = "Make sure not to leave anything blank";

                IEnumerable<Stock> stocks = _context.Stocks.ToList();

                return View(stocks);
            }

            Account sourceAccount = _context.Accounts
                .FirstOrDefault(a => a.AccountID == accountID);

            Stock stock = _context.Stocks
                .FirstOrDefault(s => s.StockID == stockID);

            Decimal totalPrice = (decimal)((stock.StockPrice * numShares) + stock.StockFee);

            if (sourceAccount.Balance < totalPrice)
            {
                ViewBag.Accounts = _context.Accounts
                .Include(a => a.AppUser)
                //TODO: Check if this is working once we can
                //create IRA accounts
                .Where(a => a.AccountType != AccountType.IRA)
                .Where(a => a.AppUser.Email == User.Identity.Name).ToList();

                IEnumerable<Stock> stocks = _context.Stocks.ToList();

                ViewBag.ErrorMessage = "Selected account has insufficient funds.  Deposit more or select another account.";

                return View(stocks);
            }

            StockPortfolio portfolio = _context.StockPortfolios
                .Include(sp => sp.StockTransactions)
                .Include(sp => sp.AppUser)
                .FirstOrDefault(sp => sp.AppUser.Email == User.Identity.Name);

            sourceAccount.Withdraw(totalPrice);

            Transaction transaction1 = new Transaction()
            {
                Amount = (decimal)(stock.StockPrice * numShares),
                TransactionType = TransactionType.Withdrawal,
                Date = (System.DateTime)date,
                Description = "Stock Purchase - Account[" + portfolio.AccountNumberLastFour + "]",
                Account = sourceAccount,
                TransactionStatus = TransactionStatus.Accepted
            };

            Transaction transaction2 = new Transaction()
            {
                Amount = stock.StockFee,
                TransactionType = TransactionType.Withdrawal,
                Date = (System.DateTime)date,
                Description = "Fee: [" + stock.StockName + "]",
                Account = sourceAccount,
                TransactionStatus = TransactionStatus.Accepted
            };

            _context.Transactions.Add(transaction1);
            _context.Transactions.Add(transaction2);
            _context.SaveChanges();

            StockTransaction st = new StockTransaction()
            {
                NumberOfShares = (int)numShares,
                PurchasePrice = stock.StockPrice,
                PurchaseFee = stock.StockFee,
                Stock = stock,
                StockPortfolio = portfolio,
                PurchaseDate = (System.DateTime)date
            };

            _context.StockTransactions.Add(st);
            portfolio.StockTransactions.Add(st);
            _context.SaveChanges();

            ViewBag.AccountID = portfolio.AccountID;

            return View("SuccessStock");
        }

        public IActionResult Sell(int stockID, int numShares, Decimal pPrice, Decimal cPrice, DateTime pDate)
        {
            ViewBag.StockID = stockID;
            ViewBag.NumShares = numShares;
            ViewBag.PurchasePrice = pPrice;
            ViewBag.CurrentPrice = cPrice;
            ViewBag.Gain = cPrice - pPrice;
            ViewBag.PurchaseDate = pDate;

            return View();
        }

        [HttpPost]
        public IActionResult Sell(int numSharesWanted, int stockID, int numSharesOwned, DateTime sDate, Decimal purPrice)
        {
            if (numSharesWanted > numSharesOwned)
            {
                ViewBag.ErrorMessage = "Number of shares to sell exceeds amount owned";
                return View();
            }

            StockPortfolio portfolio = _context.StockPortfolios
                .Include(p => p.StockTransactions)
                .ThenInclude(st => st.Stock)
                .Include(p => p.AppUser)
                .FirstOrDefault(p => p.AppUser.Email == User.Identity.Name);

            DateTime pDate = new DateTime();
            foreach (StockTransaction st in portfolio.StockTransactions)
            {
                if (st.Stock.StockID == stockID)
                {
                    pDate = st.PurchaseDate;
                }
                break;
            }

            if (DateTime.Compare(sDate, pDate) < 0)
            {
                string errorMessage = "Must pick a sale date that is after the purchase date";
                return RedirectToAction("Details", "StockPortfolios", new { id = portfolio.AccountID, message = errorMessage });
            }

            return RedirectToAction("SellConfirm", "StockPortfolios", new { numSharesWanted, stockID, numSharesOwned, sDate, purPrice });
        }

        public IActionResult SellConfirm(int numSharesWanted, int stockID, int numSharesOwned, DateTime sDate, Decimal purPrice)
        {
            Stock stock = _context.Stocks
                .FirstOrDefault(s => s.StockID == stockID);

            StockPortfolio portfolio = _context.StockPortfolios
                .Include(sp => sp.AppUser)
                .FirstOrDefault(sp => sp.AppUser.Email == User.Identity.Name);

            ViewBag.Company = stock.StockName;
            ViewBag.AccountID = portfolio.AccountID;
            ViewBag.PurchasePrice = purPrice;
            ViewBag.Fee = stock.StockFee;
            ViewBag.NumSharesWanted = numSharesWanted;
            ViewBag.StockID = stockID;
            ViewBag.SharesRemaining = numSharesOwned - numSharesWanted;
            ViewBag.Date = sDate;
            ViewBag.NetProfit = (numSharesWanted * stock.StockPrice) - (numSharesWanted * purPrice) - stock.StockFee;

            return View();
        }

        [HttpPost]
        public IActionResult SellConfirm(int numShares, int stockID, DateTime sDate, Decimal purPrice, Decimal profit)
        {
            StockPortfolio portfolio = _context.StockPortfolios
                .Include(p => p.AppUser)
                .FirstOrDefault(p => p.AppUser.Email == User.Identity.Name);

            Stock stock = _context.Stocks
                .FirstOrDefault(s => s.StockID == stockID);

            string desc = Convert.ToString(numShares) + " shares of " + stock.StockName + " sold at " + stock.StockPrice + ". Initial price was " + Convert.ToString(purPrice) + ". Total gains/losses were " + Convert.ToString(profit);

            Transaction transaction1 = new Transaction()
            {
                Amount = numShares * stock.StockPrice,
                TransactionType = TransactionType.Deposit,
                Date = sDate,
                Description = desc,
                Account = portfolio,
                TransactionStatus = TransactionStatus.Accepted
            };

            Transaction transaction2 = new Transaction()
            {
                Amount = stock.StockFee,
                TransactionType = TransactionType.Withdrawal,
                Date = sDate,
                Description = "Fee for sale of " + stock.StockName,
                Account = portfolio,
                TransactionStatus = TransactionStatus.Accepted
            };

            _context.Transactions.Add(transaction1);
            _context.Transactions.Add(transaction2);
            _context.SaveChanges();

            StockTransaction st = new StockTransaction()
            {
                NumberOfShares = numShares * -1,
                PurchasePrice = stock.StockPrice,
                PurchaseFee = stock.StockFee,
                Stock = stock,
                StockPortfolio = portfolio,
                PurchaseDate = sDate
            };

            portfolio.Deposit(numShares * stock.StockPrice);
            portfolio.Withdraw(stock.StockFee);

            _context.StockTransactions.Add(st);
            portfolio.StockTransactions.Add(st);
            _context.SaveChanges();

            ViewBag.AccountID = portfolio.AccountID;

            return View("SuccessSale");
        }

        private bool StockPortfolioExists(int id)
        {
            return _context.StockPortfolios.Any(e => e.AccountID == id);
        }

        private Decimal GetTotalFees()
        {
            StockPortfolio portfolio = _context.StockPortfolios
                .Include(p => p.StockTransactions)
                .ThenInclude(s => s.Stock)
                .Include(p => p.AppUser)
                .FirstOrDefault(p => p.AppUser.Email == User.Identity.Name);

            return portfolio.StockTransactions.Sum(st => st.PurchaseFee);
        }

        private List<StockDetailsViewModel> GetStockViewModels()
        {
            StockPortfolio portfolio = _context.StockPortfolios
                .FirstOrDefault(sp => sp.AppUser.Email == User.Identity.Name);

            List<StockTransaction> stockTrans = _context.StockTransactions
                .Include(st => st.StockPortfolio)
                .ThenInclude(sp => sp.AppUser)
                .Where(st => st.StockPortfolio.AppUser.Email == User.Identity.Name)
                .ToList();

            List<Stock> userStocks = new List<Stock>();
            foreach (StockTransaction st in stockTrans)
            {
                if (!userStocks.Contains(st.Stock))
                {
                    userStocks.Add(st.Stock);
                }
            }

            List<StockDetailsViewModel> sdvmList = new List<StockDetailsViewModel>();

            foreach (Stock stock in userStocks)
            {
                StockDetailsViewModel sdvm = new StockDetailsViewModel()
                {
                    StockID = stock.StockID,
                    StockName = stock.StockName,
                    StockTicker = stock.StockTicker,
                    PurchasePrice = GetPurchasePrice(stock.StockID),
                    CurrentPrice = stock.StockPrice,
                    StockFee = stock.StockFee,
                    StockType = stock.StockType,
                    NumberOfShares = GetNumShares(stock.StockID)
                };

                if (sdvm.NumberOfShares > 0)
                {
                    sdvmList.Add(sdvm);
                }
            }

            return sdvmList;
        }

        private Decimal GetPurchasePrice(int stockID)
        {
            StockPortfolio portfolio = _context.StockPortfolios
                .Include(p => p.StockTransactions)
                .Include(p => p.AppUser)
                .FirstOrDefault(p => p.AppUser.Email == User.Identity.Name);

            List<StockTransaction> stockTrans = _context.StockTransactions
                .Include(st => st.StockPortfolio)
                .Where(st => st.StockPortfolio.AccountID == portfolio.AccountID)
                .ToList();

            Decimal purchasePrice = 0;

            foreach (StockTransaction st in portfolio.StockTransactions)
            {
                if (st.Stock.StockID == stockID)
                {
                    purchasePrice = st.PurchasePrice;
                    break;
                }
            }

            return purchasePrice;
        }

        private int GetNumShares(int stockID)
        {
            StockPortfolio portfolio = _context.StockPortfolios
                .Include(p => p.StockTransactions)
                .ThenInclude(st => st.Stock)
                .Include(p => p.AppUser)
                .FirstOrDefault(p => p.AppUser.Email == User.Identity.Name);

            int numShares = 0;
            foreach (StockTransaction st in portfolio.StockTransactions)
            {
                if (st.Stock.StockID == stockID)
                {
                    numShares += st.NumberOfShares;
                }
            }

            return numShares;
        }

        private bool GetBalancedStatus()
        {
            StockPortfolio portfolio = _context.StockPortfolios
                .Include(p => p.StockTransactions)
                .ThenInclude(s => s.Stock)
                .Include(p => p.AppUser)
                .FirstOrDefault(p => p.AppUser.Email == User.Identity.Name);

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

        private bool GetHasOtherAccounts()
        {
            int numAccounts = _context.Accounts
                .Include(a => a.AppUser)
                .Where(a => a.AppUser.UserName == User.Identity.Name).Count();

            return numAccounts > 1;
        }

        private Decimal GetStockBalance()
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

                return stockBalance;
            }
            else
            {
                return -1m;
            }
        }

        private List<Transaction> GetAllTransactions(int accountID)
        {
            List<Transaction> transactions = _context.Transactions
                .Include(t => t.Account)
                .Where(t => t.Account.AccountID == accountID)
                .ToList();

            return transactions;
        }

    }
}