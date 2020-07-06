using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Datos;
namespace AccesoADatos
{
    public class EstudianteDAO
    {
        //Clase que posee los métodos para gestionar la tabla tblEstudiantes de la base de datos 
        public static int Autenticar(String correo,String password)
        {
            Estudiante auxiliar = new Estudiante();
            SqlConnection con = BaseDatos.obtenerConexion();
            SqlCommand comando = new SqlCommand("Select * from tblEstudiantes where correo='" + correo + "' " + "and contraseña='" + password + "'", con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int i = reader.GetInt32(0);
                    auxiliar.Correo = reader.GetString(1);
                    auxiliar.Password = reader.GetString(2);
                    con.Close();
                    return i;
                }
            }
            con.Close();
            return 0;
        }


        public static string ObtenerCorreo(int id)
        {
            string correo="";
            SqlConnection con = BaseDatos.obtenerConexion();
            SqlCommand comando = new SqlCommand("Select * from tblEstudiantes where id='" + id + "'", con);
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
