using SofttekPeru.API.Context;
using SofttekPeru.API.Repository.Interfaces;
using SofttekPeru.Model;

namespace SofttekPeru.API.Repository
{
    public class VentaRepository : IVentaRepository
    {
        public VentaRepository()
        {
            using (var context = new ApiContext())
            {
                var ventas = new List<Venta>
                {
                    new Venta
                    {
                        IdVenta = 1,IdCliente = 10000,IdAsesor = 72854591,
                        TipoComprobante = "BOL",SerieComprobante = "B001",
                        NumeroComprobante = "001205",FechaComprobante = DateTime.Now,
                        MontoTotal = 500,IGV= Convert.ToDecimal(500*0.18),Estado = 1
                    },
                    new Venta
                    {
                        IdVenta = 2,IdCliente = 43432,IdAsesor = 72854591,
                        TipoComprobante = "BOL",SerieComprobante = "B001",
                        NumeroComprobante = "001206",FechaComprobante = DateTime.Now,
                        MontoTotal = 700,IGV= Convert.ToDecimal(700*0.18),Estado = 1
                    },new Venta
                    {
                        IdVenta = 3,IdCliente = 42,IdAsesor = 728545955,
                        TipoComprobante = "BOL",SerieComprobante = "B001",
                        NumeroComprobante = "001215",FechaComprobante = DateTime.Now,
                        MontoTotal = 100,IGV= Convert.ToDecimal(100*0.18),Estado = 1
                    },new Venta
                    {
                        IdVenta = 4,IdCliente = 530,IdAsesor = 72854522,
                        TipoComprobante = "BOL",SerieComprobante = "B001",
                        NumeroComprobante = "001139",FechaComprobante = DateTime.Now,
                        MontoTotal = 100,IGV= Convert.ToDecimal(100*0.18),Estado = 1
                    }

                };

                context.Ventas.AddRange(ventas);
                context.SaveChanges();
            }
        }    
        public List<Venta> getVentas()
        {
            using (var context = new ApiContext())
            {
                var list = context.Ventas
                    .ToList();
                return list;
            }
        }

        public List<Venta> getVentasPorAsesor(int IdAsesor)
        {
            using (var context = new ApiContext())
            {
                var list = context.Ventas
                    .Where(x=>x.IdAsesor == IdAsesor)
                    .ToList();
                return list;
            }
        }

        public List<Venta> nuevaVenta(Venta venta)
        {
            using (var context = new ApiContext())
            {
                context.Ventas.Add(venta);
                context.SaveChanges();

                var list = context.Ventas.ToList();
                return list;
            }
        }
    }
}
