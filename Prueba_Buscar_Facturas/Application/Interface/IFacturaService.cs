using Prueba_Buscar_Facturas.Application.Dtos;
using Prueba_Buscar_Facturas.Domain.Models;
using System.Collections.Generic;

namespace Prueba_Buscar_Facturas.Application.Interface
{
    public interface IFacturaService
    {
        IEnumerable<Factura> ObtenerTodasLasFacturas();
        CrearFacturaResponse AgregarFactura(CrearFacturaRequest);

    }
}
