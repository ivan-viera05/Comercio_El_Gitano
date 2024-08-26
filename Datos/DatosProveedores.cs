using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosProveedores
    {
        public DataTable ObtenerProveedorPorID(int proveedorID)
        {
            using (SqlConnection connection = Conexion.conectar())
            {
                string query = "SELECT * FROM Proveedores WHERE ProveedorID = @ProveedorID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProveedorID", proveedorID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
        public DataTable ObtenerTodosLosProovedores()
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                DataTable dt = new DataTable();
                string sql = "select * from Proveedores";
                using (SqlCommand cmd = new SqlCommand(sql, conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                return dt;
            }
        }
        public bool ExisteProveedorID(int proveedorID)
        {
            string consulta = "SELECT COUNT(1) FROM TuTabla WHERE ProveedorID = @ProveedorID";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            cmd.Parameters.AddWithValue("@ProveedorID", proveedorID);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        public DataTable ObtenerProveedorPorNombre(string nombre)
        {
            using (SqlConnection connection = Conexion.conectar())
            {
                string query = "SELECT * FROM Proveedores WHERE Nombre LIKE '%' + @Nombre + '%'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        public DataTable ObtenerTodosLibrosProveedores()
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                DataTable dt = new DataTable();
                string sql = "select ProveedorID, ISBN from Libros";
                using (SqlCommand cmd = new SqlCommand(sql, conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                return dt;
            }
        }

        public DataTable ObtenerProveedorPorID2(int proveedorID)
        {
            using (SqlConnection connection = Conexion.conectar())
            {
                string query = "SELECT ProveedorID, ISBN FROM Libros WHERE ProveedorID = @ProveedorID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProveedorID", proveedorID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
        public DataTable ObtenerProveedorPorISBN(string ISBN)
        {
            using (SqlConnection connection = Conexion.conectar())
            {
                string query = "SELECT ProveedorID, ISBN FROM Libros WHERE ISBN LIKE '%' + @ISBN + '%'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ISBN", ISBN);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        public bool InsertarProveedor(string nombre, string email, string telefono, string direccion)
        {
            using (SqlConnection connection = Conexion.conectar())
            {
                string query = "INSERT INTO Proveedores (Nombre, Email, Telefono, Direccion) VALUES (@Nombre, @Email, @Telefono, @Direccion)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Telefono", telefono);
                command.Parameters.AddWithValue("@Direccion", direccion);

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool EliminarProveedor(string ProveedorID)
        {
            try
            {


                // Eliminar el cliente de la tabla Clientes
                string queryEliminar = "DELETE FROM Proveedores WHERE ProveedorID = @ProveedorID";

                SqlCommand commandEliminar = new SqlCommand(queryEliminar, Conexion.conectar());

                commandEliminar.Parameters.AddWithValue("@ProveedorID", ProveedorID);
                int rowsAffected = commandEliminar.ExecuteNonQuery();

                return rowsAffected > 0;


            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al eliminar el cliente: " + ex.Message);
                return false;
            }
        }
        public bool DesactivarProveedor(string ProveedorID)
        {
            try
            {
                // Actualizar el estado del proveedor a inactivo
                string queryDesactivar = "UPDATE Proveedores SET Activo = 0 WHERE ProveedorID = @ProveedorID";
                using (SqlCommand commandDesactivar = new SqlCommand(queryDesactivar, Conexion.conectar()))
                {
                    commandDesactivar.Parameters.AddWithValue("@ProveedorID", ProveedorID);
                    int rowsAffected = commandDesactivar.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al desactivar el proveedor: " + ex.Message);
                return false;
            }
        }
        public bool ActualizarEstadoProveedor(string proveedorID, bool isActive)
        {
            try
            {
                string query = "UPDATE Proveedores SET Activo = @Activo WHERE ProveedorID = @ProveedorID";
                using (SqlCommand command = new SqlCommand(query, Conexion.conectar()))
                {
                    command.Parameters.AddWithValue("@Activo", isActive ? 1 : 0);
                    command.Parameters.AddWithValue("@ProveedorID", proveedorID);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el estado del proveedor: " + ex.Message);
                return false;
            }
        }

        public void ModificarProveedor(int id, string nombre, string email, string telefono, string direccion)
        {
            using (SqlConnection connection = Conexion.conectar())
            {
                // Obtener datos anteriores del proveedor
                string querySelect = "SELECT Nombre, Email, Telefono, Direccion, Activo FROM Proveedores WHERE ProveedorID = @ProveedorID";
                SqlCommand commandSelect = new SqlCommand(querySelect, connection);
                commandSelect.Parameters.AddWithValue("@ProveedorID", id);

                SqlDataAdapter adapter = new SqlDataAdapter(commandSelect);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string nombreAnterior = row["Nombre"].ToString();
                    string emailAnterior = row["Email"].ToString();
                    string telefonoAnterior = row["Telefono"].ToString();
                    string direccionAnterior = row["Direccion"].ToString();
                    bool activoAnterior = Convert.ToBoolean(row["Activo"]);

                    // Modificar el proveedor
                    string queryUpdate = "UPDATE Proveedores SET Nombre = @Nombre, Email = @Email, Telefono = @Telefono, Direccion = @Direccion WHERE ProveedorID = @ProveedorID";
                    SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection);
                    commandUpdate.Parameters.AddWithValue("@ProveedorID", id);
                    commandUpdate.Parameters.AddWithValue("@Nombre", nombre);
                    commandUpdate.Parameters.AddWithValue("@Email", email);
                    commandUpdate.Parameters.AddWithValue("@Telefono", telefono);
                    commandUpdate.Parameters.AddWithValue("@Direccion", direccion);
                    commandUpdate.ExecuteNonQuery();

                    // Insertar en ProveedorHistorial
                    InsertarProveedorHistorial(id, nombreAnterior, emailAnterior, telefonoAnterior, direccionAnterior, activoAnterior, nombre, email, telefono, direccion, activoAnterior);
                }
            }
        }

            public void InsertarProveedorHistorial(int proveedorID, string nombreAnterior, string emailAnterior, string telefonoAnterior, string direccionAnterior, bool activoAnterior, string nombreNuevo, string emailNuevo, string telefonoNuevo, string direccionNuevo, bool activoNuevo)
            {
                using (SqlConnection connection = Conexion.conectar())
                {
                    string query = "INSERT INTO ProveedorHistorial (ProveedorID, NombreAnterior, EmailAnterior, TelefonoAnterior, DireccionAnterior, ActivoAnterior, NombreNuevo, EmailNuevo, TelefonoNuevo, DireccionNuevo, ActivoNuevo, FechaModificacion) " +
                                   "VALUES (@ProveedorID, @NombreAnterior, @EmailAnterior, @TelefonoAnterior, @DireccionAnterior, @ActivoAnterior, @NombreNuevo, @EmailNuevo, @TelefonoNuevo, @DireccionNuevo, @ActivoNuevo, @FechaModificacion)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProveedorID", proveedorID);
                    command.Parameters.AddWithValue("@NombreAnterior", nombreAnterior);
                    command.Parameters.AddWithValue("@EmailAnterior", emailAnterior);
                    command.Parameters.AddWithValue("@TelefonoAnterior", telefonoAnterior);
                    command.Parameters.AddWithValue("@DireccionAnterior", direccionAnterior);
                    command.Parameters.AddWithValue("@ActivoAnterior", activoAnterior);
                    command.Parameters.AddWithValue("@NombreNuevo", nombreNuevo);
                    command.Parameters.AddWithValue("@EmailNuevo", emailNuevo);
                    command.Parameters.AddWithValue("@TelefonoNuevo", telefonoNuevo);
                    command.Parameters.AddWithValue("@DireccionNuevo", direccionNuevo);
                    command.Parameters.AddWithValue("@ActivoNuevo", activoNuevo);
                    command.Parameters.AddWithValue("@FechaModificacion", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }


        public DataTable BuscarHistorialModificaciones(int? proveedorID, string nombre, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            using (SqlConnection connection = Conexion.conectar())
            {
                StringBuilder query = new StringBuilder("SELECT * FROM ProveedorHistorial WHERE 1=1");

                if (proveedorID.HasValue)
                {
                    query.Append(" AND ProveedorID = @ProveedorID");
                }

                if (!string.IsNullOrEmpty(nombre))
                {
                    query.Append(" AND (NombreAnterior LIKE '%' + @Nombre + '%' OR NombreNuevo LIKE '%' + @Nombre + '%')");
                }

                if (fechaDesde.HasValue)
                {
                    query.Append(" AND FechaModificacion >= @FechaDesde");
                }

                if (fechaHasta.HasValue)
                {
                    query.Append(" AND FechaModificacion <= @FechaHasta");
                }

                SqlCommand command = new SqlCommand(query.ToString(), connection);

                if (proveedorID.HasValue)
                {
                    command.Parameters.AddWithValue("@ProveedorID", proveedorID.Value);
                }

                if (!string.IsNullOrEmpty(nombre))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                }

                if (fechaDesde.HasValue)
                {
                    command.Parameters.AddWithValue("@FechaDesde", fechaDesde.Value);
                }

                if (fechaHasta.HasValue)
                {
                    command.Parameters.AddWithValue("@FechaHasta", fechaHasta.Value);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
        public DataTable ObtenerHistorialModificaciones()
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                DataTable dt = new DataTable();
                string sql = "select * from ProveedorHistorial";
                using (SqlCommand cmd = new SqlCommand(sql, conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                return dt;
            }
        }


    }
    }



