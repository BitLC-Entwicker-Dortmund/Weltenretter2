using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Weltenretter2.Models;

namespace Weltenretter2.Controllers
{
    public class BedrohungsController : Controller
    {
        private readonly Weltenretter2Context _context;

        public BedrohungsController(Weltenretter2Context context)
        {
            _context = context;
        }

        // GET: Bedrohungs
        public async Task<IActionResult> Index()
        {
            var weltenretter2Context = _context.Bedrohung.Include(b => b.Agressor).Include(b => b.Held);
            return View(await weltenretter2Context.ToListAsync());
        }

        // GET: Bedrohungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedrohung = await _context.Bedrohung
                .Include(b => b.Agressor)
                .Include(b => b.Held)
                .SingleOrDefaultAsync(m => m.BedrohungId == id);
            if (bedrohung == null)
            {
                return NotFound();
            }

            return View(bedrohung);
        }

        // GET: Bedrohungs/Create
        public IActionResult Create()
        {
            ViewData["AgressorId"] = new SelectList(_context.Agressor, "AgressorId", "Nachname");
            ViewData["HeldId"] = new SelectList(_context.Held, "HeldId", "Nachname");
            return View();
        }

        // POST: Bedrohungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BedrohungId,Name,Existent,AgressorId,HeldId")] Bedrohung bedrohung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bedrohung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgressorId"] = new SelectList(_context.Agressor, "AgressorId", "Nachname", bedrohung.AgressorId);
            ViewData["HeldId"] = new SelectList(_context.Held, "HeldId", "Nachname", bedrohung.HeldId);
            return View(bedrohung);
        }

        // GET: Bedrohungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedrohung = await _context.Bedrohung.SingleOrDefaultAsync(m => m.BedrohungId == id);
            if (bedrohung == null)
            {
                return NotFound();
            }
            ViewData["AgressorId"] = new SelectList(_context.Agressor, "AgressorId", "Nachname", bedrohung.AgressorId);
            ViewData["HeldId"] = new SelectList(_context.Held, "HeldId", "Nachname", bedrohung.HeldId);
            return View(bedrohung);
        }

        // POST: Bedrohungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BedrohungId,Name,Existent,AgressorId,HeldId")] Bedrohung bedrohung)
        {
            if (id != bedrohung.BedrohungId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bedrohung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BedrohungExists(bedrohung.BedrohungId))
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
            ViewData["AgressorId"] = new SelectList(_context.Agressor, "AgressorId", "Nachname", bedrohung.AgressorId);
            ViewData["HeldId"] = new SelectList(_context.Held, "HeldId", "Nachname", bedrohung.HeldId);
            return View(bedrohung);
        }

        // GET: Bedrohungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedrohung = await _context.Bedrohung
                .Include(b => b.Agressor)
                .Include(b => b.Held)
                .SingleOrDefaultAsync(m => m.BedrohungId == id);
            if (bedrohung == null)
            {
                return NotFound();
            }

            return View(bedrohung);
        }

        // POST: Bedrohungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bedrohung = await _context.Bedrohung.SingleOrDefaultAsync(m => m.BedrohungId == id);
            _context.Bedrohung.Remove(bedrohung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BedrohungExists(int id)
        {
            return _context.Bedrohung.Any(e => e.BedrohungId == id);
        }
    }
}
