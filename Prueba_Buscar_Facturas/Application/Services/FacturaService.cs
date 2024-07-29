using Prueba_Buscar_Facturas.Application.Dtos;
using Prueba_Buscar_Facturas.Application.Interface;
using Prueba_Buscar_Facturas.Domain.Interface;
using Prueba_Buscar_Facturas.Domain.Models;

namespace Prueba_Buscar_Facturas.Application.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaDomainService _facturaDomainService;

        public FacturaService(IFacturaDomainService facturaDomainService)
        {
            _facturaDomainService = facturaDomainService;
        }

        public IEnumerable<Factura> ObtenerTodasLasFacturas()
        {
            return _facturaDomainService.GetAllFacturas();
        }

        public CrearFacturaResponse AgregarFactura(CrearFacturaRequest crearFacturaRequest)
        {
            try
            {
                CrearFacturaResponse response = new CrearFacturaResponse();

                Factura factura = new Factura
                {
                    FechaEmisionFactura = crearFacturaRequest.fechaEmisionFactura,
                    IdCliente = crearFacturaRequest.IdCliente,
                    NumeroFactura = crearFacturaRequest.NumeroFactura,
                    NumeroTotalArticulos = crearFacturaRequest.NumeroTotalArticulos,
                    SubTotalFacturas = crearFacturaRequest.SubTotalFacturas,
                    TotalImpuestos = crearFacturaRequest.TotalImpuestos,
                    TotalFactura = crearFacturaRequest.TotalFactura,
                };

                var result = _facturaDomainService.AddFactura(factura);

                foreach (var item in crearFacturaRequest.DetalleFactura)
                {
                    item.IdFactura = result;

                }

                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
