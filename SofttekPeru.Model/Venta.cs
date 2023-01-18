using System.ComponentModel.DataAnnotations;

namespace SofttekPeru.Model
{
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public string? TipoComprobante { get; set; }
        [Required]
        public string? SerieComprobante { get; set; }
        [Required]
        public string? NumeroComprobante { get; set; }
        [Required]
        public DateTime FechaComprobante { get; set; }
        [Required]
        public decimal IGV { get; set; }
        [Required]
        public decimal MontoTotal { get; set; }
        [Required]
        public int Estado { get; set; }
        [Required]
        public int IdAsesor { get; set; }
    }
}