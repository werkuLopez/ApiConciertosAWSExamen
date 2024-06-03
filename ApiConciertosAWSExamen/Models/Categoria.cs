﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiConciertosAWSExamen.Models
{
    [Table("categoriaevento")]
    public class Categoria
    {
        [Key]
        [Column("idcategoria")]
        public int IdCategoria { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
