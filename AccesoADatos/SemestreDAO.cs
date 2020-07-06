using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Datos;

namespace AccesoADatos
{
    public class SemestreDAO
    {
        //Clase que posee los métodos para gestionar la tabla tblSemestre de la base de datos 
        private static int obtenerId()
        {
            int id;
            SqlConnection con = BaseDatos.obtenerConexion();
            String consulta = "SELECT MAX(id) FROM tblSemestre;";
            SqlCommand comando = new SqlCommand(consulta, con);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            if (reader.IsDBNull(0))
            {
                id = 0;
            }
            else
            {
                id = reader.GetInt32(0);
            }
            con.Close();
            return id + 1;
        }


        public static int ChequearSemestre()
        {
            SqlConnection con = BaseDatos.obtenerConexion();
            int id=1;
            String consulta = "SELECT * FROM tblSemestre where seleccionado='1'";
            SqlCommand comando = new SqlCommand(consulta, con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
            }
            con.Close();
            return id;
           
        }

        public static string SemestreSeleccionado()
        {
            SqlConnection con = BaseDatos.obtenerConexion();
            string id="";
            String consulta = "SELECT * FROM tblSemestre where seleccionado='1'";
            SqlCommand comando = new SqlCommand(consulta, con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = reader.GetString(1);
                }
            }
            con.Close();
            return id;

        }


    }
}
