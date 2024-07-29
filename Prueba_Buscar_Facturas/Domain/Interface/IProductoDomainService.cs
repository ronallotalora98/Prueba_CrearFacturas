using Prueba_Buscar_Facturas.Domain.Models;

namespace Prueba_Buscar_Facturas.Domain.Interface
{
    public interface IProductoDomainService
    {
        IEnumerable<Producto> GetProducts();
        
    }
}
