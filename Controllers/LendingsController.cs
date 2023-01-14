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
    public class LendingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LendingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lendings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lendings.Include(l => l.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lendings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Lendings == null)
            {
                return NotFound();
            }

            var lending = await _context.Lendings
                .Include(l => l.Customer)
                .FirstOrDefaultAsync(m => m.IDLending == id);
            if (lending == null)
            {
                return NotFound();
            }

            return View(lending);
        }

        // GET: Lendings/Create
        public IActionResult Create()
        {
            ViewData["IDCustomer"] = new SelectList(_context.Customers, "IDCustomer", "Name");
            return View();
        }

        // POST: Lendings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDLending,IDCustomer,Balance,Plafond")] Lending lending)
        {
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {
                _context.Add(lending);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCustomer"] = new SelectList(_context.Customers, "IDCustomer", "Name", lending.IDCustomer);
            return View(lending);
        }

        // GET: Lendings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Lendings == null)
            {
                return NotFound();
            }

            var lending = await _context.Lendings.FindAsync(id);
            if (lending == null)
            {
                return NotFound();
            }
            ViewData["IDCustomer"] = new SelectList(_context.Customers, "IDCustomer", "Name", lending.IDCustomer);
            return View(lending);
        }

        // POST: Lendings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IDLending,IDCustomer,Balance,Plafond")] Lending lending)
        {
            if (id != lending.IDLending)
            {
                return NotFound();
            }
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lending);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LendingExists(lending.IDLending))
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
            ViewData["IDCustomer"] = new SelectList(_context.Customers, "IDCustomer", "Name", lending.IDCustomer);
            return View(lending);
        }

        // GET: Lendings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Lendings == null)
            {
                return NotFound();
            }

            var lending = await _context.Lendings
                .Include(l => l.Customer)
                .FirstOrDefaultAsync(m => m.IDLending == id);
            if (lending == null)
            {
                return NotFound();
            }

            return View(lending);
        }

        // POST: Lendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Lendings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Lendings'  is null.");
            }
            var lending = await _context.Lendings.FindAsync(id);
            if (lending != null)
            {
                _context.Lendings.Remove(lending);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LendingExists(string id)
        {
          return _context.Lendings.Any(e => e.IDLending == id);
        }
    }
}
