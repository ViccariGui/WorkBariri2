using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WorkBariri.Models;

namespace WorkBariri2.Models
{
    [Table("AvaliacaoEmpresas")]
    public class AvaliacaoEmpresa
    {

        [Column("AvaliacaoEmpresasId")]
        [Display(Name = "Código da empresa")]
        public int AvaliacaoEmpresasId { get; set; }

        [Column("Feedback")]
        [Display(Name = "Feedback sobre a empresa:")]
        public string Feedback { get; set; } = string.Empty;

        [Column("EscalaEstrela")]
        [Display(Name = "Coloque sua avaliação para a empresa:")]
        public string EscalaEstrela { get; set; } = string.Empty;

        [Column("UsuariosId")]
        [Display(Name = "Usuário")]
        public Guid UsuariosId { get; set; }
        public Usuarios? Usuarios { get; set; }

        [Column("EmpresasId")]
        [Display(Name = "Empresa")]
        public Guid EmpresasId { get; set; }
        public Empresas? Empresas { get; set; }

    }
}

