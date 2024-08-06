using System;
using System.Collections.Generic;
using System.Data;
using Datos;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class NegocioLibros
    {
        private DatosLibros datosLibros = new DatosLibros();
       

        

        public DataTable LlenarGrid()
        {
            return datosLibros.ObtenerTodosLosLibros();
        }

        public DataTable BuscarLibros(string titulo, string autor, string codigo, string genero, string editorial)
        {
            return datosLibros.BuscarLibros(titulo, autor, codigo, genero, editorial);
        }

        public void AgregarLibro(string titulo, string autor, string isbn, string fechaPublicacion, string editorial, decimal precio, int paginas, int genero, string descripcion, int stock, int proveedorID)
        {
            datosLibros.AgregarLibro(titulo, autor, isbn, fechaPublicacion, editorial, precio, paginas, genero, descripcion, stock, proveedorID);
        }
    

        public void SumarStock(string isbn, int cantidad)
        {
            datosLibros.SumarStock(isbn, cantidad); // Usar la instancia
        }
       

        public void ModificarLibro(int id, string titulo, string autor, string isbn, string fechaPublicacion, string editorial, decimal precio, int paginas, string genero, string descripcion, int stock)
        {
            datosLibros.Modificar(id, titulo, autor, isbn, fechaPublicacion, editorial, precio, paginas, genero, descripcion, stock);
        }
        public DataTable GetBookByISBN(string isbn)
        {
            return datosLibros.GetBookByISBN(isbn);
        }

        public void RestarStock(string isbn, int cantidad)
        {
            DatosLibros.RestarStock(isbn, cantidad);
        }
        public DataTable ObtenerHistorialModificaciones(string titulo, string isbn, DateTime? desde, DateTime? hasta)
        {
            return datosLibros.ObtenerHistorialModificaciones(titulo, isbn, desde, hasta);
        }
        public DataTable ObtenerHistorialModificacion()
        {
            return datosLibros.ObtenerHistorialLibros();
        }

    }
}
