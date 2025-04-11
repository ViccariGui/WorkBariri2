﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkBariri2.Models
{
    [Table("Vagas")]
    public class Vagas
    {
        [Column("VagasId")]
        [Display(Name = "Código da Vaga")]
        public int VagasId { get; set; }

        [Column("Especializacao")]
        [Display(Name = "Especialização da Vaga")]
        public string Especializacao { get; set; } = string.Empty;

        [Column("Quantidade")]
        [Display(Name = "Quantidade de Vagas")]
        public int Quantidade { get; set; }

        [Column("CargaHoraria")]
        [Display(Name = "Carga Horária")]
        public string CargaHoraria { get; set; } = string.Empty;

        [Column("Salario")]
        [Display(Name = "Salário")]
        public string Salario { get; set; } = string.Empty;

        [Column("EmpresasId")]
        [Display(Name = "Empresa")]
        public Guid EmpresasId { get; set; }
        public Empresas? Empresas { get; set; }
    }
}
