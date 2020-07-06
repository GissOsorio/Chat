using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Datos;

namespace AccesoADatos
{
    //Clase que posee los métodos para gestionar la tabla tblConocimiento de la base de datos 
    public class ConocimientoDAO
    {

        public static Conocimiento buscarFilaPorPattern(String pattern)
        {
            Conocimiento auxiliar = new Conocimiento();
            SqlConnection con = BaseDatos.obtenerConexion();
            String consulta = "SELECT * FROM tblConocimiento where pattern='" + pattern + "' ";
            SqlCommand comando = new SqlCommand(consulta, con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    auxiliar.Id = reader.GetInt32(0);
                    auxiliar.IdTopic = reader.GetInt32(1);
                    auxiliar.Pattern = reader.GetString(2);
                    auxiliar.IdComplemento = reader.GetInt32(3);
                }
            }
            con.Close();
            return auxiliar;
        }
        public static List<Conocimiento> buscarPorComplemento()
        {
            List<Conocimiento> conocimientos = new List<Conocimiento>();
            SqlConnection con = BaseDatos.obtenerConexion();
            SqlCommand comando = new SqlCommand("Select * from tblConocimiento where idComplemento=1", con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Conocimiento auxiliar = new Conocimiento();
                    auxiliar.Id = reader.GetInt32(0);
                    auxiliar.IdTopic = reader.GetInt32(1);
                    auxiliar.Pattern = reader.GetString(2);
                    conocimientos.Add(auxiliar);
                }
            }
            con.Close();
            return conocimientos;
        }


        public static List<Conocimiento> buscarPorAfirmacion()
        {
            List<Conocimiento> conocimientos = new List<Conocimiento>();
            SqlConnection con = BaseDatos.obtenerConexion();
            SqlCommand comando = new SqlCommand("Select * from tblConocimiento where idTopic=40", con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Conocimiento auxiliar = new Conocimiento();
                    auxiliar.Id = reader.GetInt32(0);
                    auxiliar.IdTopic = reader.GetInt32(1);
                    auxiliar.Pattern = reader.GetString(2);
                    conocimientos.Add(auxiliar);
                }
            }
            con.Close();
            return conocimientos;
        }

        public static List<Conocimiento> buscarPorNegacion()
        {
            List<Conocimiento> conocimientos = new List<Conocimiento>();
            SqlConnection con = BaseDatos.obtenerConexion();
            SqlCommand comando = new SqlCommand("Select * from tblConocimiento where idTopic=41", con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Conocimiento auxiliar = new Conocimiento();
                    auxiliar.Id = reader.GetInt32(0);
                    auxiliar.IdTopic = reader.GetInt32(1);
                    auxiliar.Pattern = reader.GetString(2);
                    conocimientos.Add(auxiliar);
                }
            }
            con.Close();
            return conocimientos;
        }
       
    }
}
