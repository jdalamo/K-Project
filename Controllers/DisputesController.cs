using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fa19projectgroup16;
using fa19projectgroup16.DAL;

namespace fa19projectgroup16.Controllers
{
    public class DisputesController : Controller
    {
        private readonly AppDbContext _context;

        public DisputesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Disputes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Disputes.ToListAsync());
        }

        // GET: Disputes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispute = await _context.Disputes
                .FirstOrDefaultAsync(m => m.DisputeID == id);
            if (dispute == null)
            {
                return NotFound();
            }

            return View(dispute);
        }

        // GET: Disputes/Create
        public IActionResult Create(int id)
        {
            ViewBag.TransactionID = id;
            ViewBag.Error = null;

            return View();
        }

        // POST: Disputes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisputeID,CustomerComment,CorrectAmount")] Dispute dispute, int transactionID, string option)
        {
            if (ModelState.IsValid)
            {
                if (option == "No" && dispute.CorrectAmount == 0)
                {
                    ViewBag.Error = "If the amount is 0, then transaction should be deleted.";
                    ViewBag.TransactionID = transactionID;
                    return View(dispute);
                }
                if (option == "Yes" && dispute.CorrectAmount > 0)
                {
                    ViewBag.Error = "If the amount is greater than 0, then transaction should not be deleted";
                    ViewBag.TransactionID = transactionID;
                    return View(dispute);
                }
                dispute.Status = Status.Submitted;

                Transaction transaction = _context.Transactions
                    .FirstOrDefault(a => a.TransactionID == transactionID);

                dispute.Transaction = transaction;

                _context.Add(dispute);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Transactions", new { id = transactionID });
            }
            return View(dispute);
        }

        // GET: Disputes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispute = await _context.Disputes.FindAsync(id);
            if (dispute == null)
            {
                return NotFound();
            }
            return View(dispute);
        }

        // POST: Disputes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisputeID,CustomerComment,CorrectAmount,Status,ManagerComment")] Dispute dispute)
        {
            if (id != dispute.DisputeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dispute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisputeExists(dispute.DisputeID))
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
            return View(dispute);
        }

        // GET: Disputes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispute = await _context.Disputes
                .FirstOrDefaultAsync(m => m.DisputeID == id);
            if (dispute == null)
            {
                return NotFound();
            }

            return View(dispute);
        }

        // POST: Disputes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dispute = await _context.Disputes.FindAsync(id);
            _context.Disputes.Remove(dispute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisputeExists(int id)
        {
            return _context.Disputes.Any(e => e.DisputeID == id);
        }
    }
}
