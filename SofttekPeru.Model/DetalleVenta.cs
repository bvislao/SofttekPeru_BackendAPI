using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofttekPeru.Model
{
    public class DetalleVenta
    {
        [Key]
        public int IdDetalleVenta { get; set; }
        [Required]
        public int IdVenta { get; set; }
        [Required]
        public int IdArticulo { get; set; }
        [Required]
        public int cantidadArticulo { get; set; }
        [Required]
        public decimal precioArticulo { get; set; }
        [Required]
        public decimal descuento { get; set; }

    }
}
