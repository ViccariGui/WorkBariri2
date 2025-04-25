using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkBariri2.Data;
using WorkBariri2.Models;

namespace WorkBariri2.Controllers
{

    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsuariosController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize(Roles = "Freelancer, Empresa")]
        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            // Verificar o usuario que esta autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                ModelState.AddModelError("Loggin", "Usuário não autenticado.");
                return RedirectToAction("Index", "Home");
            }

            // Filtar os usuarios que tem o mesmo TipoUsuario do usuario autenticado
            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(u => u.AppUserId == Guid.Parse(userId));

            // Retornar a lista com os usuarios que tem o mesmo TipoUsuario do usuario autenticado
            var usuarios = await _context.Usuario
                .Where(u => u.TipoUsuario == usuario.TipoUsuario)
                .ToListAsync();

            return View(usuarios);
        }

        [Authorize(Roles = "Freelancer")]
        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuario
                .FirstOrDefaultAsync(m => m.UsuariosId == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuariosId,Nome,AreaEsp,Sexo,Email,Senha,Telefone,CPF,CEP,FotoPerfil,TipoUsuario")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                // Setar o AppUserId com o Id do Usuario do Identity
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    ModelState.AddModelError("", "Usuário não autenticado.");
                    return View(usuarios);
                }

                // Verifica se o usuário já existe
                var usuarioExistente = await _context.Usuario
                    .FirstOrDefaultAsync(u => u.AppUserId == Guid.Parse(userId));

                if (usuarioExistente != null)
                {
                    ModelState.AddModelError("", "Usuário já cadastrado.");
                    return View(usuarios);
                }
                usuarios.AppUserId = Guid.Parse(userId);
                var identityUser = await _context.Users.FindAsync(userId);
                usuarios.IdentityUser = identityUser;

                _context.Add(usuarios);

                //// Criar um registro no AspNetUsersRoles com o Tipo de Usuário
                //var role = new IdentityUserRole<string>
                //{
                //    UserId = usuarios.AppUserId.ToString(),
                //    RoleId = _context.Roles.FirstOrDefault(r => r.Name == usuarios.TipoUsuario).Id // Defina o ID do papel desejado aqui
                //};
                //_context.UserRoles.Add(role);

                // Adicionar a role ao Usuario
                await _userManager.AddToRoleAsync(identityUser, usuarios.TipoUsuario);

                // Atualizar o cookie de autenticação
                await _signInManager.RefreshSignInAsync(identityUser);


                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(usuarios);
        }
        [Authorize(Roles = "Freelancer")]
        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuario.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }
        [Authorize(Roles = "Freelancer")]
        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuariosId,Nome,AreaEsp,Sexo,Email,Senha,Telefone,CPF,CEP,FotoPerfil,TipoUsuario")] Usuarios usuarios)
        {
            if (id != usuarios.UsuariosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.UsuariosId))
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
            return View(usuarios);
        }
        [Authorize(Roles = "Freelancer")]
        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuario
                .FirstOrDefaultAsync(m => m.UsuariosId == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }
        [Authorize(Roles = "Freelancer")]
        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Usuario'  is null.");
            }
            var usuarios = await _context.Usuario.FindAsync(id);
            if (usuarios != null)
            {
                _context.Usuario.Remove(usuarios);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosExists(int id)
        {
            return (_context.Usuario?.Any(e => e.UsuariosId == id)).GetValueOrDefault();
        }
    }
}
