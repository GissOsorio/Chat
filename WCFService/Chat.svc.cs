using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;


namespace WCFService
{
    //Contrato de servicio
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Chat
    {
        //Método que se expondrá como operación del servicio
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        public Chatear FuncionChat(string nombre,Int32 identificador,Int32 esAutenticado)
        {
            return new Chatear() {
                 Respuesta = Respuesta.Responder(nombre,identificador,esAutenticado)
            };
        }
        //Método que se expondrá como operación del servicio
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        public Autenticado Autenticar(String correo, String password)
        {
             return new Autenticado()
            {
                idAutenticado = Respuesta.Autenticar(correo, password)
            };
        }

        //Método que se expondrá como operación del servicio
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        public Autenticado NoAutenticar()
        {
            return new Autenticado()
            {
                idAutenticado = Respuesta.NoAutenticar()
            };
        }
    }
    //Contrato de datos
    [DataContract]
    public class Chatear
    {
        [DataMember]
        public string Respuesta { get; set; }
    }
    //Contrato de datos
    [DataContract]
    public class Autenticado
    {
        [DataMember]
        public int idAutenticado { get; set; }
    }
}
