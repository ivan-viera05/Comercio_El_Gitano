using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioValidaciones
    {

        public bool EsSoloLetras(string texto)
        {
            // Verificar que el texto solo contenga letras y espacios
            return System.Text.RegularExpressions.Regex.IsMatch(texto, @"^[a-zA-Z\s]+$");
        }

        public bool ContieneNumeros(string texto)
        {
            // Verificar si el texto contiene algún número
            return System.Text.RegularExpressions.Regex.IsMatch(texto, @"\d");
        }

        public bool EsSoloNumeros(string texto)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(texto, @"^\d+$");
        }

        public bool EsLongitudValida(string texto, int longitudMaxima)
        {
            return texto.Length <= longitudMaxima;
        }
        public bool EsFechaValida(string fecha)
        {
            DateTime temp;
            return DateTime.TryParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp);
        }

        public bool ValidarNumerosYLongitud(string texto, int longitudMaxima)
        {
            return texto.All(char.IsDigit) && texto.Length <= longitudMaxima;
        }
        public bool ValidarEmail(string email)
        {
            // Expresión regular para validar el formato del correo electrónico
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, patron);
        }
    }
}
