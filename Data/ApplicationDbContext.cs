using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;
using System.Reflection.Emit;
using WorkBariri2.Models;

namespace WorkBariri2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Vagas> Vaga { get; set; }
        public DbSet<InscricaoVagas> InscricaoVaga { get; set; }
        public DbSet<AvaliacaoEmpresa> AvaliacaoEmpresas { get; set; }
        public DbSet<AvaliacaoUsuarios> AvaliacaoUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Usuarios>().ToTable("Usuarios");
            builder.Entity<Vagas>().ToTable("Vagas");
            builder.Entity<InscricaoVagas>().ToTable("InscricaoVagas");
            builder.Entity<AvaliacaoUsuarios>().ToTable("AvaliacaoEmpresas");
            builder.Entity<AvaliacaoEmpresa>().ToTable("AvaliacaoUsuarios");

            // Cadastrando as Roles padrão do Sistema
            Guid AdminGuid = Guid.NewGuid();
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Empresa",
                    NormalizedName = "EMPRESA"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Freelancer",
                    NormalizedName = "FREELANCER"
                }
            );

        }

    }
}