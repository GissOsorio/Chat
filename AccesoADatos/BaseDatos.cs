using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class BaseDatos
    {
        //Clase que posee la conexión con la base de datos
        public static SqlConnection obtenerConexion()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G5A74E7\SQLEXPRESS;Initial Catalog=pruebaBase2;Integrated Security=True");
            con.Open();
            return con;
        }

    }
}
