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
    public class AvaliacaoUsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvaliacaoUsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AvaliacaoUsuarios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AvaliacaoUsuarios.Include(a => a.Empresas);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AvaliacaoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AvaliacaoUsuarios == null)
            {
                return NotFound();
            }

            var avaliacaoUsuarios = await _context.AvaliacaoUsuarios
                .Include(a => a.Empresas)
                .FirstOrDefaultAsync(m => m.AvaliacaoUsuariosId == id);
            if (avaliacaoUsuarios == null)
            {
                return NotFound();
            }

            return View(avaliacaoUsuarios);
        }

        // GET: AvaliacaoUsuarios/Create
        public IActionResult Create()
        {
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "EmpresasId", "EmpresasId");
            return View();
        }

        // POST: AvaliacaoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AvaliacaoUsuariosId,Feedback,EscalaEstrela,UsuariosId,EmpresasId")] AvaliacaoUsuarios avaliacaoUsuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliacaoUsuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "EmpresasId", "EmpresasId", avaliacaoUsuarios.EmpresasId);
            return View(avaliacaoUsuarios);
        }

        // GET: AvaliacaoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AvaliacaoUsuarios == null)
            {
                return NotFound();
            }

            var avaliacaoUsuarios = await _context.AvaliacaoUsuarios.FindAsync(id);
            if (avaliacaoUsuarios == null)
            {
                return NotFound();
            }
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "EmpresasId", "EmpresasId", avaliacaoUsuarios.EmpresasId);
            return View(avaliacaoUsuarios);
        }

        // POST: AvaliacaoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AvaliacaoUsuariosId,Feedback,EscalaEstrela,UsuariosId,EmpresasId")] AvaliacaoUsuarios avaliacaoUsuarios)
        {
            if (id != avaliacaoUsuarios.AvaliacaoUsuariosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacaoUsuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoUsuariosExists(avaliacaoUsuarios.AvaliacaoUsuariosId))
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
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "EmpresasId", "EmpresasId", avaliacaoUsuarios.EmpresasId);
            return View(avaliacaoUsuarios);
        }

        // GET: AvaliacaoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AvaliacaoUsuarios == null)
            {
                return NotFound();
            }

            var avaliacaoUsuarios = await _context.AvaliacaoUsuarios
                .Include(a => a.Empresas)
                .FirstOrDefaultAsync(m => m.AvaliacaoUsuariosId == id);
            if (avaliacaoUsuarios == null)
            {
                return NotFound();
            }

            return View(avaliacaoUsuarios);
        }

        // POST: AvaliacaoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AvaliacaoUsuarios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AvaliacaoUsuarios'  is null.");
            }
            var avaliacaoUsuarios = await _context.AvaliacaoUsuarios.FindAsync(id);
            if (avaliacaoUsuarios != null)
            {
                _context.AvaliacaoUsuarios.Remove(avaliacaoUsuarios);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvaliacaoUsuariosExists(int id)
        {
          return (_context.AvaliacaoUsuarios?.Any(e => e.AvaliacaoUsuariosId == id)).GetValueOrDefault();
        }
    }
}
