using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ModificarLibro
    {
        public void Modificar(int id, string titulo, string autor, string isbn, string fechaPublicacion, string editorial, decimal precio, int paginas, string genero, string descripcion, int stock)
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                string modificar = "UPDATE Libros SET Titulo=@titulo, Autor=@autor, ISBN=@ISBN, FechaPublicacion=@fechaPublicacion, Editorial=@editorial, Precio=@precio, Paginas=@paginas, Genero=@genero, Descripcion=@descripcion, Stock=@stock WHERE LibroID = @id";
                using (SqlCommand cmd = new SqlCommand(modificar, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@autor", autor);
                    cmd.Parameters.AddWithValue("@ISBN", isbn);
                    cmd.Parameters.AddWithValue("@fechaPublicacion", fechaPublicacion);
                    cmd.Parameters.AddWithValue("@editorial", editorial);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@paginas", paginas);
                    cmd.Parameters.AddWithValue("@genero", genero ?? (object)DBNull.Value); // Manejar valor nulo
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@stock", stock);

                    cmd.ExecuteNonQuery();
                }
            }
        }  // Método para llenar el DataGridView
        public DataTable ObtenerTodosLosLibros()
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                string query = "SELECT * FROM Libros";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable libros = new DataTable();
                        adapter.Fill(libros);
                        return libros;
                    }
                }
            }
        }



    }
}
