using Prueba_Buscar_Facturas.Application.Dtos;
using Prueba_Buscar_Facturas.Domain.Models;

namespace Prueba_Buscar_Facturas.Domain.Interface
{
    public interface IFacturaDomainService
    {
        IEnumerable<Factura> GetAllFacturas();
        int AddFactura(Factura factura);
        int AddDetalleFactura(DetalleFactura detalle);
    }
}
