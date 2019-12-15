using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fa19projectgroup16.Utilities;
using fa19projectgroup16.DAL;

namespace fa19projectgroup16.Controllers
{
    public class PayeesController : Controller
    {
        private readonly AppDbContext _context;

        public PayeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Payees
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

            return View(await _context.Payees.ToListAsync());
        }

        // GET: Payees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payee payee = await _context.Payees
                .Include(tr => tr.Transactions)
                .FirstOrDefaultAsync(m => m.PayeeID == id);
            if (payee == null)
            {
                return NotFound();
            }

            return View(payee);
        }

        // GET: Payees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PayeeID,PayeeName,PhoneNumber,PayeeType,Street,City,State,Zip")] Payee payee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payee);
        }

        // GET: Payees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payee = await _context.Payees.FindAsync(id);
            if (payee == null)
            {
                return NotFound();
            }
            return View(payee);
        }

        // POST: Payees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PayeeID,PayeeName,PhoneNumber,PayeeType,Street,City,State,Zip")] Payee payee)
        {
            if (id != payee.PayeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayeeExists(payee.PayeeID))
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
            return View(payee);
        }


        private bool PayeeExists(int id)
        {
            return _context.Payees.Any(e => e.PayeeID == id);
        }

       /*private SelectList GetAllPayees()
        {
            List<PayeeType> SelectedPayeeType = PayeeType.ToList();


            SelectList SelectedPayeeType = new SelectList(SelectedPayeeType.OrderBy(g => g.PayeeID), "PayeeID", "PayeeName");

            return SelectedPayeeType;
        }*/
    }
}
