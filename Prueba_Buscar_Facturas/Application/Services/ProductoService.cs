using Prueba_Buscar_Facturas.Application.Interface;
using Prueba_Buscar_Facturas.Domain.Interface;
using Prueba_Buscar_Facturas.Domain.Models;

namespace Prueba_Buscar_Facturas.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoDomainService _productoDomainService;
        public ProductoService(IProductoDomainService  productoDomain)
        {
            _productoDomainService = productoDomain;
        }

        public IEnumerable<Producto> GetProducts()
        {
            try
            {
                return _productoDomainService.GetProducts();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
