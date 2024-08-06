using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        public static SqlConnection conectar()
        {

            SqlConnection cn = new SqlConnection("SERVER=DESKTOP-K6LB0LV\\SQLEXPRESS; DATABASE=LibreriaGitano;integrated security=true;");
            cn.Open();
            return cn;
        }

    }
}
