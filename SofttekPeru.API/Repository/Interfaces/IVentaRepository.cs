using SofttekPeru.Model;

namespace SofttekPeru.API.Repository.Interfaces
{
    public interface IVentaRepository
    {
        public List<Venta> getVentas();
        public List<Venta> getVentasPorAsesor(int IdAsesor);
        public List<Venta> nuevaVenta(Venta venta);
    }
}
