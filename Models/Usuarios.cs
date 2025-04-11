using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        [Display(Name = "Area de Especialização")]
        public string AreaEsp { get; set; } = string.Empty;

        [Column("Sexo")]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; } = string.Empty;

        [Column("Email")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Column("Senha")]
        [Display(Name = "Senha")]
        public string Senha { get; set; } = string.Empty;

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; } = string.Empty;

        [Column("CPF")]
        [Display(Name = "CPF")]
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
    }
}
