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

        public bool ActualizarCantidadLibro(string isbn, int nuevaCantidad, decimal nuevoPrecio)
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                string query = "UPDATE Libros SET Cantidad = @Cantidad, Precio = @Precio WHERE ISBN = @ISBN";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Cantidad", nuevaCantidad);
                cmd.Parameters.AddWithValue("@Precio", nuevoPrecio);
                cmd.Parameters.AddWithValue("@ISBN", isbn);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        public bool EliminarLibro(string isbn)
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                string query = "DELETE FROM Libros WHERE ISBN = @ISBN";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@ISBN", isbn);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
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

        public void Modificar(int id, string titulo, string autor, string isbn, string fechaPublicacion, string editorial, decimal precio, int paginas, string genero, string descripcion, int stock)
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                // Obtener los datos anteriores del libro
                DataTable dtLibroAnterior = ObtenerLibroPorID(id);

                if (dtLibroAnterior.Rows.Count > 0)
                {
                    DataRow rowAnterior = dtLibroAnterior.Rows[0];

                    // Insertar los datos anteriores y nuevos en el historial
                    string insertHistorialQuery = @"INSERT INTO LibrosHistorial
                        (LibroID, TituloAnterior, AutorAnterior, ISBNAnterior, FechaPublicacionAnterior, EditorialAnterior, PrecioAnterior, PaginasAnterior, GeneroAnterior, DescripcionAnterior, StockAnterior, ProveedorIDAnterior,
                        TituloNuevo, AutorNuevo, ISBNNuevo, FechaPublicacionNueva, EditorialNueva, PrecioNuevo, PaginasNuevas, GeneroNuevo, DescripcionNueva, StockNuevo, ProveedorIDNuevo, FechaModificacion)
                        VALUES
                        (@LibroID, @TituloAnterior, @AutorAnterior, @ISBNAnterior, @FechaPublicacionAnterior, @EditorialAnterior, @PrecioAnterior, @PaginasAnterior, @GeneroAnterior, @DescripcionAnterior, @StockAnterior, @ProveedorIDAnterior,
                        @TituloNuevo, @AutorNuevo, @ISBNNuevo, @FechaPublicacionNueva, @EditorialNueva, @PrecioNuevo, @PaginasNuevas, @GeneroNuevo, @DescripcionNueva, @StockNuevo, @ProveedorIDNuevo, GETDATE())";

                    using (SqlCommand cmdHistorial = new SqlCommand(insertHistorialQuery, conexion))
                    {
                        cmdHistorial.Parameters.AddWithValue("@LibroID", id);
                        cmdHistorial.Parameters.AddWithValue("@TituloAnterior", rowAnterior["Titulo"]);
                        cmdHistorial.Parameters.AddWithValue("@AutorAnterior", rowAnterior["Autor"]);
                        cmdHistorial.Parameters.AddWithValue("@ISBNAnterior", rowAnterior["ISBN"]);
                        cmdHistorial.Parameters.AddWithValue("@FechaPublicacionAnterior", rowAnterior["FechaPublicacion"]);
                        cmdHistorial.Parameters.AddWithValue("@EditorialAnterior", rowAnterior["Editorial"]);
                        cmdHistorial.Parameters.AddWithValue("@PrecioAnterior", rowAnterior["Precio"]);
                        cmdHistorial.Parameters.AddWithValue("@PaginasAnterior", rowAnterior["Paginas"]);
                        cmdHistorial.Parameters.AddWithValue("@GeneroAnterior", rowAnterior["Genero"]);
                        cmdHistorial.Parameters.AddWithValue("@DescripcionAnterior", rowAnterior["Descripcion"]);
                        cmdHistorial.Parameters.AddWithValue("@StockAnterior", rowAnterior["Stock"]);
                        cmdHistorial.Parameters.AddWithValue("@ProveedorIDAnterior", rowAnterior["ProveedorID"]);
                        cmdHistorial.Parameters.AddWithValue("@TituloNuevo", titulo);
                        cmdHistorial.Parameters.AddWithValue("@AutorNuevo", autor);
                        cmdHistorial.Parameters.AddWithValue("@ISBNNuevo", isbn);
                        cmdHistorial.Parameters.AddWithValue("@FechaPublicacionNueva", fechaPublicacion);
                        cmdHistorial.Parameters.AddWithValue("@EditorialNueva", editorial);
                        cmdHistorial.Parameters.AddWithValue("@PrecioNuevo", precio);
                        cmdHistorial.Parameters.AddWithValue("@PaginasNuevas", paginas);
                        cmdHistorial.Parameters.AddWithValue("@GeneroNuevo", genero);
                        cmdHistorial.Parameters.AddWithValue("@DescripcionNueva", descripcion);
                        cmdHistorial.Parameters.AddWithValue("@StockNuevo", stock);
                        cmdHistorial.Parameters.AddWithValue("@ProveedorIDNuevo", DBNull.Value); // Valor nulo para ProveedorIDNuevo si es necesario

                        cmdHistorial.ExecuteNonQuery();
                    }
                }

                // Actualizar los datos del libro
                string modificar = @"UPDATE Libros SET
                    Titulo = @titulo, Autor = @autor, ISBN = @ISBN, FechaPublicacion = @fechaPublicacion, Editorial = @editorial, Precio = @precio, Paginas = @paginas, Genero = @genero, Descripcion = @descripcion, Stock = @stock
                    WHERE LibroID = @id";

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
        }
        public DataTable ObtenerLibroPorID(int libroID)
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                string query = "SELECT * FROM Libros WHERE LibroID = @LibroID";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@LibroID", libroID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
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
        public DataTable ObtenerHistorialLibros()
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                string sql = "SELECT * FROM LibrosHistorial";
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
        public DataTable ObtenerHistorialModificaciones(string titulo, string isbn, DateTime? desde, DateTime? hasta)
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                DataTable dt = new DataTable();
                string consulta = "SELECT * FROM LibrosHistorial WHERE 1=1";

                // Añadir condiciones a la consulta según los parámetros proporcionados
                if (!string.IsNullOrEmpty(titulo))
                {
                    consulta += " AND TituloNuevo LIKE @Titulo";
                }
                if (!string.IsNullOrEmpty(isbn))
                {
                    consulta += " AND ISBNNuevo LIKE @ISBN";
                }
                if (desde.HasValue)
                {
                    consulta += " AND FechaModificacion >= @Desde";
                }
                if (hasta.HasValue)
                {
                    consulta += " AND FechaModificacion <= @Hasta";
                }

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    // Asignar valores a los parámetros de la consulta
                    if (!string.IsNullOrEmpty(titulo))
                    {
                        cmd.Parameters.AddWithValue("@Titulo", "%" + titulo + "%");
                    }
                    if (!string.IsNullOrEmpty(isbn))
                    {
                        cmd.Parameters.AddWithValue("@ISBN", "%" + isbn + "%");
                    }
                    if (desde.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@Desde", desde.Value);
                    }
                    if (hasta.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@Hasta", hasta.Value);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
        }
    }
}
    

