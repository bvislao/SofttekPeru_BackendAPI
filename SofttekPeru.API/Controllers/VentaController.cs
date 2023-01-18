using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SofttekPeru.API.Repository.Interfaces;
using SofttekPeru.Model;

namespace SofttekPeru.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        readonly IVentaRepository _ventaRepository;
        public VentaController(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        [HttpGet]
        public ActionResult<List<Venta>> GetVentas()
        {
            return Ok(_ventaRepository.getVentas());
        }

        [HttpGet]
        [Route("GetVentasForId")]
        public ActionResult<List<Venta>> GetVentasForId(int IdAsesor)
        {
            return Ok(_ventaRepository.getVentasPorAsesor(IdAsesor));
        }

        [HttpPost]
        public ActionResult<List<Venta>> AgregarVenta(Venta venta)
        {
            return Ok(_ventaRepository.nuevaVenta(venta));
        }
    }
}
