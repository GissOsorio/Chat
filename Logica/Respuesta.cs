using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using AccesoADatos;
using AIMLbot;
using Datos;
using RestSharp;
using System.Globalization;

namespace Logica
{
    public class Respuesta
    {
        public static string Responder(String mensaje, Int32 identificador,Int32 esAutenticado)
        {
            //Simulando una conversacion
            Conocimiento conocimiento = new Conocimiento();
            List<Template> templates = new List<Template>();
            InfUser informacionUsuario = new InfUser();
            String mensajeInicial = mensaje;
            String mensaje1 = SinTildes(mensaje);
            mensaje = mensaje1;
            //Revisar el semestre actual, así se repondera con la información actual
            int idSemestre = SemestreDAO.ChequearSemestre();
            //Revisar el contexto, si el mensaje anterior fue una afirmación o una negación
            string afirmacion = EsAfirmacion(mensaje, identificador, idSemestre,esAutenticado);
            string negacion = EsNegacion(mensaje, identificador, idSemestre,esAutenticado);
            //Revisar si el usuario ingresó al chat con autenticación
            if (esAutenticado==0)
            {
                //Si no es autenticado y envía su correo electrónico para enviarle información
                //Se revisa si el mensaje del usuario tiene la estructura de correo electrónico
                string a=IsValidEmailTexto(mensajeInicial);
                //Si es un correo electrónico
                if (a!=null)
                {
                    //Se guarda el correo electrónico junto al identificador del usuario no autenticado
                    PublicoDAO.modificarPublico(identificador,a);
                    //Se procede a verificar qué información desea el usuario y a enviar el mail
                    int ayuda = EnviaralMailNoAutenticado(identificador, esAutenticado,idSemestre);
                    //Se informa al usuario q la información ha sido enviada
                    if (ayuda==1)
                    {
                        return "Te envié la información al correo que me proporcionaste.";
                    }
                }
            }

            //Se revisa si el mensaje contiene una afirmación
            if (afirmacion!="")
            {
                //Si el mesaje contiene una afirmación se verifica el tema de la conversación anterior
                int ayuda=EnviaralMail(identificador, esAutenticado,idSemestre);
                //Si se le envió la información al usuario
                if (ayuda== 1)
                {
                    return afirmacion;
                //Si el usuario desea que se le envíe información pero no tiene registrado un correo electrónico
                }else if (ayuda==-1)
                {
                    return "¡No conozco tu correo electrónico! Indícame el correo electónico al que te enviaré la información.";
                }
            //Si el mensaje contiene una negación
            }else if (negacion != "")
            {
                //Se verifica el tema de la conversación anterior
                if (NoEnviaralMail(identificador,esAutenticado) == 1)
                {
                    return negacion;
                }        
            }
            else
            {
                //Sin contexto
                //Busca en la base el patron exacto
                conocimiento = ConocimientoDAO.buscarFilaPorPattern(mensaje);
                XmlDocument doc = new XmlDocument();
                //Cuando el mensaje no coincide exactamente con los patrones de la base de datos
                if (conocimiento.Pattern == null)
                {
                    //Traer todos los patrones por tema
                    //XML
                    //Buscar posibles respuestas
                    List<Conocimiento> conocimientos = new List<Conocimiento>();
                    conocimientos = ConocimientoDAO.buscarPorComplemento();
                    XElement xmlConocimientoTodo = new XElement("aiml");
                    foreach (var item in conocimientos)
                    {
                        //Armar árbol xml
                        xmlConocimientoTodo.Add(new XElement("category", new XElement("pattern", item.Pattern)));
                        XElement child5 = (XElement)xmlConocimientoTodo.LastNode;
                        child5.Add(new XElement("template", new XElement("random")));
                        XElement child1 = (XElement)xmlConocimientoTodo.LastNode;
                        List<Template> templates2 = new List<Template>();

                        //Insertar respuestas del conocimiento en una lista
                        foreach (var item2 in ConocimientoTemplateDAO.buscarFilaPorConocimiento(item.Id))
                        {
                            templates2.Add(TemplateDAO.buscarFilaPorId(item2.IdTemplate,idSemestre));

                        }
                        try
                        {
                            //Insertar respuestas del conocimiento en el arbol xml
                            foreach (var item3 in templates2)
                            {
                                child1.Element("template").Element("random").Add(new XElement("li", item3));
                            }
                        }
                        catch
                        {
                            child1.Element("template").Element("random").Add(new XElement("li", "Lo siento, no comprendí tu mensaje. Recuerda que brindo información sobre:<br/> Procesos matriculación<br/>Proceso de titulación<br/>Prácticas preprofesionales<br/>Coordinación de la carrera<br/>Malla curricular<br/>Supletorios<br/>Seminarios<br/>Fechas de inicio y fin de semestre, para presentar documentos, para cambios de carrera"));

                        }

                    }
                    //Guardar xml
                    doc.LoadXml(xmlConocimientoTodo.ToString());
                    doc.Save("C:\\Users\\Giselita\\AppData\\Local\\Temp\\" + identificador +esAutenticado+ "doc.aiml");
                }
                else
                {
                    //Cuando se encuentra el patrón exacto
                    //Buscar posibles respuestas
                    foreach (var item in ConocimientoTemplateDAO.buscarFilaPorConocimiento(conocimiento.Id))
                    {
                        templates.Add(TemplateDAO.buscarFilaPorId(item.IdTemplate,idSemestre));
                        
                    }
                    //XML
                    XElement xmlConocimiento = new XElement("aiml", 
                    new XElement("category",
                    new XElement("pattern", conocimiento.Pattern),
                    new XElement("template", new XElement("random"))));

                    try
                    {
                        //Insertar respuestas
                        foreach (var item in templates)
                        {
                            XElement child1 = xmlConocimiento.Element("category").Element("template").Element("random");
                            child1.Add(new XElement("li", item));
                        }
                    }
                    catch
                    {
                        XElement child1 = xmlConocimiento.Element("category").Element("template").Element("random");
                        child1.Add(new XElement("li", "Lo siento, no comprendí tu mensaje. Recuerda que brindo información sobre:<br/> Procesos matriculación<br/>Proceso de titulación<br/>Prácticas preprofesionales<br/>Coordinación de la carrera<br/>Malla curricular<br/>Supletorios<br/>Seminarios<br/>Fechas de inicio y fin de semestre, para presentar documentos, para cambios de carrera"));
                    }
                    

                    //Guardar xml
                    doc.LoadXml(xmlConocimiento.ToString());
                    doc.Save("C:\\Users\\Giselita\\AppData\\Local\\Temp\\"+identificador+esAutenticado+"doc.aiml");
                }
                //AIML
                Bot AI = new Bot(); //Define el objeto AI, para guardar la información del bot
                string configPath = Directory.GetCurrentDirectory();
                // Cragar la configuración del chatbot, desde la carpeta config
                AI.loadSettings(); 
                //terminar de cargar aiml
                AI.loadAIMLFromXML(doc, "C:\\Users\\Giselita\\AppData\\Local\\Temp\\"+identificador+esAutenticado+"doc.aiml");
                AI.isAcceptingUserInput = false; // Desactivar  la entrada de texto del usuario mientras el chatbot se carga
                User myUser = new User("Giss", AI); // Crear un nuevo usuario con la información cargada del chatbot 
                AI.isAcceptingUserInput = true; // Cuando el chatbot se ha cargado se permite la entrada de texto del usuario

                Request r = new Request(mensaje, myUser, AI); // Lee la consola y ao
                Result res = AI.Chat(r); //  Envía la solicitud en el objeto resultado, la respuesta está basada en el AIML file
                //Si no se obtiene una respuesta
                if (res.Output == "")
                {
                    //petición post al servicio grampal
                    var client = new RestClient("http://localhost:55803/Grampal.svc/Postear");
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("Content-Type", "application/json");
                    const string quote = "\"";
                    string consulta = "{\n" + quote + "data" + quote + ":" + quote + mensajeInicial.ToLower() + quote + ",\n}";
                    request.AddParameter("undefined", consulta, ParameterType.RequestBody);
                    //Obtener la respuesta de la petición
                    IRestResponse response = client.Execute(request);        
                    string cadenaTexto = response.Content;
                    //Se obtiene unicamente lo necesario del análisis morfológico
                    string loQueSeAnalizará = AnalisisPalabra(cadenaTexto,identificador,idSemestre,esAutenticado);
                    return loQueSeAnalizará;
                }
                else
                {
                    //Guardar en la base de datos de la informacion del usuario
                    //string pat = res.Output.Substring(0,res.Output.Length-1);
                    informacionUsuario.IdTopic = TemplateDAO.buscarIdTopicPorRespuesta(chequearPuntoFinal(res.Output),idSemestre);
                    informacionUsuario.IdUser = identificador;
                    informacionUsuario.EsAutenticado = esAutenticado;
                    InfUserDAO.insertarInfUser(informacionUsuario);
                    //Verificar si el usuario puede recibir la información solicitada
                    if (informacionUsuario.IdTopic==18 && esAutenticado==0)
                    {
                        return "La información solicitada es privada. Favor ¡Autentícate!";
                    }
                    if (informacionUsuario.IdTopic==4|| informacionUsuario.IdTopic == 25|| informacionUsuario.IdTopic == 26|| informacionUsuario.IdTopic == 27)
                    {
                        return obtenerSinElPath(res.Output);
                    }
                   
                    return SemestreCorrecto(res.Output); // Mostrar por consola el resultado
                }
            }
            //En caso que el análisis morfológico presente una falla
            informacionUsuario.IdTopic = -1;
            informacionUsuario.IdUser = identificador;
            informacionUsuario.EsAutenticado = esAutenticado;
            InfUserDAO.insertarInfUser(informacionUsuario);
            return "Lo siento, no comprendí tu mensaje. Recuerda que brindo información sobre:<br/> Procesos matriculación<br/>Proceso de titulación<br/>Prácticas preprofesionales<br/>Coordinación de la carrera<br/>Malla curricular<br/>Supletorios<br/>Seminarios<br/>Fechas de inicio y fin de semestre, para presentar documentos, para cambios de carrera";
           
        }
        //Para verificar el tema de la respuesta que se enviará al usuario, se debe chequear si en la base de datos se tiene punto final
        private static string chequearPuntoFinal(string mensaje)
        {
            string ultimo = mensaje.Substring(mensaje.Length-1);

            if (ultimo == ".")
            {
                return mensaje;
            }
            else
            {
             
                return mensaje;
            }
        }
        //Extraer la información relevante de la respuesta del servicio que realiza el análisis morfológico
        private static string AnalisisPalabra(string cadenaTexto,Int32 identificador,int idSemestre,int esAutenticado)
        {
            string cadenaTexto2 = cadenaTexto;
            string cadenaTexto3 = cadenaTexto;
            const string quote = "\"";
            List<String> verbos = new List<string>();
            List<String> sustantivos = new List<string>();
           //Buscar si el análisis morfológico contiene verbos
            while (cadenaTexto2.Contains(quote + "V" + quote))
            {
                cadenaTexto2= cadenaTexto2.Substring(cadenaTexto2.IndexOf(quote + "V" + quote) + 12, cadenaTexto2.Length - cadenaTexto2.IndexOf(quote + "V" + quote) - 12);
                //Extraer un listado de verbos
                verbos.Add(cadenaTexto2.Substring(0, cadenaTexto2.IndexOf(quote)));
            }
            foreach (var item in verbos)
            {
                //Buscar en AIML si se obtiene una respuesta
                string primeraBusqueda = AyudaGrampaVerbo(SinTildes(item), identificador, idSemestre, esAutenticado);
                if (primeraBusqueda!="")
                {
                    return primeraBusqueda;
                }
            }      
            //Buscar si el análisis morfológico contiene sustantivos
            while (cadenaTexto.Contains(quote + "N" + quote))
            {
                cadenaTexto = cadenaTexto.Substring(cadenaTexto.IndexOf(quote + "N" + quote) + 12, cadenaTexto.Length - cadenaTexto.IndexOf(quote + "N" + quote) - 12);
                //Extraer listado de sustantivos
                sustantivos.Add(cadenaTexto.Substring(0, cadenaTexto.IndexOf(quote)));
            }
            //Buscar si el análisis morfológico contiene sustantivos
            while (cadenaTexto3.Contains(quote + "n" + quote))
            {
                cadenaTexto3 = cadenaTexto3.Substring(cadenaTexto3.IndexOf(quote + "n" + quote) + 12, cadenaTexto3.Length - cadenaTexto3.IndexOf(quote + "n" + quote) - 12);
                //Extraer listado de sustantivos
                sustantivos.Add( cadenaTexto3.Substring(0, cadenaTexto3.IndexOf(quote)));
            }
            foreach (var item in sustantivos)
            {
                //Buscar con AIML una respuesta
                string primeraBusqueda = AyudaGrampaVerbo(SinTildes(item), identificador, idSemestre, esAutenticado);
                if (primeraBusqueda != "")
                {
                    return primeraBusqueda;
                }
            }
            //Si no se obtiene una respuesta con el análisis morfológico
            InfUser informacionUsuario = new InfUser();
            informacionUsuario.IdTopic = -1;
            informacionUsuario.IdUser = identificador;
            informacionUsuario.EsAutenticado = esAutenticado;
            InfUserDAO.insertarInfUser(informacionUsuario);

            return "Lo siento, no comprendí tu mensaje. Recuerda que brindo información sobre:<br/> Procesos matriculación<br/>Proceso de titulación<br/>Prácticas preprofesionales<br/>Coordinación de la carrera<br/>Malla curricular<br/>Supletorios<br/>Seminarios<br/>Fechas de inicio y fin de semestre, para presentar documentos, para cambios de carrera";

        }


        //Verificar si el mensaje enviado por el usuario corresponde a un correo electrónico
        private static string IsValidEmailTexto(string email)
        {
            const string MatchEmailPattern = @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
             + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                 + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";
            Regex rx = new Regex(MatchEmailPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            MatchCollection matches = rx.Matches(email);
            // Número de coincidencias
            int noOfMatches = matches.Count;

            
            foreach (Match match in matches)
            {
                return match.Value.ToString();
            }
            return null;
        }
        //Verificar el tema de conversación anterior
        private static int EnviaralMail(int identificador, int esAutenticado,int idSemestre)
        {
            //Si el mensaje anterior corresponde al tema con id 4
            if(InfUserDAO.MensajeAnterior(identificador, 4,esAutenticado)==1)
            {
                if (esAutenticado==1)
                {
                    //enviar el mail
                    int g=enviarCorreo(1, EstudianteDAO.ObtenerCorreo(identificador),idSemestre);
                    return g;
                }
                else
                {
                    return -1;
                }
            //Si el mensaje anterior corresponde al tema con id 25           
            }else if (InfUserDAO.MensajeAnterior(identificador, 25,esAutenticado) == 1)
            {
                if (esAutenticado == 1)
                {
                    int g = enviarCorreo(2, EstudianteDAO.ObtenerCorreo(identificador),idSemestre);
                    return g;
                }
                else
                {
                    return -1;
                }
            }
            //Si el mensaje anterior corresponde al tema con id 26
            else if (InfUserDAO.MensajeAnterior(identificador, 26,esAutenticado) == 1)
            {
                if (esAutenticado == 1)
                {
                    int g = enviarCorreo(3, EstudianteDAO.ObtenerCorreo(identificador),idSemestre);
                    return g;
                }
                else
                {
                    return -1;
                }
            }
            //Si el mensaje anterior corresponde al tema con id 27
            else if (InfUserDAO.MensajeAnterior(identificador, 27,esAutenticado) == 1)
            {
                if (esAutenticado == 1)
                {
                    int g = enviarCorreo(4, EstudianteDAO.ObtenerCorreo(identificador),idSemestre);
                    return g;
                }
                else
                {
                    return -1;
                }
            }
            return 0;
        }

        private static int EnviaralMailNoAutenticado(int identificador, int esAutenticado,int idSemestre)
        {
            //Si el mensaje anterior corresponde al tema con id 4
            if (InfUserDAO.MensajeAnterior(identificador, 4, esAutenticado) == 1)
            {              
                enviarCorreo(1, PublicoDAO.ObtenerCorreo(identificador),idSemestre);                

            }
            //Si el mensaje anterior corresponde al tema con id 25
            else if (InfUserDAO.MensajeAnterior(identificador, 25, esAutenticado) == 1)
            {
                enviarCorreo(2, PublicoDAO.ObtenerCorreo(identificador),idSemestre);
            }
            //Si el mensaje anterior corresponde al tema con id 26
            else if (InfUserDAO.MensajeAnterior(identificador, 26, esAutenticado) == 1)
            {
                enviarCorreo(3, PublicoDAO.ObtenerCorreo(identificador),idSemestre);
            }
            //Si el mensaje anterior corresponde al tema con id 27
            else if (InfUserDAO.MensajeAnterior(identificador, 27, esAutenticado) == 1)
            {
                enviarCorreo(4, PublicoDAO.ObtenerCorreo(identificador),idSemestre);
            }
            return 1;
        }


        private static int NoEnviaralMail(int identificador, int esAutenticado)
        {
            //Si el mensaje anterior corresponde al tema con id 4 pero no quiere recibir mail
            if (InfUserDAO.MensajeAnterior(identificador, 4,esAutenticado) == 1)
            {     
                return 1;
            //Si el mensaje anterior corresponde al tema con id 25 pero no quiere recibir mail
            }else if (InfUserDAO.MensajeAnterior(identificador, 25,esAutenticado) == 1)
            {
                return 1;
            //Si el mensaje anterior corresponde al tema con id 26 pero no quiere recibir mail
            }else if (InfUserDAO.MensajeAnterior(identificador, 26,esAutenticado) == 1)
            {
                return 1;
            //Si el mensaje anterior corresponde al tema con id 27 pero no quiere recibir mail
            }else if (InfUserDAO.MensajeAnterior(identificador, 27,esAutenticado) == 1)
            {
                return 1;
            }
            return 0;
        }
        //Verificar si el mensaje contiene una afirmación
        private static string EsAfirmacion(string mensaje, Int32 identificador, int idSemestre,int esAutenticado)
        {
            List<Conocimiento> conocimientos = new List<Conocimiento>();
            conocimientos = ConocimientoDAO.buscarPorAfirmacion();
            XElement xmlConocimientoTodo = new XElement("aiml");
            var doc = new XmlDocument();
            foreach (var item in conocimientos)
            {
                //Armar árbol xml
                xmlConocimientoTodo.Add(new XElement("category", new XElement("pattern", item.Pattern)));
                XElement child5 = (XElement)xmlConocimientoTodo.LastNode;
                child5.Add(new XElement("template", new XElement("random")));
                XElement child1 = (XElement)xmlConocimientoTodo.LastNode;
                List<Template> templates2 = new List<Template>();
                //Insertar respuestas del conocimiento en una lista
                foreach (var item2 in ConocimientoTemplateDAO.buscarFilaPorConocimiento(item.Id))
                {
                    templates2.Add(TemplateDAO.buscarFilaPorId(item2.IdTemplate,idSemestre));

                }
                //Insertar respuestas del conocimiento en el arbol xml

                try
                {
                    foreach (var item3 in templates2)
                    {
                        child1.Element("template").Element("random").Add(new XElement("li", item3));
                    }
                }
                catch
                {
                    child1.Element("template").Element("random").Add(new XElement("li", "Lo siento, no comprendí tu mensaje. Recuerda que brindo información sobre:<br/> Procesos matriculación<br/>Proceso de titulación<br/>Prácticas preprofesionales<br/>Coordinación de la carrera<br/>Malla curricular<br/>Supletorios<br/>Seminarios<br/>Fechas de inicio y fin de semestre, para presentar documentos, para cambios de carrera"));
                }
               
            }
            //Guardar xml
            doc.LoadXml(xmlConocimientoTodo.ToString());
            doc.Save("C:\\Users\\Giselita\\AppData\\Local\\Temp\\" + identificador+esAutenticado + "doc.aiml");
            Bot AI = new Bot(); //Define el objeto AI, para guardar la información del bot
            string configPath = Directory.GetCurrentDirectory();

            AI.loadSettings(); // Cragar la configuración del chatbot, desde la carpeta config                           
            //terminar de cargar aiml
            AI.loadAIMLFromXML(doc, "C:\\Users\\Giselita\\AppData\\Local\\Temp\\" + identificador +esAutenticado+ "doc.aiml");
            AI.isAcceptingUserInput = false; // Desactivar  la entrada de texto del usuario mientras el chatbot se carga
            User myUser = new User("Giss", AI); // Crear un nuevo usuario con la información cargada del chatbot 
            AI.isAcceptingUserInput = true; // Cuando el chatbot se ha cargado se permite la entrada de texto del usuario
            Request r = new Request(mensaje, myUser, AI); // Lee la consola y ao
            Result res = AI.Chat(r);
            return res.Output;
        }

        //Verificar si el mensaje contiene una negación
        private static string EsNegacion(string mensaje, Int32 identificador,int idSemestre,int esAutenticado)
        {
            List<Conocimiento> conocimientos = new List<Conocimiento>();
            conocimientos = ConocimientoDAO.buscarPorNegacion();
            XElement xmlConocimientoTodo = new XElement("aiml");
            var doc = new XmlDocument();
            foreach (var item in conocimientos)
            {
                //Armar árbol xml
                xmlConocimientoTodo.Add(new XElement("category", new XElement("pattern", item.Pattern)));
                XElement child5 = (XElement)xmlConocimientoTodo.LastNode;
                child5.Add(new XElement("template", new XElement("random")));
                XElement child1 = (XElement)xmlConocimientoTodo.LastNode;
                List<Template> templates2 = new List<Template>();
                //Insertar respuestas del conocimiento en una lista
                foreach (var item2 in ConocimientoTemplateDAO.buscarFilaPorConocimiento(item.Id))
                {
                    templates2.Add(TemplateDAO.buscarFilaPorId(item2.IdTemplate,idSemestre));

                }
                //Insertar respuestas del conocimiento en el arbol xml

                try
                {
                    foreach (var item3 in templates2)
                    {
                        child1.Element("template").Element("random").Add(new XElement("li", item3));
                    }
                }
                catch
                {
                    child1.Element("template").Element("random").Add(new XElement("li", "Lo siento, no comprendí tu mensaje. Recuerda que brindo información sobre:<br/> Procesos matriculación<br/>Proceso de titulación<br/>Prácticas preprofesionales<br/>Coordinación de la carrera<br/>Malla curricular<br/>Supletorios<br/>Seminarios<br/>Fechas de inicio y fin de semestre, para presentar documentos, para cambios de carrera"));
                }
                
            }
            //Guardar xml
            doc.LoadXml(xmlConocimientoTodo.ToString());
            doc.Save("C:\\Users\\Giselita\\AppData\\Local\\Temp\\" + identificador+esAutenticado + "doc.aiml");
            Bot AI = new Bot(); //Define el objeto AI, para guardar la información del bot
            string configPath = Directory.GetCurrentDirectory();

            AI.loadSettings(); // Cragar la configuración del chatbot, desde la carpeta config
                               //AI.loadSettings();

            //terminar de cargar aiml
            AI.loadAIMLFromXML(doc, "C:\\Users\\Giselita\\AppData\\Local\\Temp\\" + identificador+esAutenticado + "doc.aiml");
            AI.isAcceptingUserInput = false; // Desactivar  la entrada de texto del usuario mientras el chatbot se carga
            User myUser = new User("Giss", AI); // Crear un nuevo usuario con la información cargada del chatbot 
            AI.isAcceptingUserInput = true; // Cuando el chatbot se ha cargado se permite la entrada de texto del usuario


            Request r = new Request(mensaje, myUser, AI); // Lee la consola y ao
            Result res = AI.Chat(r);
            return res.Output;
        }

        public static string AyudaGrampaVerbo(string mensaje,Int32 identificador,int idSemestre,int esAutenticado)
        {
            //Simulando una conversacion
            Conocimiento conocimiento = new Conocimiento();
            List<Template> templates = new List<Template>();
            var doc = new XmlDocument();
            //Busca en la base el patron exacto
            conocimiento = ConocimientoDAO.buscarFilaPorPattern(mensaje);
            //Cuando se encuentra el patrón exacto
            //Buscar posibles respuestas
            foreach (var item in ConocimientoTemplateDAO.buscarFilaPorConocimiento(conocimiento.Id))
            {
                templates.Add(TemplateDAO.buscarFilaPorId(item.IdTemplate,idSemestre));

            }
            //XML
            XElement xmlConocimiento = new XElement("aiml", new XElement("category",
            new XElement("pattern", conocimiento.Pattern),
            new XElement("template", new XElement("random"))));

            //Insertar respuestas
            try
            {
                foreach (var item in templates)
                {
                    XElement child1 = xmlConocimiento.Element("category").Element("template").Element("random");
                    child1.Add(new XElement("li", item));
                }
            }
            catch
            {
                 XElement child1 = xmlConocimiento.Element("category").Element("template").Element("random");
                 child1.Add(new XElement("li", "Lo siento, no comprendí tu mensaje. Recuerda que brindo información sobre:<br/> Procesos matriculación<br/>Proceso de titulación<br/>Prácticas preprofesionales<br/>Coordinación de la carrera<br/>Malla curricular<br/>Supletorios<br/>Seminarios<br/>Fechas de inicio y fin de semestre, para presentar documentos, para cambios de carrera"));
            }
           
            //Guardar xml
            doc.LoadXml(xmlConocimiento.ToString());
            doc.Save("C:\\Users\\Giselita\\AppData\\Local\\Temp\\" + identificador+esAutenticado + "doc.aiml");
            //AIML
            Bot AI = new Bot(); 
            string configPath = Directory.GetCurrentDirectory();
            AI.loadSettings(); 
            //terminar de cargar aiml
            AI.loadAIMLFromXML(doc, "C:\\Users\\Giselita\\AppData\\Local\\Temp\\" + identificador+esAutenticado + "doc.aiml");
            AI.isAcceptingUserInput = false;
            User myUser = new User("Giss", AI); 
            AI.isAcceptingUserInput = true;
            
            Request r = new Request(mensaje, myUser, AI); 
            Result res = AI.Chat(r);
            return res.Output;
        }
        //Autenticar a un estudiante con sus credenciales
        public static int Autenticar(String correo, String password)
        {
            int i = EstudianteDAO.Autenticar(correo, password);
            return i;
        }
        //Proporcionar un identificador a un usuario no autenticado
        public static int NoAutenticar()
        {
            int i = PublicoDAO.NoAutenticar();
            return i;
        }
        //Chequear el semestre para enviar en las respuestas del chatbot
        public static string SemestreCorrecto(string mensaje)
        {
           
            if (mensaje.Contains("para el semestre 2019-A"))
            {
                Regex a = new Regex("2019-A", RegexOptions.Compiled);
                mensaje = a.Replace(mensaje, SemestreDAO.SemestreSeleccionado());
            }
           
            return mensaje;
        }
        //Enviar correo electrónico
        private static int enviarCorreo(int contenidoCorreo, string correo, int idSemestre)
        {
            var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            string strHost = smtpSection.Network.Host;
            int port = smtpSection.Network.Port;
            string strUserName = smtpSection.Network.UserName;
            string strFromPass = smtpSection.Network.Password;

            
            try
            {
                //Crear un nuevo correo
                SmtpClient smtp = new SmtpClient(strHost, port);
                NetworkCredential cert = new NetworkCredential(strUserName, strFromPass);
                smtp.EnableSsl = true;
                MailMessage msg = new MailMessage(smtpSection.From, correo);
                msg.Subject = "Respuesta a tu pregunta";
                msg.IsBodyHtml = true;
                Attachment adjunto;
                //Seleccionar el contenido del correo
                if (contenidoCorreo == 1)
                {
                    Template template = new Template();
                    template = TemplateDAO.buscarFilaPorId(4, idSemestre);
                    string path = obtenerSoloElPath(template.Li);
                    adjunto = new Attachment(path);
                    msg.Body += "<p>Estimado/a <p>En el archivo adjunto puedes observar el horario de materias. <p>¡Un gusto ayudarte!<p>Chatbot de la Coordinación de la Carrera de Tecnologías de la Información <p>Facultad de Ingeniería Eléctrica y Electrónica <p>Escuela Politécnica Nacional</p></p></p></p>";
                }
                else if (contenidoCorreo == 2)
                {
                    Template template = new Template();
                    template = TemplateDAO.buscarFilaPorId(26, idSemestre);
                    string path = obtenerSoloElPath(template.Li);
                    adjunto = new Attachment(path);
                    msg.Body += "<p>Estimado/a<p>En el archivo adjunto puedes observar la malla curricular de la carrera de Tecnologías de la Información. <p>¡Un gusto ayudarte! <p>Chatbot de la Coordinación de la Carrera de Tecnologías de la Información <p>Facultad de Ingeniería Eléctrica y Electrónica <p>Escuela Politécnica Nacional</p></p></p></p>";
                }
                else if (contenidoCorreo == 3)
                {
                    Template template = new Template();
                    template = TemplateDAO.buscarFilaPorId(27, idSemestre);
                    string path = obtenerSoloElPath(template.Li);
                    adjunto = new Attachment(path);
                    msg.Body += "<p>Estimado/a<p>En el archivo adjunto puedes observar el horario de supletorios. <p>¡Un gusto ayudarte! <p>Chatbot de la Coordinación de la Carrera de Tecnologías de la Información <p>Facultad de Ingeniería Eléctrica y Electrónica <p>Escuela Politécnica Nacional</p></p></p></p>";
                }
                else if (contenidoCorreo == 4)
                {
                    Template template = new Template();
                    template = TemplateDAO.buscarFilaPorId(28, idSemestre);
                    string path = obtenerSoloElPath(template.Li);
                    adjunto = new Attachment(path);
                    msg.Body += "<p>Estimado/a<p>En el archivo adjunto puedes observar el horario de seminarios. <p>¡Un gusto ayudarte! <p>Chatbot de la Coordinación de la Carrera de Tecnologías de la Información <p>Facultad de Ingeniería Eléctrica y Electrónica <p>Escuela Politécnica Nacional</p></p></p></p>";
                }
                else
                {
                    adjunto = new Attachment("C:\\Users\\Giselita\\Documents\\Visual Studio 2017\\AppChatbot\\WCFService\\defecto.docx");
                    msg.Body += "<p>Buen día. <p>Chatbot de la Coordinación de la Carrera de Tecnologías de la Información <p>Facultad de Ingeniería Eléctrica y Electrónica <p>Escuela Politécnica Nacional</p></p></p></p>";
                }
                //Enviar el correo
                msg.Attachments.Add(adjunto);
                smtp.Send(msg);
            }
            catch
            {
                return -1;
            }
            
            
            return 1;
            
        }
        //Obtener la ubicación de los archivos que se enviarán al correo electrónico
        private static string obtenerSoloElPath(String cadenaTexto)
        {
            string cadenaTexto2 = cadenaTexto;
            string resultado2 = "";

            if (cadenaTexto.Contains("-"))
            {
                //busca desde
                resultado2 = cadenaTexto2.Substring(cadenaTexto2.IndexOf("-") + 1, cadenaTexto2.Length - cadenaTexto2.IndexOf("-") - 2);

            }
            return resultado2;

        }
        //Enviar el mensaje al usuario sin la ubicación del archivo
        private static string obtenerSinElPath(String cadenaTexto)
        {
            string cadenaTexto2 = cadenaTexto;
            string resultado2 = "";
            if (cadenaTexto.Contains("-"))
            {
                //busca desde
                resultado2 = cadenaTexto2.Substring(0, cadenaTexto2.IndexOf("-"));
            }
            return resultado2;
        }
        //Analizar el mensaje enviado por el usuario sin signos ni tildes
        private static String SinTildes(String inputString)
        {
            Regex a = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
            Regex e = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
            Regex i = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            Regex o = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
            Regex u = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);
            Regex A = new Regex("[Á]", RegexOptions.Compiled);
            Regex E = new Regex("[É]", RegexOptions.Compiled);
            Regex I = new Regex("[Í]", RegexOptions.Compiled);
            Regex O = new Regex("[Ó]", RegexOptions.Compiled);
            Regex U = new Regex("[Ú]", RegexOptions.Compiled);
            Regex n = new Regex("[ñ|Ñ]", RegexOptions.Compiled);
            Regex signo = new Regex("[?|¿|!|¡|-|+|_|)|(|#|$|%|&|/|=|*|+|,|.|:|;|'|°|¬|{|}|^|´|~|°|`|<|>|¨|\"|1|2|3|4|5|6|7|8|9|0|]", RegexOptions.Compiled);
            inputString = a.Replace(inputString, "a");
            inputString = e.Replace(inputString, "e");
            inputString = i.Replace(inputString, "i");
            inputString = o.Replace(inputString, "o");
            inputString = u.Replace(inputString, "u");
            inputString = A.Replace(inputString, "A");
            inputString = E.Replace(inputString, "E");
            inputString = I.Replace(inputString, "I");
            inputString = O.Replace(inputString, "O");
            inputString = U.Replace(inputString, "U");
            inputString = n.Replace(inputString, "n");
            inputString = signo.Replace(inputString,"");
            char[] MyChar = { ']', '[', '-'};
            inputString= inputString.TrimEnd(MyChar);
            return inputString;
        }
    }


}