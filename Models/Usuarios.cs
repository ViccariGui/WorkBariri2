using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity;

namespace WorkBariri2.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Column("UsuariosId")]
        [Display(Name = "Id do Usuário")]
        public int UsuariosId { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("AreaEsp")]
        [Display(Name = "Area de Especialização/Ramo de Trabalho")]
        public string AreaEsp { get; set; } = string.Empty;

        [Column("Sexo")]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; } = string.Empty;

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; } = string.Empty;

        [Column("CPF")]
        [Display(Name = "CPF/CNPJ")]
        public string CPF { get; set; } = string.Empty;

        [Column("CEP")]
        [Display(Name = "CEP")]
        public string CEP { get; set; } = string.Empty;

        [Column("FotoPerfil")]
        [Display(Name = "Foto de Perfil")]
        public string FotoPerfil { get; set; } = string.Empty;

        [Column("TipoUsuario")]
        [Display(Name = "Tipo de Usuário")]
        public string TipoUsuario { get; set; } = string.Empty;


        public Guid? AppUserId { get; set; }
        public IdentityUser? IdentityUser { get; set; }
    }
}
