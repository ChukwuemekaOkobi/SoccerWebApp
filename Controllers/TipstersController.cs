using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoccerWebApp.Models;

namespace SoccerWebApp.Controllers
{
    public class TipstersController : Controller
    {
        private readonly SoccerWebAppContext _context;

        public TipstersController(SoccerWebAppContext context)
        {
            _context = context;
        }

        // GET: Tipsters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipster.ToListAsync());
        }

        // GET: Tipsters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipster = await _context.Tipster
                 .Include(s => s.Predictions)
                 .ThenInclude(e => e.Match)
                 .AsNoTracking()
                .SingleOrDefaultAsync(m => m.TipsterId == id);
       


            if (tipster == null)
            {
                return NotFound();
            }

            return View(tipster);
        }

        // GET: Tipsters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipsters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipsterId,Name,Email,PhoneNumber")] Tipster tipster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tipster);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(tipster);
        }

        // GET: Tipsters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipster = await _context.Tipster.SingleOrDefaultAsync(m => m.TipsterId == id);
            if (tipster == null)
            {
                return NotFound();
            }
            return View(tipster);
        }

        // POST: Tipsters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipsterId,Name,Email,PhoneNumber")] Tipster tipster)
        {
            if (id != tipster.TipsterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipsterExists(tipster.TipsterId))
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
            return View(tipster);
        }

        // GET: Tipsters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipster = await _context.Tipster
                .SingleOrDefaultAsync(m => m.TipsterId == id);
            if (tipster == null)
            {
                return NotFound();
            }

            return View(tipster);
        }

        // POST: Tipsters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipster = await _context.Tipster.SingleOrDefaultAsync(m => m.TipsterId == id);
            _context.Tipster.Remove(tipster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipsterExists(int id)
        {
            return _context.Tipster.Any(e => e.TipsterId == id);
        }
    }
}
