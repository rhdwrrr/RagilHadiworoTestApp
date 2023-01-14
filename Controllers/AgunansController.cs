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
    public class AgunansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgunansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Agunans
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Agunans.Include(a => a.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Agunans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Agunans == null)
            {
                return NotFound();
            }

            var agunan = await _context.Agunans
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(m => m.AgunanID == id);
            if (agunan == null)
            {
                return NotFound();
            }

            return View(agunan);
        }

        // GET: Agunans/Create
        public IActionResult Create()
        {
            ViewData["IDCustomer"] = new SelectList(_context.Customers, "IDCustomer", "Name");
            return View();
        }

        // POST: Agunans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgunanID,IDCustomer,Type,Amount")] Agunan agunan)
        {
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {
                _context.Add(agunan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCustomer"] = new SelectList(_context.Customers, "IDCustomer", "Name", agunan.IDCustomer);
            return View(agunan);
        }

        // GET: Agunans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Agunans == null)
            {
                return NotFound();
            }

            var agunan = await _context.Agunans.FindAsync(id);
            if (agunan == null)
            {
                return NotFound();
            }
            ViewData["IDCustomer"] = new SelectList(_context.Customers, "IDCustomer", "Name", agunan.IDCustomer);
            return View(agunan);
        }

        // POST: Agunans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AgunanID,IDCustomer,Type,Amount")] Agunan agunan)
        {
            if (id != agunan.AgunanID)
            {
                return NotFound();
            }
            ModelState.Remove("Customer");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agunan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgunanExists(agunan.AgunanID))
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
            ViewData["IDCustomer"] = new SelectList(_context.Customers, "IDCustomer", "Name", agunan.IDCustomer);
            return View(agunan);
        }

        // GET: Agunans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Agunans == null)
            {
                return NotFound();
            }

            var agunan = await _context.Agunans
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(m => m.AgunanID == id);
            if (agunan == null)
            {
                return NotFound();
            }

            return View(agunan);
        }

        // POST: Agunans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Agunans == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Agunans'  is null.");
            }
            var agunan = await _context.Agunans.FindAsync(id);
            if (agunan != null)
            {
                _context.Agunans.Remove(agunan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgunanExists(string id)
        {
          return _context.Agunans.Any(e => e.AgunanID == id);
        }
    }
}
