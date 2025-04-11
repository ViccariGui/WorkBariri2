using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkBariri.Models
{
    public class Empresas
    {
        [Column("EmpresasId")]
        [Display(Name = "Código da Empresa")]
        public int EmpresasId { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("CNPJ")]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; } = string.Empty;

        [Column("Localizacao")]
        [Display(Name = "Localização")]
        public string Localizacao { get; set; } = string.Empty;

        [Column("RamoEmpresa")]
        [Display(Name = "Ramo Da Empresa")]
        public string RamoEmpresa { get; set; } = string.Empty;

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; } = string.Empty;

    }
}