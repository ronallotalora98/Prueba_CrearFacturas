using Microsoft.AspNetCore.Mvc;
using Prueba_Buscar_Facturas.Application.Dtos;
using Prueba_Buscar_Facturas.Application.Interface;
using Prueba_Buscar_Facturas.Domain.Models;

namespace Prueba_Buscar_Facturas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _facturaService;
        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Factura>> Get()
        {
            var facturas = _facturaService.ObtenerTodasLasFacturas();
            return Ok(facturas);
        }

        [HttpPost]
        public ActionResult<CrearFacturaResponse> Post([FromBody] CrearFacturaRequest factura)
        {
            var response = _facturaService.AgregarFactura(factura);
            return Ok(response);
        }
    }
}
