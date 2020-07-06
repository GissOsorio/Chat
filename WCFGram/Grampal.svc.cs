using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WCFGram
{
    //Contrato de servicio
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Grampal
    {
        //Método que se expondrá en el servicio
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        public List<Estructura> Postear(string data)
        {
                //oracion gramatical a analizar
                string oracion = data;
                List<Estructura> datos = new List<Estructura>();
            try
            {
                //configuraicon de modo headless
                ChromeOptions configuracion = new ChromeOptions();
                //sin ventanas graficas
                configuracion.AddArgument("--headless");
                IWebDriver navegador = new ChromeDriver(configuracion);
                //navegar a url
                navegador.Navigate().GoToUrl("http://cartago.lllf.uam.es/grampal/grampal.cgi?m=etiqueta&e=");
                //escribir oracion deseada en linea de texto
                navegador.FindElement(By.Name("e")).SendKeys(oracion);
                //clic en boton para analisis
                navegador.FindElement(By.CssSelector("input[type='submit']")).Click();

                //el elemento navegador en este punto contiene toda la pagina con los resultados del analisis
                //obtengo filas de la tabla 
                List<IWebElement> filas = navegador.FindElements(By.TagName("tr")).ToList();

               
                foreach (IWebElement fila in filas)
                {
                    //obtengo columnas de cada fila
                    List<IWebElement> cols = fila.FindElements(By.TagName("td")).ToList();
                    Estructura item = new Estructura();
                    int contador = 0;
                    foreach (IWebElement col in cols)
                    {
                        //a traves de este loop guardo los elemento en un objeto para su posterior uso
                        if (contador == 0)
                        {
                            item.palabra = col.Text;
                            contador++;
                        }
                        else if (contador == 1)
                        {
                            //arreglos al string necesarios para eliminar info redundante
                            item.categoria = col.Text.Replace("categoría ", "").Trim();
                            contador++;
                        }
                        else if (contador == 2)
                        {
                            item.lema = col.Text.Replace("lema ", "").Trim();
                            contador++;
                        }
                        else if (contador == 3)
                        {
                            item.rasgo = col.Text.Replace("rasgos ", "").Trim();
                            contador = 0;
                        }
                    }
                    datos.Add(item);
                }
            }
            catch (Exception)
            {
                datos = null;
            }        
             return datos;
                                             
        }
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Estructura
    {
        [DataMember]
        public string palabra { get; set; }
        [DataMember]
        public string categoria { get; set; }
        [DataMember]
        public string lema { get; set; }
        [DataMember]
        public string rasgo { get; set; }
    }


}
