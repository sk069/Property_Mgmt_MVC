using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Property_Mgmt_MVC.Data;
using Property_Mgmt_MVC.Models;

namespace Property_Mgmt_MVC.Controllers
{
    public class Property_octionController : Controller
    {
        private readonly Property_Mgmt_MVCdatabase _context;

        public Property_octionController(Property_Mgmt_MVCdatabase context)
        {
            _context = context;
        }

        // GET: Property_oction
        public async Task<IActionResult> Index()
        {
            var property_Mgmt_MVCdatabase = _context.Property_oction.Include(p => p.Customer_Detail).Include(p => p.Dealer_Detail).Include(p => p.Property_Detail);
            return View(await property_Mgmt_MVCdatabase.ToListAsync());
        }

        // GET: Property_oction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property_oction = await _context.Property_oction
                .Include(p => p.Customer_Detail)
                .Include(p => p.Dealer_Detail)
                .Include(p => p.Property_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (property_oction == null)
            {
                return NotFound();
            }

            return View(property_oction);
        }

        [Authorize]
        // GET: Property_oction/Create
        public IActionResult Create()
        {
            ViewData["Customer_DetailId"] = new SelectList(_context.Customer_Detail, "Id", "Customer_Name");
            ViewData["Dealer_DetailId"] = new SelectList(_context.Dealer_Detail, "Id", "Dealer_Name");
            ViewData["Property_DetailId"] = new SelectList(_context.Property_Detail, "Id", "Area");
            return View();
        }

        // POST: Property_oction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Bid_Price,Property_DetailId,Customer_DetailId,Dealer_DetailId")] Property_oction property_oction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(property_oction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customer_DetailId"] = new SelectList(_context.Customer_Detail, "Id", "Customer_Name", property_oction.Customer_DetailId);
            ViewData["Dealer_DetailId"] = new SelectList(_context.Dealer_Detail, "Id", "Dealer_Name", property_oction.Dealer_DetailId);
            ViewData["Property_DetailId"] = new SelectList(_context.Property_Detail, "Id", "Area", property_oction.Property_DetailId);
            return View(property_oction);
        }

        [Authorize]
        // GET: Property_oction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property_oction = await _context.Property_oction.FindAsync(id);
            if (property_oction == null)
            {
                return NotFound();
            }
            ViewData["Customer_DetailId"] = new SelectList(_context.Customer_Detail, "Id", "Customer_Name", property_oction.Customer_DetailId);
            ViewData["Dealer_DetailId"] = new SelectList(_context.Dealer_Detail, "Id", "Dealer_Name", property_oction.Dealer_DetailId);
            ViewData["Property_DetailId"] = new SelectList(_context.Property_Detail, "Id", "Area", property_oction.Property_DetailId);
            return View(property_oction);
        }

        // POST: Property_oction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Bid_Price,Property_DetailId,Customer_DetailId,Dealer_DetailId")] Property_oction property_oction)
        {
            if (id != property_oction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(property_oction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Property_octionExists(property_oction.Id))
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
            ViewData["Customer_DetailId"] = new SelectList(_context.Customer_Detail, "Id", "Customer_Name", property_oction.Customer_DetailId);
            ViewData["Dealer_DetailId"] = new SelectList(_context.Dealer_Detail, "Id", "Dealer_Name", property_oction.Dealer_DetailId);
            ViewData["Property_DetailId"] = new SelectList(_context.Property_Detail, "Id", "Area", property_oction.Property_DetailId);
            return View(property_oction);
        }

        [Authorize]
        // GET: Property_oction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property_oction = await _context.Property_oction
                .Include(p => p.Customer_Detail)
                .Include(p => p.Dealer_Detail)
                .Include(p => p.Property_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (property_oction == null)
            {
                return NotFound();
            }

            return View(property_oction);
        }

        // POST: Property_oction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var property_oction = await _context.Property_oction.FindAsync(id);
            _context.Property_oction.Remove(property_oction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Property_octionExists(int id)
        {
            return _context.Property_oction.Any(e => e.Id == id);
        }
    }
}
