using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace AccesoADatos
{
    public class PublicoDAO
    {
        //Clase que posee los métodos para gestionar la tabla tblPublico de la base de datos 
        private static int obtenerId()
        {
            int id;
            SqlConnection con = BaseDatos.obtenerConexion();
            String consulta = "SELECT MAX(id) FROM tblPublico;";
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
        public static int NoAutenticar()
        {
            Int32 nuevoId;
            nuevoId = obtenerId();
            SqlConnection con = BaseDatos.obtenerConexion();
            String consulta = "INSERT INTO tblPublico (id, correo) VALUES ('" + nuevoId + "', '" + "" + "')";
            System.Console.WriteLine(consulta);
            SqlCommand comando = new SqlCommand(consulta, con);
            int i = comando.ExecuteNonQuery();
            con.Close();
            return nuevoId;
        }

        public static int modificarPublico(int identificador,string correo)
        {
            SqlConnection con = BaseDatos.obtenerConexion();
            String consulta = "UPDATE tblPublico SET correo= '" + correo + "' WHERE id= '" + identificador + "' ";
            SqlCommand comando2 = new SqlCommand(consulta, con);
            int i = comando2.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public static string ObtenerCorreo(int id)
        {
            string correo = "";
            SqlConnection con = BaseDatos.obtenerConexion();
            SqlCommand comando = new SqlCommand("Select * from tblPublico where id='" + id + "'", con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    correo = reader.GetString(1);
                }
            }
            con.Close();
            return correo;
        }
    }
}
