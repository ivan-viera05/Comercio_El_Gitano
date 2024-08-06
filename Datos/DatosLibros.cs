using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosLibros
    {
        public DataTable ObtenerTodosLosLibros()
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                DataTable dt = new DataTable();
                string sql = "select * from Libros";
                using (SqlCommand cmd = new SqlCommand(sql, conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                return dt;
            }
        }

        public DataTable BuscarLibros(string titulo, string autor, string codigo, string genero, string editorial)
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                DataTable dt = new DataTable();
                string consulta = "select * from Libros where 1=1 ";

                if (!string.IsNullOrEmpty(titulo))
                {
                    consulta += " AND Titulo LIKE @Titulo";
                }
                if (!string.IsNullOrEmpty(autor))
                {
                    consulta += " AND Autor LIKE @Autor";
                }
                if (!string.IsNullOrEmpty(codigo))
                {
                    consulta += " AND ISBN LIKE @Codigo";
                }
                if (!string.IsNullOrEmpty(genero))
                {
                    consulta += " AND Genero = @Genero";
                }
                if (!string.IsNullOrEmpty(editorial))
                {
                    consulta += " AND Editorial LIKE @Editorial";
                }

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    if (!string.IsNullOrEmpty(titulo))
                    {
                        cmd.Parameters.AddWithValue("@Titulo", "%" + titulo + "%");
                    }
                    if (!string.IsNullOrEmpty(autor))
                    {
                        cmd.Parameters.AddWithValue("@Autor", "%" + autor + "%");
                    }
                    if (!string.IsNullOrEmpty(codigo))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", "%" + codigo + "%");
                    }
                    if (!string.IsNullOrEmpty(genero))
                    {
                        cmd.Parameters.AddWithValue("@Genero", genero);
                    }
                    if (!string.IsNullOrEmpty(editorial))
                    {
                        cmd.Parameters.AddWithValue("@Editorial", "%" + editorial + "%");
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
        public DataTable GetBookByISBN(string isbn)
        {
            using (SqlConnection connection = Conexion.conectar())
            {
                string query = "SELECT Titulo, ISBN, Precio, Stock FROM Libros WHERE ISBN = @ISBN";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ISBN", isbn);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }
        public static void RestarStock(string isbn, int cantidadComprada)
        {
            using (SqlConnection connection = Conexion.conectar())
            {
                string query = "UPDATE Libros SET Stock = Stock - @cantidadComprada WHERE ISBN = @isbn";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@isbn", isbn);
                command.Parameters.AddWithValue("@cantidadComprada", cantidadComprada);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception($"No se encontró el libro con ISBN '{isbn}' en el inventario o no se pudo actualizar.");
                }
            }
        }
    }
}
