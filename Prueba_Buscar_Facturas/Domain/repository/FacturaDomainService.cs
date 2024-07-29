using Prueba_Buscar_Facturas.Application.Dtos;
using Prueba_Buscar_Facturas.Domain.Interface;
using Prueba_Buscar_Facturas.Domain.Models;
using System.Data.SqlClient;

namespace Prueba_Buscar_Facturas.Domain.repository
{
    public class FacturaDomainService : IFacturaDomainService
    {
        private readonly string _connectionString;

        public FacturaDomainService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Factura> GetAllFacturas()
        {
            List<Factura> facturas = new List<Factura>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                string procedure = "spTblFacturas";
                SqlCommand command = new SqlCommand(procedure, connection);

                command.Parameters.AddWithValue("@Id", 0);
                command.Parameters.AddWithValue("@FechaEmisionFactura", DBNull.Value);
                command.Parameters.AddWithValue("@IdCliente", DBNull.Value);
                command.Parameters.AddWithValue("@NumeroFactura", DBNull.Value);
                command.Parameters.AddWithValue("@NumeroTotalArticulos", DBNull.Value);
                command.Parameters.AddWithValue("@SubTotalFacturas", DBNull.Value);
                command.Parameters.AddWithValue("@TotalImpuestos", DBNull.Value);
                command.Parameters.AddWithValue("@TotalFactura", DBNull.Value);
                command.Parameters.AddWithValue("@NroTransaccion", 2);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Factura factura = new Factura
                    {
                        Id = reader.GetInt32(0),
                        NumeroFactura = reader.GetInt32(1),
                        FechaEmisionFactura = reader.GetDateTime(2),
                        TotalFactura = reader.GetDecimal(3)
                    };

                    facturas.Add(factura);
                }
            }

            return facturas;
        }

        public int AddFactura(Factura factura)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string procedure = "spAddFactura";
                SqlCommand command = new SqlCommand(procedure, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FechaEmisionFactura", factura.FechaEmisionFactura);
                command.Parameters.AddWithValue("@IdCliente", factura.IdCliente);
                command.Parameters.AddWithValue("@NumeroFactura", factura.NumeroFactura);
                command.Parameters.AddWithValue("@NumeroTotalArticulos", factura.NumeroTotalArticulos);
                command.Parameters.AddWithValue("@SubTotalFacturas", factura.SubTotalFacturas);
                command.Parameters.AddWithValue("@TotalImpuestos", factura.TotalImpuestos);
                command.Parameters.AddWithValue("@TotalFactura", factura.TotalFactura);
                command.Parameters.AddWithValue("@NroTransaccion", 1);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                int idFactura = 0;
                while (reader.Read())
                {
                    idFactura = Convert.ToInt32(reader["ID"]);
                }
                return idFactura;
            }
        }

        public int AddDetalleFactura(DetalleFactura detalle)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string procedure = "spAddFactura";
                SqlCommand command = new SqlCommand(procedure, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdFactura", detalle.IdFactura);
                command.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                command.Parameters.AddWithValue("@CantidadDeProducto", detalle.CantidadDeProducto);
                command.Parameters.AddWithValue("@PrecioUnitarioProducto", detalle.PrecioUnitarioProducto);
                command.Parameters.AddWithValue("@SubtotalProducto", detalle.SubtotalProducto);
                command.Parameters.AddWithValue("@IdFactura", detalle.Notas);
                command.Parameters.AddWithValue("@NroTransaccion", 4);


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                int idFactura = 0;
                while (reader.Read())
                {
                    idFactura = Convert.ToInt32(reader["ID"]);
                }
                return idFactura;
            }
        }
    }
}
