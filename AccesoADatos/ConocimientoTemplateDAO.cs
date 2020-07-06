using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Datos;

namespace AccesoADatos
{
    //Clase que posee los métodos para gestionar la tabla tblConocimientoTemplate de la base de datos 
    public class ConocimientoTemplateDAO
    {
             
        public static List<ConocimientoTemplate> buscarFilaPorConocimiento(int idConocimiento)
        {
            List<ConocimientoTemplate> conocimientos = new List<ConocimientoTemplate>();
            SqlConnection con = BaseDatos.obtenerConexion();
            SqlCommand comando = new SqlCommand("Select * from tblConocimientoTemplate where idConocimiento='" + idConocimiento + "' ",con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ConocimientoTemplate auxiliar = new ConocimientoTemplate();
                    auxiliar.Id = reader.GetInt32(0);
                    auxiliar.IdConocimiento = reader.GetInt32(1);
                    auxiliar.IdTemplate = reader.GetInt32(2);
                    conocimientos.Add(auxiliar);
                }
            }
            con.Close();
            return conocimientos;
        }


    }
}
