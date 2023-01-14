using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RagilHadiworoApp.Models;

namespace RagilHadiworoApp.Controllers
{
    public class FundingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FundingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fundings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Fundings.Include(f => f.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Fundings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Fundings == null)
            {
                return NotFound();
            }

            var funding = await _context.Fundings
                .Include(f => f.Customer)
                .FirstOrDefaultAsync(m => m.IDFunding == id);
            if (funding == null)
            {
                return NotFound();
            }

            return View(funding);
        }

        // GET: Fundings/Create
        public IActionResult Create()
        {
            ViewData["IDCustomer"] = new SelectList(_context.Customers, "IDCustomer", "Name");
            return View();
        }

        // POST: Fundings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDFunding,IDCustomer,Balance")] Funding funding)
        {
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {
                _context.Add(funding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCustomer"] = new SelectList(_context.Customers, "IDCustomer", "Name", funding.IDCustomer);
            return View(funding);
        }

        // GET: Fundings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Fundings == null)
            {
                return NotFound();
            }

            var funding = await _context.Fundings.FindAsync(id);
            if (funding == null)
            {
                return NotFound();
            }
            ViewData["IDCustomer"] = new SelectList(_context.Customers, "IDCustomer", "Name", funding.IDCustomer);
            return View(funding);
        }

        // POST: Fundings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IDFunding,IDCustomer,Balance")] Funding funding)
        {
            if (id != funding.IDFunding)
            {
                return NotFound();
            }
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FundingExists(funding.IDFunding))
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
            ViewData["IDCustomer"] = new SelectList(_context.Customers, "IDCustomer", "Name", funding.IDCustomer);
            return View(funding);
        }

        // GET: Fundings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Fundings == null)
            {
                return NotFound();
            }

            var funding = await _context.Fundings
                .Include(f => f.Customer)
                .FirstOrDefaultAsync(m => m.IDFunding == id);
            if (funding == null)
            {
                return NotFound();
            }

            return View(funding);
        }

        // POST: Fundings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Fundings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Fundings'  is null.");
            }
            var funding = await _context.Fundings.FindAsync(id);
            if (funding != null)
            {
                _context.Fundings.Remove(funding);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FundingExists(string id)
        {
          return _context.Fundings.Any(e => e.IDFunding == id);
        }
    }
}
