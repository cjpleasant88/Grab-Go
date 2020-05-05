using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrabAndGo.Data;
using GrabAndGo.Models;

namespace GrabAndGo.Controllers
{
    public class AislesController : Controller
    {
        private readonly GrabAndGoContext _context;

        public AislesController(GrabAndGoContext context)
        {
            _context = context;
        }

        // GET: Aisles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aisle.ToListAsync());
        }

        // GET: Aisles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aisle = await _context.Aisle
                .FirstOrDefaultAsync(m => m.AisleID == id);
            if (aisle == null)
            {
                return NotFound();
            }

            return View(aisle);
        }

        // GET: Aisles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aisles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AisleID,StoreID,AisleNumber,CategoryID")] Aisle aisle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aisle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aisle);
        }

        // GET: Aisles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aisle = await _context.Aisle.FindAsync(id);
            if (aisle == null)
            {
                return NotFound();
            }
            return View(aisle);
        }

        // POST: Aisles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AisleID,StoreID,AisleNumber,CategoryID")] Aisle aisle)
        {
            if (id != aisle.AisleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aisle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AisleExists(aisle.AisleID))
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
            return View(aisle);
        }

        // GET: Aisles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aisle = await _context.Aisle
                .FirstOrDefaultAsync(m => m.AisleID == id);
            if (aisle == null)
            {
                return NotFound();
            }

            return View(aisle);
        }

        // POST: Aisles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aisle = await _context.Aisle.FindAsync(id);
            _context.Aisle.Remove(aisle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AisleExists(int id)
        {
            return _context.Aisle.Any(e => e.AisleID == id);
        }
    }
}
