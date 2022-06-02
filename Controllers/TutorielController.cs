using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TutorielAuto.TutorielAuto.Models;

namespace TutorielAuto.Controllers
{
    public class TutorielController : Controller
    {
        private readonly TutorielAutoContext _context;

        public TutorielController(TutorielAutoContext context)
        {
            _context = context;
        }

        // GET: Tutoriel
        public async Task<IActionResult> Index()
        {
            var tutorielAutoContext = _context.Tutoriels.Include(t => t.Categorie);
            return View(await tutorielAutoContext.ToListAsync());
        }

        // GET: Tutoriel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tutoriels == null)
            {
                return NotFound();
            }

            var tutoriel = await _context.Tutoriels
                .Include(t => t.Categorie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tutoriel == null)
            {
                return NotFound();
            }

            return View(tutoriel);
        }

        // GET: Tutoriel/Create
        public IActionResult Create()
        {
            ViewData["CategorieId"] = new SelectList(_context.Categories, "Id", "Id");
            return View();
        }

        // POST: Tutoriel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titre,Dcc,Contenu,VideoLink,Dml,Type,CategorieId")] Tutoriel tutoriel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tutoriel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategorieId"] = new SelectList(_context.Categories, "Id", "Id", tutoriel.CategorieId);
            return View(tutoriel);
        }

        // GET: Tutoriel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tutoriels == null)
            {
                return NotFound();
            }

            var tutoriel = await _context.Tutoriels.FindAsync(id);
            if (tutoriel == null)
            {
                return NotFound();
            }
            ViewData["CategorieId"] = new SelectList(_context.Categories, "Id", "Id", tutoriel.CategorieId);
            return View(tutoriel);
        }

        // POST: Tutoriel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titre,Dcc,Contenu,VideoLink,Dml,Type,CategorieId")] Tutoriel tutoriel)
        {
            if (id != tutoriel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tutoriel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutorielExists(tutoriel.Id))
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
            ViewData["CategorieId"] = new SelectList(_context.Categories, "Id", "Id", tutoriel.CategorieId);
            return View(tutoriel);
        }

        // GET: Tutoriel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tutoriels == null)
            {
                return NotFound();
            }

            var tutoriel = await _context.Tutoriels
                .Include(t => t.Categorie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tutoriel == null)
            {
                return NotFound();
            }

            return View(tutoriel);
        }

        // POST: Tutoriel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tutoriels == null)
            {
                return Problem("Entity set 'TutorielAutoContext.Tutoriels'  is null.");
            }
            var tutoriel = await _context.Tutoriels.FindAsync(id);
            if (tutoriel != null)
            {
                _context.Tutoriels.Remove(tutoriel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TutorielExists(int id)
        {
          return (_context.Tutoriels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
