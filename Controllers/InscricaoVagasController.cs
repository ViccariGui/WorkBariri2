using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkBariri2.Data;
using WorkBariri2.Models;

namespace WorkBariri2.Controllers
{
    public class InscricaoVagasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InscricaoVagasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InscricaoVagas
        public async Task<IActionResult> Index()
        {
              return _context.InscricaoVaga != null ? 
                          View(await _context.InscricaoVaga.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InscricaoVaga'  is null.");
        }

        // GET: InscricaoVagas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InscricaoVaga == null)
            {
                return NotFound();
            }

            var inscricaoVagas = await _context.InscricaoVaga
                .FirstOrDefaultAsync(m => m.InscricaoVagasId == id);
            if (inscricaoVagas == null)
            {
                return NotFound();
            }

            return View(inscricaoVagas);
        }

        // GET: InscricaoVagas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InscricaoVagas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InscricaoVagasId,UsuariosId,VagasId,ArquivoCurriculo,Status")] InscricaoVagas inscricaoVagas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscricaoVagas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inscricaoVagas);
        }

        // GET: InscricaoVagas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InscricaoVaga == null)
            {
                return NotFound();
            }

            var inscricaoVagas = await _context.InscricaoVaga.FindAsync(id);
            if (inscricaoVagas == null)
            {
                return NotFound();
            }
            return View(inscricaoVagas);
        }

        // POST: InscricaoVagas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InscricaoVagasId,UsuariosId,VagasId,ArquivoCurriculo,Status")] InscricaoVagas inscricaoVagas)
        {
            if (id != inscricaoVagas.InscricaoVagasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscricaoVagas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscricaoVagasExists(inscricaoVagas.InscricaoVagasId))
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
            return View(inscricaoVagas);
        }

        // GET: InscricaoVagas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InscricaoVaga == null)
            {
                return NotFound();
            }

            var inscricaoVagas = await _context.InscricaoVaga
                .FirstOrDefaultAsync(m => m.InscricaoVagasId == id);
            if (inscricaoVagas == null)
            {
                return NotFound();
            }

            return View(inscricaoVagas);
        }

        // POST: InscricaoVagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InscricaoVaga == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InscricaoVaga'  is null.");
            }
            var inscricaoVagas = await _context.InscricaoVaga.FindAsync(id);
            if (inscricaoVagas != null)
            {
                _context.InscricaoVaga.Remove(inscricaoVagas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscricaoVagasExists(int id)
        {
          return (_context.InscricaoVaga?.Any(e => e.InscricaoVagasId == id)).GetValueOrDefault();
        }
    }
}
