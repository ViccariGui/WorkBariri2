using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkBariri2.Data;
using WorkBariri2.Models;

namespace WorkBariri2.Controllers
{
    [Authorize(Roles = "Empresa")]

    public class VagasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VagasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vagas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vaga.Include(v => v.Empresas);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vagas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vaga == null)
            {
                return NotFound();
            }

            var vagas = await _context.Vaga
                .Include(v => v.Empresas)
                .FirstOrDefaultAsync(m => m.VagasId == id);
            if (vagas == null)
            {
                return NotFound();
            }

            return View(vagas);
        }

        // GET: Vagas/Create
        public IActionResult Create()
        {
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "EmpresasId", "EmpresasId");
            return View();
        }

        // POST: Vagas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VagasId,Especializacao,Quantidade,CargaHoraria,Salario,EmpresasId")] Vagas vagas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vagas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "EmpresasId", "EmpresasId", vagas.EmpresasId);
            return View(vagas);
        }

        // GET: Vagas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vaga == null)
            {
                return NotFound();
            }

            var vagas = await _context.Vaga.FindAsync(id);
            if (vagas == null)
            {
                return NotFound();
            }
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "EmpresasId", "EmpresasId", vagas.EmpresasId);
            return View(vagas);
        }

        // POST: Vagas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VagasId,Especializacao,Quantidade,CargaHoraria,Salario,EmpresasId")] Vagas vagas)
        {
            if (id != vagas.VagasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vagas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagasExists(vagas.VagasId))
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
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "EmpresasId", "EmpresasId", vagas.EmpresasId);
            return View(vagas);
        }

        // GET: Vagas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vaga == null)
            {
                return NotFound();
            }

            var vagas = await _context.Vaga
                .Include(v => v.Empresas)
                .FirstOrDefaultAsync(m => m.VagasId == id);
            if (vagas == null)
            {
                return NotFound();
            }

            return View(vagas);
        }

        // POST: Vagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vaga == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vaga'  is null.");
            }
            var vagas = await _context.Vaga.FindAsync(id);
            if (vagas != null)
            {
                _context.Vaga.Remove(vagas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagasExists(int id)
        {
            return (_context.Vaga?.Any(e => e.VagasId == id)).GetValueOrDefault();
        }
    }
}
