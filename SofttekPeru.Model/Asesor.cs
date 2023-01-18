using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofttekPeru.Model
{
    public class Asesor
    {
        [Key]
        public int CodigoAsesor { get; set; }
        public string? PasswordAsesor { get; set; }
        public string? NombreAsesor { get; set; }
    }
}
