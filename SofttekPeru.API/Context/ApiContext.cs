using Microsoft.EntityFrameworkCore;
using SofttekPeru.Model;

namespace SofttekPeru.API.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "VentasDb");
        }

        public DbSet<Asesor> Asesores { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    }
}
