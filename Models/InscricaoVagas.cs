using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkBariri2.Models
{
    [Table("InscricaoVagas")]
    public class InscricaoVagas
    {
        [Column("InscricaoId")]
        [Display(Name = "Código da Inscrição")]
        public int InscricaoVagasId { get; set; }

        [Column("UsuariosId")]
        [Display(Name = "Usuário")]
        public Guid UsuariosId { get; set; }
        public Usuarios? Usuarios { get; set; }

        [Column("VagasId")]
        [Display(Name = "Vaga")]
        public Guid VagasId { get; set; }
        public Vagas? Vagas { get; set; }

        [Column("ArquivoCurriculo")]
        [Display(Name = "Arquivo Currículo")]
        public string ArquivoCurriculo { get; set; } = string.Empty;

        [Column("Status")]
        [Display(Name = "Status da Inscrição")]
        public string Status { get; set; } = string.Empty;
    }
}
