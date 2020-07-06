using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Datos;

namespace AccesoADatos
{
    public class TemplateDAO
    {
        //Clase que posee los métodos para gestionar la tabla tblTemplate de la base de datos 
        public static Template buscarFilaPorId(int id, int idSemestre)
        {
            Template auxiliar = new Template();
            SqlConnection con = BaseDatos.obtenerConexion();
            String consulta = "SELECT * FROM tblTemplate where idTemplate='" + id + "' and idSemestre='" + idSemestre + "' ";
            SqlCommand comando = new SqlCommand(consulta, con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    auxiliar.Id = reader.GetInt32(0);
                    auxiliar.IdTemplate = reader.GetInt32(1);
                    auxiliar.IdTopic = reader.GetInt32(2);
                    auxiliar.Li = reader.GetString(3);
                    auxiliar.IdSemestre = reader.GetInt32(4);
                }
            }
            con.Close();
            return auxiliar;
        }

        public static int buscarIdTopicPorRespuesta(string respuesta,int idSemestre)
        {
            Template auxiliar = new Template();
            SqlConnection con = BaseDatos.obtenerConexion();
            String consulta = "SELECT * FROM tblTemplate where li='" + respuesta +"' and idSemestre='" + idSemestre + "' ";
            SqlCommand comando = new SqlCommand(consulta, con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                auxiliar.IdTopic = reader.GetInt32(2);
            }
            con.Close();
            return auxiliar.IdTopic;
        }
    }
}