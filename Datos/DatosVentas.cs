using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;



namespace Datos
{
    public class DatosVentas
    {
        public static void InsertarVenta(string dni, string isbn, int cantidad, decimal precioVenta)
        {
            using (SqlConnection connection = Conexion.conectar())
            {
                string query = "INSERT INTO Ventas (DNI, ISBN, FechaVenta, Cantidad, PrecioVenta) VALUES (@DNI, @ISBN, @FechaVenta, @Cantidad, @PrecioVenta)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@DNI", dni);
                cmd.Parameters.AddWithValue("@ISBN", isbn);
                cmd.Parameters.AddWithValue("@FechaVenta", DateTime.Now);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@PrecioVenta", precioVenta);
                cmd.ExecuteNonQuery();

                // Actualizar el stock del libro
                ActualizarStock(isbn, -cantidad);
            }
        }

        public static DataTable ObtenerTodosLasVentas()
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                string sql = "SELECT * FROM Ventas";
                using (SqlCommand cmd = new SqlCommand(sql, conexion))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static void ActualizarStock(string isbn, int cantidad)
        {
            using (SqlConnection connection = Conexion.conectar())
            {
                string query = "UPDATE Libros SET Stock = Stock + @Cantidad WHERE ISBN = @ISBN";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@ISBN", isbn);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable BuscarVentas(int? ventaID, string dni, string isbn, string fechaVenta, decimal? precioVenta)
        {

                Conexion.conectar();
                string query = "SELECT * FROM ventas WHERE (@VentaID IS NULL OR VentaID = @VentaID) AND (@DNI IS NULL OR DNI = @DNI) AND (@ISBN IS NULL OR ISBN = @ISBN) AND (@FechaVenta IS NULL OR FechaVenta = @FechaVenta) AND (@PrecioVenta IS NULL OR PrecioVenta = @PrecioVenta)";
                SqlCommand command = new SqlCommand(query,Conexion.conectar());
                command.Parameters.AddWithValue("@VentaID", (object)ventaID ?? DBNull.Value);
                command.Parameters.AddWithValue("@DNI", (object)dni ?? DBNull.Value);
                command.Parameters.AddWithValue("@ISBN", (object)isbn ?? DBNull.Value);
                command.Parameters.AddWithValue("@FechaVenta", (object)fechaVenta ?? DBNull.Value);              
                command.Parameters.AddWithValue("@PrecioVenta", (object)precioVenta ?? DBNull.Value);
              

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            
        }

    }
}
