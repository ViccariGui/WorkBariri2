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
    [Authorize(Roles = "Freelancer")]
    public class AvaliacaoEmpresasController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AvaliacaoEmpresasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AvaliacaoEmpresas
        public async Task<IActionResult> Index()
        {
            var avalicacoes = await _context.AvaliacaoEmpresas.Include(u => u.Usuarios).ToListAsync();
            return View(avalicacoes);
        }

        // GET: AvaliacaoEmpresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AvaliacaoEmpresas == null)
            {
                return NotFound();
            }

            var avaliacaoEmpresa = await _context.AvaliacaoEmpresas
                .FirstOrDefaultAsync(m => m.AvaliacaoEmpresaId == id);
            if (avaliacaoEmpresa == null)
            {
                return NotFound();
            }

            return View(avaliacaoEmpresa);
        }

        // GET: AvaliacaoEmpresas/Create
        public IActionResult Create()
        {
            // Retornar a lista com os usuarios que tem o mesmo TipoUsuario do usuario autenticado
            var empresas = _context.Usuario.Where(u => u.TipoUsuario == "Empresa").ToList();
            ViewData["UsuarioId"] = new SelectList(empresas, "UsuariosId", "Nome");
            return View();
        }

        // POST: AvaliacaoEmpresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AvaliacaoEmpresaId,Feedback,EscalaEstrela,UsuariosId")] AvaliacaoEmpresa avaliacaoEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliacaoEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(avaliacaoEmpresa);
        }

        // GET: AvaliacaoEmpresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AvaliacaoEmpresas == null)
            {
                return NotFound();
            }

            var avaliacaoEmpresa = await _context.AvaliacaoEmpresas.FindAsync(id);
            if (avaliacaoEmpresa == null)
            {
                return NotFound();
            }
            return View(avaliacaoEmpresa);
        }

        // POST: AvaliacaoEmpresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AvaliacaoEmpresaId,Feedback,EscalaEstrela,UsuariosId")] AvaliacaoEmpresa avaliacaoEmpresa)
        {
            if (id != avaliacaoEmpresa.AvaliacaoEmpresaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacaoEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoEmpresaExists(avaliacaoEmpresa.AvaliacaoEmpresaId))
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
            return View(avaliacaoEmpresa);
        }

        // GET: AvaliacaoEmpresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AvaliacaoEmpresas == null)
            {
                return NotFound();
            }

            var avaliacaoEmpresa = await _context.AvaliacaoEmpresas
                .FirstOrDefaultAsync(m => m.AvaliacaoEmpresaId == id);
            if (avaliacaoEmpresa == null)
            {
                return NotFound();
            }

            return View(avaliacaoEmpresa);
        }

        // POST: AvaliacaoEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AvaliacaoEmpresas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AvaliacaoEmpresas'  is null.");
            }
            var avaliacaoEmpresa = await _context.AvaliacaoEmpresas.FindAsync(id);
            if (avaliacaoEmpresa != null)
            {
                _context.AvaliacaoEmpresas.Remove(avaliacaoEmpresa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvaliacaoEmpresaExists(int id)
        {
            return (_context.AvaliacaoEmpresas?.Any(e => e.AvaliacaoEmpresaId == id)).GetValueOrDefault();
        }
    }
}
