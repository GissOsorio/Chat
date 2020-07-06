using Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IAdministrar
{
    ////////////////////////////////////////////////////CONOCIMIENTO DAO////////////////////////////////////////////
    [OperationContract]
    int buscarFilaPorPattern(String pattern);
    [OperationContract]
    int insertarConocimiento(Conocimiento conocimiento);
    [OperationContract]
    int eliminarConocimiento(int numero);
    [OperationContract]
    List<Conocimiento> buscarPalabrasClave();
    [OperationContract]
    Conocimiento buscarPalabraClavePorConocimiento(int idConocimiento);
    ////////////////////////////////////////////CONOCIMIENTO TEMPLATE DAO///////////////////////////////////////////
    [OperationContract]    
    int insertarConocimientoTemplate(ConocimientoTemplate conocimiento);
    [OperationContract]
    int eliminarConocimientoTemplate(int numero);
    [OperationContract]
    ConocimientoTemplate buscarFilaPorConocimiento(int idConocimiento);
    [OperationContract]
    ConocimientoTemplate buscarFilaPorTemplate(int idTemplate);
    //////////////////////////////////////////////////////////////// TEMPLATE DAO //////////////////////////////////////////////////////////////////////
    [OperationContract]
    int modificarTemplateProfesor(Template template, int idSemestre);
    [OperationContract]
    Template buscarFilaPorId(int id, int idSemestre);
    [OperationContract]
    List<Template> listaTemplatesTopic(int id, int idSemestre);
    [OperationContract]
    int insertarTemplate(Template template, int idSemestre);
    [OperationContract]
    int modificarTemplate(Template template, int idSemestre);
    [OperationContract]
    int eliminarTemplate(int id, int idSemestre);
    [OperationContract]
    List<Template> listaTodoslosTemplates(int id, int nuevoSemestre);
    [OperationContract]
    int insertarListaTemplates(Template templates);
    /////////////////////////////////////////////////SEMESTRE DAO///////////////////////////
    [OperationContract]
    List<Semestre> todoslosSemestres();
    [OperationContract]
    Semestre seleccionarSemestreTexto(string texto);
    [OperationContract]
    int semestreSeleccionado(int idAnterior, int idNuevo);
    [OperationContract]
    int insertarSemestre();

}

