using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosClientes
    {
        public DataTable ObtenerTodosLosClientes()
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                string sql = "SELECT * FROM Clientes";
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

        public DataTable BuscarClientes(string nombre, string apellido, string dni, string telefono, string email, string direccion)
        {
            using (SqlConnection conexion = Conexion.conectar())
            {
                string consulta = "SELECT c.DNI, c.Nombre, c.Apellido, c.Email, c.Telefono, c.Direccion FROM Clientes c WHERE 1=1";
                if (!string.IsNullOrEmpty(nombre)) consulta += " AND c.Nombre LIKE @NombreCliente";
                if (!string.IsNullOrEmpty(apellido)) consulta += " AND c.Apellido LIKE @ApellidoCliente";
                if (!string.IsNullOrEmpty(dni)) consulta += " AND c.DNI LIKE @DNI";
                if (!string.IsNullOrEmpty(telefono)) consulta += " AND c.Telefono LIKE @Telefono";
                if (!string.IsNullOrEmpty(email)) consulta += " AND c.Email LIKE @Email";
                if (!string.IsNullOrEmpty(direccion)) consulta += " AND c.Direccion LIKE @Direccion";

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    if (!string.IsNullOrEmpty(nombre)) cmd.Parameters.AddWithValue("@NombreCliente", "%" + nombre + "%");
                    if (!string.IsNullOrEmpty(apellido)) cmd.Parameters.AddWithValue("@ApellidoCliente", "%" + apellido + "%");
                    if (!string.IsNullOrEmpty(dni)) cmd.Parameters.AddWithValue("@DNI", "%" + dni + "%");
                    if (!string.IsNullOrEmpty(telefono)) cmd.Parameters.AddWithValue("@Telefono", "%" + telefono + "%");
                    if (!string.IsNullOrEmpty(email)) cmd.Parameters.AddWithValue("@Email", "%" + email + "%");
                    if (!string.IsNullOrEmpty(direccion)) cmd.Parameters.AddWithValue("@Direccion", "%" + direccion + "%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }

        }
        public static void AgregarCliente(string dni, string nombre, string apellido, string telefono, string direccion, string email)
        {
            Conexion.conectar();
            string query = "INSERT INTO Clientes (DNI, Nombre, Apellido, Telefono, Direccion, Email) VALUES (@DNI, @Nombre, @Apellido, @Telefono, @Direccion, @Email)";
            SqlCommand command = new SqlCommand(query, Conexion.conectar());
            command.Parameters.AddWithValue("@DNI", dni);
            command.Parameters.AddWithValue("@Nombre", nombre);
            command.Parameters.AddWithValue("@Apellido", apellido);
            command.Parameters.AddWithValue("@Telefono", telefono);
            command.Parameters.AddWithValue("@Direccion", direccion);
            command.Parameters.AddWithValue("@Email", email);
            command.ExecuteNonQuery();

        }

        public static void InsertarOActualizarCliente(string dni, string nombre, string apellido, string email, string telefono, string direccion)
        {
            using (SqlConnection connection = Conexion.conectar())
            {
                string query = @"
                IF EXISTS (SELECT 1 FROM Clientes WHERE DNI = @DNI)
                    UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Telefono = @Telefono, Direccion = @Direccion WHERE DNI = @DNI
                ELSE
                    INSERT INTO Clientes (DNI, Nombre, Apellido, Email, Telefono, Direccion) VALUES (@DNI, @Nombre, @Apellido, @Email, @Telefono, @Direccion)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@DNI", dni);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@Direccion", direccion);
                cmd.ExecuteNonQuery();
            }
        }
        public bool EliminarCliente(string dni)
        {
            try
            {
                // Mover el cliente a la tabla ClientesEliminados
                string queryMover = "INSERT INTO ClientesEliminados (DNI, Nombre, Apellido, Email, Telefono, Direccion) " +
                                    "SELECT DNI, Nombre, Apellido, Email, Telefono, Direccion FROM Clientes WHERE DNI = @DNI";

               Conexion.conectar();



                SqlCommand commandMover = new SqlCommand(queryMover, Conexion.conectar());
                    
                        commandMover.Parameters.AddWithValue("@DNI", dni);
                        commandMover.ExecuteNonQuery();
                    

                    // Eliminar el cliente de la tabla Clientes
                    string queryEliminar = "DELETE FROM Clientes WHERE DNI = @DNI";

                SqlCommand commandEliminar = new SqlCommand(queryEliminar, Conexion.conectar());
                    
                        commandEliminar.Parameters.AddWithValue("@DNI", dni);
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
        public bool EliminarClienteYActualizarVentas(string dni)
        {
            using (SqlConnection connection = Conexion.conectar())
            {
                
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Mover cliente a ClientesEliminados y obtener EliminadoID
                        string queryMover = @"
                    INSERT INTO ClientesEliminados (DNI, Nombre, Apellido, Email, Telefono, Direccion) 
                    OUTPUT INSERTED.EliminadoID 
                    SELECT DNI, Nombre, Apellido, Email, Telefono, Direccion 
                    FROM Clientes 
                    WHERE DNI = @DNI";

                        SqlCommand cmdMover = new SqlCommand(queryMover, connection, transaction);
                        cmdMover.Parameters.AddWithValue("@DNI", dni);
                        int eliminadoId = (int)cmdMover.ExecuteScalar();

                        // Actualizar las ventas asociadas con el DNI eliminado a '000000'
                        string queryActualizar = @"
                    UPDATE Ventas 
                    SET EliminadoID = @EliminadoID, DNI = '000000' 
                    WHERE DNI = @DNI";

                        SqlCommand cmdActualizar = new SqlCommand(queryActualizar, connection, transaction);
                        cmdActualizar.Parameters.AddWithValue("@EliminadoID", eliminadoId);
                        cmdActualizar.Parameters.AddWithValue("@DNI", dni);
                        cmdActualizar.ExecuteNonQuery();

                        // Eliminar el cliente de la tabla Clientes
                        string queryEliminar = @"
                    DELETE FROM Clientes 
                    WHERE DNI = @DNI";

                        SqlCommand cmdEliminar = new SqlCommand(queryEliminar, connection, transaction);
                        cmdEliminar.Parameters.AddWithValue("@DNI", dni);
                        cmdEliminar.ExecuteNonQuery();

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error al eliminar el cliente: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
