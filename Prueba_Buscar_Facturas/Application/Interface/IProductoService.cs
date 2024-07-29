using Prueba_Buscar_Facturas.Domain.Models;

namespace Prueba_Buscar_Facturas.Application.Interface
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetProducts();
    }
}
