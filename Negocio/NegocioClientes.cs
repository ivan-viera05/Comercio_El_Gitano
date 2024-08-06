using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Negocio
{
    public class NegocioClientes
    {
        private DatosClientes datosClientes = new DatosClientes();
        
        public DataTable ObtenerTodosLosClientes()
        {
            return datosClientes.ObtenerTodosLosClientes();
        }

        public DataTable BuscarClientes(string nombre, string apellido, string dni, string telefono, string email, string direccion)
        {
            return datosClientes.BuscarClientes(nombre, apellido, dni, telefono, email, direccion);
        }

        public static void AgregarCliente(string dni, string nombre, string apellido, string telefono, string direccion, string email)
        {
            DatosClientes.AgregarCliente(dni, nombre, apellido, telefono, direccion, email);
        }
        public void GuardarCliente(string dni, string nombre, string apellido, string email, string telefono, string direccion)
        {
            DatosClientes.InsertarOActualizarCliente(dni, nombre, apellido, email, telefono, direccion);
        }
        public bool EliminarCliente(string dni)
        {
            DatosClientes datosClientes = new DatosClientes();
            return datosClientes.EliminarClienteYActualizarVentas(dni);
        }


    }
}
