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
    public class Property_DetailController : Controller
    {
        private readonly Property_Mgmt_MVCdatabase _context;

        public Property_DetailController(Property_Mgmt_MVCdatabase context)
        {
            _context = context;
        }

        // GET: Property_Detail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Property_Detail.ToListAsync());
        }

        // GET: Property_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property_Detail = await _context.Property_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (property_Detail == null)
            {
                return NotFound();
            }

            return View(property_Detail);
        }

        [Authorize]
        // GET: Property_Detail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Property_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Property_Type,Area,Price,Facilities")] Property_Detail property_Detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(property_Detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(property_Detail);
        }

        [Authorize]
        // GET: Property_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property_Detail = await _context.Property_Detail.FindAsync(id);
            if (property_Detail == null)
            {
                return NotFound();
            }
            return View(property_Detail);
        }

        // POST: Property_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Property_Type,Area,Price,Facilities")] Property_Detail property_Detail)
        {
            if (id != property_Detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(property_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Property_DetailExists(property_Detail.Id))
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
            return View(property_Detail);
        }

        [Authorize]
        // GET: Property_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property_Detail = await _context.Property_Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (property_Detail == null)
            {
                return NotFound();
            }

            return View(property_Detail);
        }

        // POST: Property_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var property_Detail = await _context.Property_Detail.FindAsync(id);
            _context.Property_Detail.Remove(property_Detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Property_DetailExists(int id)
        {
            return _context.Property_Detail.Any(e => e.Id == id);
        }
    }
}
