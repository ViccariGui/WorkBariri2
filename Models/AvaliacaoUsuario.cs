﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WorkBariri2.Models;

namespace WorkBariri2.Models
{

    [Table("AvaliacaoUsuarios")]
    public class AvaliacaoUsuarios
    {
        [Column("AvaliacaoId")]
        [Display(Name = "Código do usuário")]
        public int AvaliacaoUsuariosId { get; set; }

        [Column("Feedback")]
        [Display(Name = "Feedback do usuário")]
        public string Feedback { get; set; } = string.Empty;

        [Column("EscalaEstrela")]
        [Display(Name = "Coloque sua avaliação para o usuário")]
        public string EscalaEstrela { get; set; } = string.Empty;

        [Column("UsuariosId")]
        [Display(Name = "Usuário")]
        public Guid UsuariosId { get; set; }
        public Usuarios? Usuarios { get; set; }
    }
}
