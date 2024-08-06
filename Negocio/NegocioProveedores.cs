using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioProveedores
    {
        DatosProveedores datosProveedores = new DatosProveedores();

        public DataTable ObtenerProveedorPorID(int proveedorID)
        {
            return datosProveedores.ObtenerProveedorPorID(proveedorID);
        }

        public DataTable ObtenerProveedorPorNombre(string nombre)
        {
            return datosProveedores.ObtenerProveedorPorNombre(nombre);
        }
        public DataTable LlenarGrid() 
        {
            return datosProveedores.ObtenerTodosLosProovedores();
        }
        public DataTable LlenarProovedoresLibros() 
        {
            return datosProveedores.ObtenerTodosLibrosProveedores();
        }

        public DataTable BuscarProveedorID(int proveedorID)
        {
            return datosProveedores.ObtenerProveedorPorID2(proveedorID);
        }
        public DataTable BuscarProveedorISBN(string ISBN)
        {
            return datosProveedores.ObtenerProveedorPorISBN(ISBN);
        }

        public bool InsertarProveedor(string nombre, string email, string telefono, string direccion)
        {
            return datosProveedores.InsertarProveedor(nombre, email, telefono, direccion);
        }

        public bool BajaProveedor(string ProveedorID)
        {
            return datosProveedores.EliminarProveedor(ProveedorID);
        }
        public bool DesactivarProveedor(string ProveedorID)
        {
            return datosProveedores.DesactivarProveedor(ProveedorID);
        }

        public bool ActualizarEstadoProveedor(string proveedorID, bool isActive)
        {
            return datosProveedores.ActualizarEstadoProveedor(proveedorID, isActive);
        }

        public void ModificarProveedor(int id, string nombre, string email, string telefono, string direccion)
        {
           datosProveedores.ModificarProveedor(id, nombre, email, telefono, direccion);
        }

    }
}
