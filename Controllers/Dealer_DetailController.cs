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
    public class Dealer_DetailController : Controller
    {
        private readonly Property_Mgmt_MVCdatabase _context;

        public Dealer_DetailController(Property_Mgmt_MVCdatabase context)
        {
            _context = context;
        }

        // GET: Dealer_Detail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dealer_Detail.ToListAsync());
        }

        // GET: Dealer_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealer_Detail = await _context.Dealer_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealer_Detail == null)
            {
                return NotFound();
            }

            return View(dealer_Detail);
        }

        [Authorize]
        // GET: Dealer_Detail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dealer_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dealer_Name,Dealer_Address,Mobile,Email")] Dealer_Detail dealer_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dealer_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dealer_Detail);
        }

        [Authorize]
        // GET: Dealer_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealer_Detail = await _context.Dealer_Detail.FindAsync(id);
            if (dealer_Detail == null)
            {
                return NotFound();
            }
            return View(dealer_Detail);
        }

        // POST: Dealer_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dealer_Name,Dealer_Address,Mobile,Email")] Dealer_Detail dealer_Detail)
        {
            if (id != dealer_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dealer_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Dealer_DetailExists(dealer_Detail.Id))
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
            return View(dealer_Detail);
        }

        [Authorize]
        // GET: Dealer_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealer_Detail = await _context.Dealer_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealer_Detail == null)
            {
                return NotFound();
            }

            return View(dealer_Detail);
        }

        // POST: Dealer_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dealer_Detail = await _context.Dealer_Detail.FindAsync(id);
            _context.Dealer_Detail.Remove(dealer_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Dealer_DetailExists(int id)
        {
            return _context.Dealer_Detail.Any(e => e.Id == id);
        }
    }
}
