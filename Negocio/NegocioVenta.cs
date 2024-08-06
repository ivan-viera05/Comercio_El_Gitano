using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Datos.DatosVentas;

namespace Negocio
{
    public class NegocioVenta
    {
       
        private DatosVentas ventaData = new DatosVentas();
        public void ProcesarVenta(string dni, List<LibroVenta> libros)
        {
            foreach (LibroVenta libro in libros)
            {
                DatosVentas.InsertarVenta(dni, libro.ISBN, libro.Cantidad, libro.PrecioVenta);
            }
        }
        public static DataTable LlenarGrid()
        {
            return DatosVentas.ObtenerTodosLasVentas();
        }
        public class LibroVenta
        {
            public string ISBN { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioVenta { get; set; }
        }
        public DataTable BuscarVentas(int? ventaID, string dni, string isbn, string fechaVenta,decimal? precioVenta)
        {
            return ventaData.BuscarVentas(ventaID, dni, isbn, fechaVenta, precioVenta);
        }
    }
}
