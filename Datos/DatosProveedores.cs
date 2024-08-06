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
              
                    Conexion.conectar();
                    string query = "UPDATE proveedores SET Nombre = @Nombre, Email = @Email, Telefono = @Telefono, Direccion = @Direccion WHERE ProveedorID = @ProveedorID";
                    SqlCommand command = new SqlCommand(query, Conexion.conectar());
                    command.Parameters.AddWithValue("@ProveedorID", id);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    

                   
                    command.ExecuteNonQuery();
                   
                
            }
        }
    }


