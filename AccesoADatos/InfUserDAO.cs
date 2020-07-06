using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Datos;

namespace AccesoADatos
{
    public class InfUserDAO
    {
        //Clase que posee los métodos para gestionar la tabla tblInfUser de la base de datos 
        private static int obtenerId()
        {
            int id;
            SqlConnection con = BaseDatos.obtenerConexion();
            String consulta = "SELECT MAX(id) FROM tblInfUser;";
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
        public static int MensajeAnterior(int idUser,int idTopic, int esAutenticado)
        {
            InfUser auxiliar = new InfUser();
            SqlConnection con = BaseDatos.obtenerConexion();
            String consulta = "SELECT * FROM tblInfUser where idUser = '" + idUser + "' AND  esAutenticado = '" + esAutenticado + "' order by id DESC";
            SqlCommand comando = new SqlCommand(consulta, con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                    reader.Read();
                    auxiliar.Id = reader.GetInt32(0);
                    auxiliar.IdUser = reader.GetInt32(1);
                    auxiliar.IdTopic = reader.GetInt32(2);
                    auxiliar.EsAutenticado= reader.GetInt32(3);
            }
            con.Close();
            if (auxiliar.IdTopic == idTopic)
            {
                return 1;
            }       
            return 0;
        }
         public static int insertarInfUser(InfUser infUser)
        {
            Int32 nuevoId;
            nuevoId = obtenerId();
            SqlConnection con = BaseDatos.obtenerConexion();
            try
            {
                
                String consulta = "INSERT INTO tblInfUser (id, idUser, idTopic, esAutenticado) VALUES ('" + nuevoId + "', '" + infUser.IdUser + "', '" + infUser.IdTopic + "', '" + infUser.EsAutenticado + "')";
                System.Console.WriteLine(consulta);
                SqlCommand comando = new SqlCommand(consulta, con);
                int i = comando.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
                return 1;
            }
            return nuevoId;
        }

        
    }
}

