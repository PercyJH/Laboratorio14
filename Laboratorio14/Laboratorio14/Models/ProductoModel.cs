using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratorio14.Models
{
    public class ProductoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public DateTime ProductoFechaIngreso { get; set; }
        public int ProductoCantidad { get; set; }
        public bool ProductoStock { get; set; }
    }
}  

