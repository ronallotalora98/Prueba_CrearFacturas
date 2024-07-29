using Prueba_Buscar_Facturas.Domain.Interface;
using Prueba_Buscar_Facturas.Domain.Models;
using System.Data.SqlClient;

namespace Prueba_Buscar_Facturas.Domain.repository
{
    public class ProductoDomainService : IProductoDomainService
    {
        private readonly string _connectionString;

        public ProductoDomainService(string connectionString)
        {

            _connectionString = connectionString;

        }

        public IEnumerable<Producto> GetProducts()
        {
            try
            {
                List<Producto> products  = new List<Producto>();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string procedure = "spCatProductos";
                    SqlCommand command = new SqlCommand(procedure, connection);
                    command.Parameters.AddWithValue("@Id", 0);
                    command.Parameters.AddWithValue("@NombreProducto", DBNull.Value);
                    command.Parameters.AddWithValue("@ImagenProducto", DBNull.Value);
                    command.Parameters.AddWithValue("@PrecioUnitario", DBNull.Value);
                    command.Parameters.AddWithValue("@ext", DBNull.Value);
                    command.Parameters.AddWithValue("@NroTransaccion", 2);


                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Producto producto = new Producto
                        {
                            Id = reader.GetInt32(0),
                            NombreProducto = reader.GetString(1),
                            ImagenProducto = reader.IsDBNull(2) ? null : (byte[])reader[2],
                            PrecioUnitario = reader.GetDecimal(3),
                            ext = reader.GetString(4),
                        };

                        products.Add(producto);
                    }
                }

                return products;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
