using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AltaLibro
    {
        public void AgregarLibro(string titulo, string autor, string isbn, string fechaPublicacion, string editorial, decimal precio, int paginas, int genero, string descripcion, int stock, int proveedorID)
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                string insertar = "INSERT INTO Libros (Titulo, Autor, ISBN, FechaPublicacion, Editorial, Precio, Paginas, Genero, Descripcion, Stock, ProveedorID) VALUES (@Titulo, @Autor, @ISBN, @FechaPublicacion, @Editorial, @Precio, @Paginas, @Genero, @Descripcion, @Stock, @ProveedorID)";
                using (SqlCommand cmd = new SqlCommand(insertar, conexion))
                {
                    cmd.Parameters.AddWithValue("@Titulo", titulo);
                    cmd.Parameters.AddWithValue("@Autor", autor);
                    cmd.Parameters.AddWithValue("@ISBN", isbn);
                    cmd.Parameters.AddWithValue("@FechaPublicacion", fechaPublicacion);
                    cmd.Parameters.AddWithValue("@Editorial", editorial);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@Paginas", paginas);
                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@Stock", stock);
                    cmd.Parameters.AddWithValue("@ProveedorID", proveedorID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SumarStock(string isbn, int cantidad)
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                string updateQuery = "UPDATE Libros SET Stock = Stock + @Cantidad WHERE ISBN = @Codigo";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, conexion))
                {
                    updateCommand.Parameters.AddWithValue("@Cantidad", cantidad);
                    updateCommand.Parameters.AddWithValue("@Codigo", isbn);
                    int result = updateCommand.ExecuteNonQuery();
                    if (result == 0)
                    {
                        throw new Exception("El libro no existe o no se pudo actualizar el stock.");
                    }
                }
            }
        }

    }
}
