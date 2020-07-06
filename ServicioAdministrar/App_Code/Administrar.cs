using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Datos;
// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Administrar : IAdministrar
{
    //////////////////////////////////////BASE DE DATOS/////////////////////////////////////////////////////////////////////////////////
    private SqlConnection obtenerConexion()
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G5A74E7\SQLEXPRESS;Initial Catalog=pruebaBase2;Integrated Security=True");
        con.Open();
        return con;
    }

    ////////////////////////////////////////CONOCIMIENTO DAO/////////////////////////////////////////////////////////////////////////////
    private int obtenerId()
    {
        int id;
        SqlConnection con = obtenerConexion();
        String consulta = "SELECT MAX(id) FROM tblConocimiento;";
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
    public int buscarFilaPorPattern(String pattern)
    {
        Conocimiento auxiliar = new Conocimiento();
        SqlConnection con = obtenerConexion();
        String consulta = "SELECT * FROM tblConocimiento where pattern='" + pattern + "' ";
        SqlCommand comando = new SqlCommand(consulta, con);
        SqlDataReader reader = comando.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                auxiliar.Id = reader.GetInt32(0);
            }
        }
        con.Close();
        return auxiliar.Id;
    }
    public int insertarConocimiento(Conocimiento conocimiento)
    {
        Int32 nuevoId;
        nuevoId = obtenerId();
        SqlConnection con = obtenerConexion();
        String consulta = "INSERT INTO tblConocimiento (id, idTopic, pattern,idComplemento) VALUES ('" + nuevoId + "', '" + conocimiento.IdTopic + "', '" + conocimiento.Pattern + "', '" + conocimiento.IdComplemento + "')";
        System.Console.WriteLine(consulta);
        SqlCommand comando = new SqlCommand(consulta, con);
        int i = comando.ExecuteNonQuery();
        con.Close();
        return nuevoId;
    }
    public int eliminarConocimiento(int numero)
    {
        SqlConnection con = obtenerConexion();
        SqlCommand comando = new SqlCommand("delete from tblConocimiento where id='" + numero + "'", con);
        int i = comando.ExecuteNonQuery();
        con.Close();
        return i;
    }
    public List<Conocimiento> buscarPalabrasClave()
    {
        List<Conocimiento> conocimientos = new List<Conocimiento>();
        SqlConnection con = obtenerConexion();
        SqlCommand comando = new SqlCommand("Select * from tblConocimiento where idTopic=39", con);
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

    public Conocimiento buscarPalabraClavePorConocimiento(int idConocimiento)
    {
        Conocimiento auxiliar = new Conocimiento();
        SqlConnection con = obtenerConexion();
        SqlCommand comando = new SqlCommand("Select * from tblConocimiento where id='" + idConocimiento + "' ", con);
        SqlDataReader reader = comando.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                auxiliar.Id = reader.GetInt32(0);
                auxiliar.IdTopic = reader.GetInt32(1);
                auxiliar.Pattern = reader.GetString(2);
            }
        }
        con.Close();
        return auxiliar;
    }

    ///////////////////////////////////////////////////////////////CONOCIMIENTO TEMPLATE DAO///////////////////////////////////////////
    private int obtenerIdConocimientoTemplate()
    {
        int id;
        SqlConnection con = obtenerConexion();
        String consulta = "SELECT MAX(id) FROM tblConocimientoTemplate";
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
    public int eliminarConocimientoTemplate(int numero)
    {
        SqlConnection con = obtenerConexion();
        SqlCommand comando = new SqlCommand("delete from tblConocimientoTemplate where idTemplate='" + numero + "'", con);
        int i = comando.ExecuteNonQuery();
        con.Close();
        return i;
    }
    public int insertarConocimientoTemplate(ConocimientoTemplate conocimiento)
    {
        Int32 nuevoId;
        nuevoId = obtenerIdConocimientoTemplate();
        SqlConnection con = obtenerConexion();
        String consulta = "INSERT INTO tblConocimientoTemplate (id, idConocimiento, idTemplate) VALUES ('" + nuevoId + "', '" + conocimiento.IdConocimiento + "', '" + conocimiento.IdTemplate + "')";
        System.Console.WriteLine(consulta);
        SqlCommand comando = new SqlCommand(consulta, con);
        int i = comando.ExecuteNonQuery();
        con.Close();
        return nuevoId;
    }
    public ConocimientoTemplate buscarFilaPorConocimiento(int idConocimiento)
    {
        ConocimientoTemplate auxiliar = new ConocimientoTemplate();
        SqlConnection con = obtenerConexion();
        SqlCommand comando = new SqlCommand("Select * from tblConocimientoTemplate where idConocimiento='" + idConocimiento + "' ", con);
        SqlDataReader reader = comando.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
               
                auxiliar.Id = reader.GetInt32(0);
                auxiliar.IdConocimiento = reader.GetInt32(1);
                auxiliar.IdTemplate = reader.GetInt32(2);
               
            }
        }
        con.Close();
        return auxiliar;
    }

    public ConocimientoTemplate buscarFilaPorTemplate(int idTemplate)
    {
        ConocimientoTemplate auxiliar = new ConocimientoTemplate();
        SqlConnection con = obtenerConexion();
        SqlCommand comando = new SqlCommand("Select * from tblConocimientoTemplate where idTemplate='" + idTemplate + "' ", con);
        SqlDataReader reader = comando.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {

                auxiliar.Id = reader.GetInt32(0);
                auxiliar.IdConocimiento = reader.GetInt32(1);
                auxiliar.IdTemplate = reader.GetInt32(2);

            }
        }
        con.Close();
        return auxiliar;
    }


    //////////////////////////////////////////////////////////////// TEMPLATE DAO //////////////////////////////////////////////////////////////////////
    private int obtenerIdTemplate(int semestre)
    {
        int id;
        SqlConnection con = obtenerConexion();
        String consulta = "SELECT MAX(id) FROM tblTemplate;";
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

    public Template buscarFilaPorId(int id, int idSemestre)
    {
        Template auxiliar = new Template();
        SqlConnection con = obtenerConexion();
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
    public List<Template> listaTemplatesTopic(int id,int idSemestre)
    {
        List<Template> templates = new List<Template>();
        SqlConnection con = obtenerConexion();
        String consulta = "SELECT * FROM tblTemplate where idTopic='" + id + "' and idSemestre='" + idSemestre + "' ";
        SqlCommand comando = new SqlCommand(consulta, con);
        SqlDataReader reader = comando.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Template auxiliar = new Template();
                auxiliar.Id = reader.GetInt32(0);
                auxiliar.IdTemplate = reader.GetInt32(1);
                auxiliar.IdTopic = reader.GetInt32(2);
                auxiliar.Li = reader.GetString(3);
                auxiliar.IdSemestre = reader.GetInt32(4);
                templates.Add(auxiliar);
            }
        }
        con.Close();
        return templates;
    }
    public List<Template> listaTodoslosTemplates(int idSemestre,int idNuevoSemestre)
    {
        int idNuevo = obtenerIdTemplate(idSemestre)-1;
        List<Template> templates = new List<Template>();
        SqlConnection con = obtenerConexion();
        String consulta = "SELECT * FROM tblTemplate where idSemestre='" + idSemestre + "'";
        SqlCommand comando = new SqlCommand(consulta, con);
        SqlDataReader reader = comando.ExecuteReader();
        if (reader.HasRows)
        {
           
            while (reader.Read())
            {
                idNuevo = idNuevo + 1;
                Template auxiliar = new Template();
                auxiliar.Id = idNuevo;
                auxiliar.IdTemplate = reader.GetInt32(1);
                auxiliar.IdTopic = reader.GetInt32(2);
                auxiliar.Li = reader.GetString(3);
                auxiliar.IdSemestre = idNuevoSemestre;
                templates.Add(auxiliar);
            }
        }
        con.Close();
        return templates;
    }
    public int insertarListaTemplates(Template templates)
    {
        int i=0;
        SqlConnection con = obtenerConexion();
        String consulta = "INSERT INTO tblTemplate (id, idTemplate, idTopic, li, idSemestre) VALUES ('" + templates.Id + "',"+ "'"+templates.IdTemplate + "', '" + templates.IdTopic + "', '" + templates.Li + "', '" + templates.IdSemestre + "')";
        SqlCommand comando = new SqlCommand(consulta, con);
        i = comando.ExecuteNonQuery();    
        con.Close();
        return i;
    }
    public int insertarTemplate(Template template,int idSemestre)
    {
        Int32 nuevoId;
        nuevoId = obtenerIdTemplate(idSemestre);
        SqlConnection con = obtenerConexion();
        String consulta = "INSERT INTO tblTemplate (id, idTemplate, idTopic, li, idSemestre) VALUES ('" + nuevoId + "'," + "'" + nuevoId+ "', '" + template.IdTopic + "', '" + template.Li + "', '" + template.IdSemestre + "')";
        System.Console.WriteLine(consulta);
        SqlCommand comando = new SqlCommand(consulta, con);
        comando.ExecuteNonQuery();
        con.Close();
        return nuevoId;
    }

    public int modificarTemplate(Template template,int idSemestre)
    {
        SqlConnection con = obtenerConexion();
        String consulta = "UPDATE tblTemplate SET li= '" + template.Li + "' WHERE idTemplate= '" + template.IdTemplate + "' and idSemestre='" + idSemestre + "' ";
        SqlCommand comando2 = new SqlCommand(consulta, con);
        int i = comando2.ExecuteNonQuery();
        con.Close();
        return i;
    }
    public int modificarTemplateProfesor(Template template, int idSemestre)
    {
        SqlConnection con = obtenerConexion();
        String consulta = "UPDATE tblTemplate SET li= '" + template.Li + "' WHERE idTemplate= '" + template.Id + "' and idSemestre='" + idSemestre + "' ";
        SqlCommand comando2 = new SqlCommand(consulta, con);
        int i = comando2.ExecuteNonQuery();
        con.Close();
        return i;
    }
    public int eliminarTemplate(int id,int idSemestre)
    {
        SqlConnection con = obtenerConexion();
        SqlCommand comando = new SqlCommand("delete from tblTemplate where idTemplate='" + id + "' and idSemestre='" + idSemestre + "' ", con);
        int i = comando.ExecuteNonQuery();
        con.Close();
        return i;
    }

    ////////////////////////////////////////////////////SEMESTRE///////////////////////////////////////////////////////////////////////
    private int obtenerIdSemestre()
    {
        int id;
        SqlConnection con = obtenerConexion();
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
    public List<Semestre> todoslosSemestres()
    {
            List<Semestre> lista = new List<Semestre>();        
            SqlConnection con = obtenerConexion();
            String consulta = "SELECT * FROM tblSemestre";
            SqlCommand comando = new SqlCommand(consulta, con);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Semestre auxiliar = new Semestre();
                    auxiliar.Id = reader.GetInt32(0);
                    auxiliar.NombreSemestre = reader.GetString(1);
                    auxiliar.Seleccionado = reader.GetInt32(2);
                    lista.Add(auxiliar);
                }
            }
            con.Close();
            return lista;
    }

    public Semestre seleccionarSemestreTexto(string texto)
    {
        Semestre auxiliar = new Semestre();
        SqlConnection con = obtenerConexion();
        String consulta = "SELECT * FROM tblSemestre where nombreSemestre='"+texto+"'";
        SqlCommand comando = new SqlCommand(consulta, con);
        SqlDataReader reader = comando.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                auxiliar.Id = reader.GetInt32(0);
                auxiliar.NombreSemestre = reader.GetString(1);
                auxiliar.Seleccionado = reader.GetInt32(2);
              }
        }
        con.Close();
        return auxiliar;
    }
    public Semestre seleccionarSemestreId(int id)
    {
        Semestre auxiliar = new Semestre();
        SqlConnection con = obtenerConexion();
        String consulta = "SELECT * FROM tblSemestre where id='" + id + "'";
        SqlCommand comando = new SqlCommand(consulta, con);
        SqlDataReader reader = comando.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                auxiliar.Id = reader.GetInt32(0);
                auxiliar.NombreSemestre = reader.GetString(1);
                auxiliar.Seleccionado = reader.GetInt32(2);
            }
        }
        con.Close();
        return auxiliar;
    }
    public int semestreSeleccionado(int idAnterior, int idNuevo)
    {
        SqlConnection con = obtenerConexion();
        String consulta = "UPDATE tblSemestre SET seleccionado= '0' WHERE id= '" + idAnterior + "'";
        SqlCommand comando2 = new SqlCommand(consulta, con);
        comando2.ExecuteNonQuery();
        consulta = "UPDATE tblSemestre SET seleccionado= '1' WHERE id= '" + idNuevo + "'";
        SqlCommand comando3 = new SqlCommand(consulta, con);
        int i = comando3.ExecuteNonQuery();
        con.Close();
        return i;
    }
    public int insertarSemestre()
    {
        Int32 nuevoId;
        nuevoId = obtenerIdSemestre();
        if (nuevoId>10)
        {
            return -1;
        }
        Semestre semestre = new Semestre();
        semestre = seleccionarSemestreId(nuevoId-1);
        int año;
        string resultado2 = "";

        año = Convert.ToInt32(semestre.NombreSemestre.Substring(0, semestre.NombreSemestre.IndexOf("-")));
        resultado2 = semestre.NombreSemestre.Substring(5, 1);
        if (resultado2=="A")
        {
            resultado2 = "B";
        }
        else if (resultado2=="B")
        {
            año = año + 1;
            resultado2 = "A";
        }
        semestre.NombreSemestre =año+"-"+resultado2;
        semestre.Seleccionado = 0;
        SqlConnection con = obtenerConexion();
        String consulta = "INSERT INTO tblSemestre (id, nombreSemestre, seleccionado) VALUES ('" + nuevoId + "', '" + semestre.NombreSemestre + "', '" + semestre.Seleccionado + "')";
        System.Console.WriteLine(consulta);
        SqlCommand comando = new SqlCommand(consulta, con);
        int i = comando.ExecuteNonQuery();
        con.Close();
        return nuevoId;
    }

















}
