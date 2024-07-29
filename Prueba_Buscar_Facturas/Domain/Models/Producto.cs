namespace Prueba_Buscar_Facturas.Domain.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public byte[] ImagenProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string ext { get; set; }

    }
}
