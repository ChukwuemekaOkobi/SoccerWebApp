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
    public class PredictionsController : Controller
    {
        private readonly SoccerWebAppContext _context;

        public PredictionsController(SoccerWebAppContext context)
        {
            _context = context;
        }

        // GET: Predictions
        public async Task<IActionResult> Index()
        {
            var soccerWebAppContext = _context.PredictionDatas.Include(p => p.Match).Include(p => p.Tipster);
            return View(await soccerWebAppContext.ToListAsync());
        }

        // GET: Predictions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prediction = await _context.PredictionDatas
                .Include(p => p.Match)
                .Include(p => p.Tipster)
                .SingleOrDefaultAsync(m => m.PredictionID == id);
            if (prediction == null)
            {
                return NotFound();
            }

            return View(prediction);
        }

        // GET: Predictions/Create
        public IActionResult Create()
        {
          
            ViewData["MatchID"] = new SelectList(_context.Match, "MatchID", "MatchName");
            ViewData["TipsterID"] = new SelectList(_context.Tipster, "TipsterId", "Email"); 
           
            return View();
        }

        // POST: Predictions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PredictionID,TipsterID,MatchID,predictionDate,matchOutcome")] PredictionData prediction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prediction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MatchID"] = new SelectList(_context.Match, "MatchID", "MatchName", prediction.MatchID);
            ViewData["TipsterID"] = new SelectList(_context.Tipster, "TipsterId", "Email", prediction.TipsterID);
            return View(prediction);
        }

        // GET: Predictions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prediction = await _context.PredictionDatas.SingleOrDefaultAsync(m => m.PredictionID == id);
            if (prediction == null)
            {
                return NotFound();
            }
            ViewData["MatchID"] = new SelectList(_context.Match, "MatchID", "MatchName", prediction.MatchID);
            ViewData["TipsterID"] = new SelectList(_context.Tipster, "TipsterId", "Email", prediction.TipsterID);
            return View(prediction);
        }

        // POST: Predictions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PredictionID,TipsterID,MatchID,predictionDate,matchOutcome")] PredictionData prediction)
        {
            if (id != prediction.PredictionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prediction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PredictionExists(prediction.PredictionID))
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
            ViewData["MatchID"] = new SelectList(_context.Match, "MatchID", "MatchName", prediction.MatchID);
            ViewData["TipsterID"] = new SelectList(_context.Tipster, "TipsterId", "Email", prediction.TipsterID);
            return View(prediction);
        }

        // GET: Predictions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prediction = await _context.PredictionDatas
                .Include(p => p.Match)
                .Include(p => p.Tipster)
                .SingleOrDefaultAsync(m => m.PredictionID == id);
            if (prediction == null)
            {
                return NotFound();
            }

            return View(prediction);
        }

        // POST: Predictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prediction = await _context.PredictionDatas.SingleOrDefaultAsync(m => m.PredictionID == id);
            _context.PredictionDatas.Remove(prediction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PredictionExists(int id)
        {
            return _context.PredictionDatas.Any(e => e.PredictionID == id);
        }
    }
}
