using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Buscar_Facturas.Application.Interface;
using Prueba_Buscar_Facturas.Application.Services;
using Prueba_Buscar_Facturas.Domain.Models;

namespace Prueba_Buscar_Facturas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            var productos = _productoService.GetProducts();
            return Ok(productos);
        }
    }
}
