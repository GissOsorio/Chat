using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using RtfPipe;
using Font = System.Drawing.Font;
using iDiTect.Converter;
using Administración;
using System.Text.RegularExpressions;

namespace InicioAdministracion
{
    public partial class frmInicio : Form
    {
        int idSemestreActual;
        int idSemestreChatbot;
        DateTime uno = new DateTime();
        DateTime dos = new DateTime();
        DateTime tres = new DateTime();
        DateTime cuatro = new DateTime();
        DateTime cinco = new DateTime();
        DateTime seis = new DateTime();
        DateTime siete = new DateTime();
        DateTime ocho = new DateTime();
        DateTime nueve = new DateTime();
        DateTime diez = new DateTime();
        DateTime once = new DateTime();
        DateTime doce = new DateTime();
        DateTime extraInicio = new DateTime();
        DateTime extaFin = new DateTime();
        DateTime extAnillados = new DateTime();
        DateTime becasInicio = new DateTime();
        DateTime becasFin = new DateTime();
        List<Ingeniero> listaIngenieros = new List<Ingeniero>();
        List<Conocimiento> listaPalabrasClave = new List<Conocimiento>();
        List<Template> listaPalabrasClaveTemplate = new List<Template>();
        List<String> empresas = new List<String>();
        Administración.Administrar.AdministrarClient clienteServicioAdministracion = new Administración.Administrar.AdministrarClient();
        public frmInicio()
        {
            InitializeComponent();
            var tt1 = new ToolTip();
            tt1.SetToolTip(btnInformacion, "Texto a mostrar");
            var tt2 = new ToolTip();
            tt2.SetToolTip(button6, "Añade un nuevo periodo académico con nueva información");
            var tt3 = new ToolTip();
            tt3.SetToolTip(btnGuardar, "Guarda los cambios realizados de forma permanente");
            var tt4 = new ToolTip();
            tt4.SetToolTip(btnCambiosProfesor, "Guarda los cambios realizados sobre la información de un profesor de forma permanente");
            var tt5 = new ToolTip();
            tt5.SetToolTip(btnEliminarProfesor, "Elimina a un profesor de forma permanente");
            var tt6 = new ToolTip();
            tt6.SetToolTip(btnNuevoProfesor, "Agrega la información de un nuevo profesor");
            var tt7 = new ToolTip();
            tt7.SetToolTip(button3, "Limpia los campos para agregar información de un nuevo profesor");
            var tt8 = new ToolTip();
            tt8.SetToolTip(dgv, "Selecciona un profesor");
            var tt9 = new ToolTip();
            tt9.SetToolTip(btnHorarioMaterias, "Cambia un archivo de forma permanente");
            var tt10 = new ToolTip();
            tt10.SetToolTip(btnMallaCurricular, "Cambia un archivo de forma permanente");
            var tt11 = new ToolTip();
            tt11.SetToolTip(btnSupletorios, "Cambia un archivo de forma permanente");
            var tt12 = new ToolTip();
            tt12.SetToolTip(btnSeminarios, "Cambia un archivo de forma permanente");
            var tt13 = new ToolTip();
            tt13.SetToolTip(tabInicio, "Guarda los cambios realizados de forma permanente");
            var tt14 = new ToolTip();
            tt14.SetToolTip(btnTitulacion, "Guarda los cambios realizados de forma permanente");
            var tt15 = new ToolTip();
            tt15.SetToolTip(button8, "Guarda los cambios realizados de forma permanente");
            var tt16 = new ToolTip();
            tt16.SetToolTip(button1, "Guarda los cambios realizados de forma permanente");
            var tt17 = new ToolTip();
            tt17.SetToolTip(btnAñadirPalabraClave, "Guarda los cambios realizados de forma permanente");
            var tt18 = new ToolTip();
            tt18.SetToolTip(btnEliminarPalabraClave, "Elimina una palabra clave de forma permanente");
            var tt19 = new ToolTip();
            tt19.SetToolTip(btnGuardarPalabra, "Agrega una nueva palabra clave");
            var tt20 = new ToolTip();
            tt20.SetToolTip(button2, "Limpia los campos para agregar información de una nueva palabra clave");
            var tt21 = new ToolTip();
            tt21.SetToolTip(dgvListaPalabras, "Selecciona una palabra clave");
            var tt22 = new ToolTip();
            tt22.SetToolTip(button5, "Aplica el formato de negrita al texto seleccionado");
            var tt23 = new ToolTip();
            tt23.SetToolTip(button13, "Aplica el formato de negrita al texto seleccionado");
            var tt24 = new ToolTip();
            tt24.SetToolTip(button14, "Aplica el formato de negrita al texto seleccionado");
            var tt25 = new ToolTip();
            tt25.SetToolTip(button15, "Aplica el formato de negrita al texto seleccionado");
            var tt26 = new ToolTip();
            tt26.SetToolTip(button16, "Aplica el formato de negrita al texto seleccionado");
            var tt27 = new ToolTip();
            tt27.SetToolTip(button17, "Aplica el formato de negrita al texto seleccionado");
            var tt28 = new ToolTip();
            tt28.SetToolTip(button18, "Aplica el formato de negrita al texto seleccionado");
            var tt29 = new ToolTip();
            tt29.SetToolTip(button19, "Aplica el formato de negrita al texto seleccionado");
            var tt30 = new ToolTip();
            tt30.SetToolTip(button20, "Aplica el formato de negrita al texto seleccionado");
            var tt31 = new ToolTip();
            tt31.SetToolTip(button21, "Aplica el formato de negrita al texto seleccionado");
            var tt32 = new ToolTip();
            tt32.SetToolTip(button7, "Aplica el formato de negrita al texto seleccionado");
            var tt33 = new ToolTip();
            tt33.SetToolTip(button22, "Aplica el formato de negrita al texto seleccionado");
            var tt34 = new ToolTip();
            tt34.SetToolTip(button23, "Aplica el formato de negrita al texto seleccionado");
            var tt35 = new ToolTip();
            tt35.SetToolTip(button9, "Aplica el formato de negrita al texto seleccionado");
            var tt36 = new ToolTip();
            tt36.SetToolTip(button24, "Aplica el formato de negrita al texto seleccionado");
            var tt37 = new ToolTip();
            tt37.SetToolTip(btnNegrilla, "Aplica el formato de negrita al texto seleccionado");
            var tt38 = new ToolTip();
            tt38.SetToolTip(button4, "Aplica el formato de Negrita al texto seleccionado");
            var tt39 = new ToolTip();
            tt39.SetToolTip(button10, "Aplica el formato de Negrita al texto seleccionado");
            var tt40 = new ToolTip();
            tt40.SetToolTip(button11, "Aplica el formato de Negrita al texto seleccionado");
            var tt41 = new ToolTip();
            tt41.SetToolTip(button12, "Aplica el formato de Negrita al texto seleccionado");
            var tt42 = new ToolTip();
            tt42.SetToolTip(cb1, "Selecciona un periodo académico");
            var tt43 = new ToolTip();
            tt43.SetToolTip(cbSemestre, "Selecciona un periodo académico");
            var tt44 = new ToolTip();
            tt44.SetToolTip(dtp1, "Selecciona una fecha");
            var tt45 = new ToolTip();
            tt45.SetToolTip(dtp2, "Selecciona una fecha");
            var tt46 = new ToolTip();
            tt46.SetToolTip(dtp3, "Selecciona una fecha");
            var tt47 = new ToolTip();
            tt47.SetToolTip(dtp4, "Selecciona una fecha");
            var tt48 = new ToolTip();
            tt48.SetToolTip(dtp7, "Selecciona una fecha");
            var tt49 = new ToolTip();
            tt49.SetToolTip(dtp8, "Selecciona una fecha");
            var tt50 = new ToolTip();
            tt50.SetToolTip(dtp9, "Selecciona una fecha");
            var tt51 = new ToolTip();
            tt51.SetToolTip(dtp10, "Selecciona una fecha");
            var tt52 = new ToolTip();
            tt52.SetToolTip(dtp11, "Selecciona una fecha");
            var tt53 = new ToolTip();
            tt53.SetToolTip(dtp12, "Selecciona una fecha");
            var tt54 = new ToolTip();
            tt54.SetToolTip(dtp13, "Selecciona una fecha");
            var tt55 = new ToolTip();
            tt55.SetToolTip(dtp14, "Selecciona una fecha");
            var tt56 = new ToolTip();
            tt56.SetToolTip(dtpExtraordinariasInicio, "Selecciona una fecha");
            var tt57 = new ToolTip();
            tt57.SetToolTip(dtpExtrordinariasFin, "Selecciona una fecha");
            var tt58 = new ToolTip();
            tt58.SetToolTip(dtpBecasInicio, "Selecciona una fecha");
            var tt59 = new ToolTip();
            tt59.SetToolTip(dtpBecasFin, "Selecciona una fecha");
            var tt60 = new ToolTip();
            tt60.SetToolTip(dtpExtensionAnillados, "Selecciona una fecha");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            uno = dtp1.Value;

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            mostrarSemestreInicio();
            mostrarSemestre();
            LlenarFechas();
            cargardgv();
            cargardgvPalabrasClave();
            cargarMatriculacion();
            cargarTitulacion();
            cargarArchivos();
            cargarPrácticasPreprofesionales();
        }

        private void LlenarFechas()
        {
            Template fecha = new Template();
            fecha = clienteServicioAdministracion.buscarFilaPorId(2,idSemestreActual);
            ObtenerFecha(fecha.Li,1);
            fecha = clienteServicioAdministracion.buscarFilaPorId(3,idSemestreActual);
            ObtenerFecha(fecha.Li, 3);
            fecha = clienteServicioAdministracion.buscarFilaPorId(21,idSemestreActual);
            ObtenerFecha(fecha.Li, 5);
            fecha = clienteServicioAdministracion.buscarFilaPorId(22,idSemestreActual);
            ObtenerFecha(fecha.Li, 7);
            fecha = clienteServicioAdministracion.buscarFilaPorId(23,idSemestreActual);
            ObtenerFecha(fecha.Li, 9);
            fecha = clienteServicioAdministracion.buscarFilaPorId(20,idSemestreActual);
            ObtenerFecha(fecha.Li, 11);
            fecha = clienteServicioAdministracion.buscarFilaPorId(48, idSemestreActual);
            ObtenerFecha(fecha.Li, 13);
            fecha = clienteServicioAdministracion.buscarFilaPorId(14, idSemestreActual);
            ObtenerFechaExtension(fecha.Li, 15);
            fecha = clienteServicioAdministracion.buscarFilaPorId(50, idSemestreActual);
            ObtenerFecha(fecha.Li, 17);
         

        }
        private void ObtenerProfesores()
        {
            List<Template> listaTemplates = new List<Template>();

            foreach (var item in clienteServicioAdministracion.listaTemplatesTopic(18,idSemestreActual))
            {
                listaTemplates.Add(item);
            } 

            string cadenaTexto2 = "";
            string primerVerbo = "";
            string resultado3 = "";
            string resultado2 = "";
            string resultado4 = "";
            string segundaFecha = "";
            string telefono = "";
            foreach (var item in listaTemplates)
            {
                cadenaTexto2=item.Li;
                if (cadenaTexto2.Contains("El ingeniero: "))
                {
                    //Busca nombre
                    resultado2 = cadenaTexto2.Substring(cadenaTexto2.IndexOf("El ingeniero: ") + 14, cadenaTexto2.Length - cadenaTexto2.IndexOf("El ingeniero: ") - 14);
                    primerVerbo = resultado2.Substring(0, resultado2.IndexOf(", tiene su oficina en el: "));
                    //Busca oficina
                    resultado3 = resultado2.Substring(resultado2.IndexOf(", tiene su oficina en el: ") + 26, resultado2.Length - resultado2.IndexOf(", tiene su oficina en el: ") - 26);
                    segundaFecha = resultado3.Substring(0, resultado3.IndexOf(", y su teléfono es el: "));
                    //Busca teléfono
                    resultado4 = resultado3.Substring(resultado3.IndexOf(", y su teléfono es el: ") + 23, resultado3.Length - resultado3.IndexOf(", y su teléfono es el: ") - 23);
                    telefono = resultado4.Substring(0, resultado4.IndexOf("."));
                    Ingeniero ingeniero = new Ingeniero(primerVerbo,segundaFecha,telefono,item.IdTemplate);
                    listaIngenieros.Add(ingeniero);
                    
                }
            }
        }

        private void ObtenerPalabrasClave()
        {
            listaPalabrasClave.Clear();
            listaPalabrasClaveTemplate.Clear();
            List<ConocimientoTemplate> listaConocimientoTemplates = new List<ConocimientoTemplate>();
            foreach (var item in clienteServicioAdministracion.listaTemplatesTopic(39,idSemestreActual))
            {
                listaPalabrasClaveTemplate.Add(item);
            }

            foreach (var item in listaPalabrasClaveTemplate)
            {
                listaConocimientoTemplates.Add(clienteServicioAdministracion.buscarFilaPorTemplate(item.IdTemplate));           
            }

            foreach (var item in listaConocimientoTemplates)
            {
                listaPalabrasClave.Add(clienteServicioAdministracion.buscarPalabraClavePorConocimiento(item.IdConocimiento));
            }

        }



        private void ObtenerFechaExtension(String cadenaTexto, int numero)
        {
            string cadenaTexto2 = cadenaTexto;
            string resultado3 = "";
            string segundaFecha = "";

            if (cadenaTexto.Contains("hasta el "))
            {
              
                resultado3 = cadenaTexto2.Substring(cadenaTexto2.IndexOf("hasta el ") + 9, cadenaTexto2.Length - cadenaTexto2.IndexOf("hasta el") - 9);
                segundaFecha = resultado3.Substring(0, resultado3.IndexOf("."));
            }
            Extraer(segundaFecha, numero);


        }

        private void ObtenerFecha(String cadenaTexto, int numero)
        {
            string cadenaTexto2 = cadenaTexto;
            string primerVerbo = "";
            string resultado3 = "";
            string resultado2 = "";
            string segundaFecha = "";

            if (cadenaTexto.Contains("desde el " ))
            {
                //busca desde
                resultado2 = cadenaTexto2.Substring(cadenaTexto2.IndexOf("desde el ") + 9, cadenaTexto2.Length - cadenaTexto2.IndexOf("desde el") - 9);
                primerVerbo = resultado2.Substring(0, resultado2.IndexOf("hasta el"));
                //Busca el primer verbo en aiml
                resultado3 = resultado2.Substring(resultado2.IndexOf("hasta el ") + 9, cadenaTexto2.Length - cadenaTexto2.IndexOf("hasta el") - 9);
                segundaFecha = resultado3.Substring(0, resultado3.IndexOf("."));
            }
            Extraer(primerVerbo,numero);
            Extraer(segundaFecha,numero+1);
           
            
        }

     
        private DateTime Extraer(string texto,int numero) {
            int dia;
            int mes=1;
            int año;
            string resultado2 = "";
            
            dia = Convert.ToInt32(texto.Substring(0, texto.IndexOf(" ")));
            resultado2 = texto.Substring(texto.IndexOf("de ") + 3, texto.Length - texto.IndexOf("de ") - 3);
            resultado2 = resultado2.Substring(0, resultado2.IndexOf(" del"));

            año =Convert.ToInt32( texto.Substring(texto.IndexOf("del ") + 4, texto.Length - texto.IndexOf("del ")-4));
            switch (resultado2)
            {
                case "Enero":
                    mes = 1;
                    break;
                case "Febrero":
                    mes = 2;
                    break;
                case "Marzo":
                    mes = 3;
                    break;
                case "Abril":
                    mes = 4;
                    break;
                case "Mayo":
                    mes = 5;
                    break;
                case "Junio":
                    mes = 6;
                    break;
                case "Julio":
                    mes = 7;
                    break;
                case "Agosto":
                    mes = 8;
                    break;
                case "Septiembre":
                    mes = 9;
                    break;
                case "Octubre":
                    mes = 10;
                    break;
                case "Noviembre":
                    mes = 11;
                    break;
                case "Diciembre":
                    mes = 12;
                    break;
            }
            if (numero == 1)
            {
                llenarDTP1(año,mes,dia);
            }else if (numero == 2)
            {
                llenarDTP2(año, mes, dia);
            }
            else if (numero == 3)
            {
                llenarDTP3(año, mes, dia);
            }
            else if (numero == 4)
            {
                llenarDTP4(año, mes, dia);
            }
            else if (numero == 5)
            {
                llenarDTP5(año, mes, dia);
            }
            else if (numero == 6)
            {
                llenarDTP6(año, mes, dia);
            }
            else if (numero == 7)
            {
                llenarDTP7(año, mes, dia);
            }
            else if (numero == 8)
            {
                llenarDTP8(año, mes, dia);
            }
            else if (numero == 9)
            {
                llenarDTP9(año, mes, dia);
            }
            else if (numero == 10)
            {
                llenarDTP10(año, mes, dia);
            }
            else if (numero == 11)
            {
                llenarDTP11(año, mes, dia);
            }
            else if (numero == 12)
            {
                llenarDTP12(año, mes, dia);
            }
            else if (numero == 13)
            {
                llenarDTP13(año, mes, dia);
            }
            else if (numero == 14)
            {
                llenarDTP14(año, mes, dia);
            }
            else if (numero == 15)
            {
                llenarDTP15(año, mes, dia);
            }
            else if (numero == 17)
            {
                llenarDTP16(año, mes, dia);
            }
            else if (numero == 18)
            {
                llenarDTP17(año, mes, dia);
            }

            DateTime fecha = new DateTime(año,mes,dia);
            return fecha;
        }
        private void llenarDTP1(int año, int mes, int dia)
        {
            dtp1.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP2(int año, int mes, int dia)
        {
            dtp2.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP3(int año, int mes, int dia)
        {
            dtp3.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP4(int año, int mes, int dia)
        {
            dtp4.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP5(int año, int mes, int dia)
        {
            dtp9.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP6(int año, int mes, int dia)
        {
            dtp10.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP7(int año, int mes, int dia)
        {
            dtp11.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP8(int año, int mes, int dia)
        {
            dtp12.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP9(int año, int mes, int dia)
        {
            dtp13.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP10(int año, int mes, int dia)
        {
            dtp14.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP11(int año, int mes, int dia)
        {
            dtp7.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP12(int año, int mes, int dia)
        {
            dtp8.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP13(int año, int mes, int dia)
        {
            dtpExtraordinariasInicio.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP14(int año, int mes, int dia)
        {
            dtpExtrordinariasFin.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP15(int año, int mes, int dia)
        {
            dtpExtensionAnillados.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP16(int año, int mes, int dia)
        {
            dtpBecasInicio.Value = new DateTime(año, mes, dia);
        }
        private void llenarDTP17(int año, int mes, int dia)
        {
            dtpBecasFin.Value = new DateTime(año, mes, dia);
        }
        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            dos = dtp2.Value;
        }

        private void dtp3_ValueChanged(object sender, EventArgs e)
        {
            tres = dtp3.Value;
        }

        private void dtp4_ValueChanged(object sender, EventArgs e)
        {
            cuatro = dtp4.Value;
        }

        private void dtp9_ValueChanged(object sender, EventArgs e)
        {
            cinco= dtp9.Value;
        }

        private void dtp10_ValueChanged(object sender, EventArgs e)
        {
            seis= dtp10.Value;
        }

        private void dtp11_ValueChanged(object sender, EventArgs e)
        {
            siete= dtp11.Value;
        }

        private void dtp12_ValueChanged(object sender, EventArgs e)
        {
            ocho= dtp12.Value;
        }

        private void dtp13_ValueChanged(object sender, EventArgs e)
        {
            nueve= dtp13.Value;
        }

        private void dtp14_ValueChanged(object sender, EventArgs e)
        {
            diez= dtp14.Value;
        }

        private void dtp7_ValueChanged(object sender, EventArgs e)
        {
            once= dtp7.Value;
        }

        private void dtp8_ValueChanged(object sender, EventArgs e)
        {
            doce= dtp8.Value;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int i = 0;
            int cambia = 1;
            i=VerificarFechas(uno,dos);
            if (i==-1)
            {
                cambia = -1;
            }
            i=VerificarFechas(tres,cuatro);
            if (i == -1)
            {
                cambia = -1;
            }
            i =VerificarFechas(cinco,seis);
            if (i == -1)
            {
                cambia = -1;
            }
            i =VerificarFechas(siete,ocho);
            if (i == -1)
            {
                cambia = -1;
            }
            i =VerificarFechas(nueve,diez);
            if (i == -1)
            {
                cambia = -1;
            }
            i =VerificarFechas(once,doce);
            if (i == -1)
            {
                cambia = -1;
            }
            i =VerificarFechas(becasInicio,becasFin);
            if (i == -1)
            {
                cambia = -1;
            }
            i =VerificarFechas(extraInicio,extaFin);
            if (i == -1)
            {
                cambia = -1;
            }
            if (cambia==1)
            {
                Template template = new Template();
                //uno
                template.IdTemplate = 2;
                template.Li = "Las matrículas ordinarias para el semestre 2019-A se realizarán desde el " + Llenar(uno) + " hasta el " + Llenar(dos) + ".";
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                //dos
                template.IdTemplate = 3;
                template.Li = "Las reinscripciones para el semestre 2019-A se realizarán desde el " + Llenar(tres) + " hasta el " + Llenar(cuatro) + ".";
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                //tres
                template.IdTemplate = 21;
                template.Li = "Puedes entregar esta solicitud desde el " + Llenar(cinco) + " hasta el " + Llenar(seis) + ".";
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                //cuatro
                template.IdTemplate = 22;
                template.Li = "Puedes entregar esta solicitud desde el " + Llenar(siete) + " hasta el " + Llenar(ocho) + ".";
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                //cinco
                template.IdTemplate = 23;
                template.Li = "Debes presentar tu cédula, tu papeleta de votación y la hoja de la última tutoría desde el " + Llenar(nueve) + " hasta el " + Llenar(diez) + ".";
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                //seis
                template.IdTemplate = 20;
                template.Li = "El semestre 2019-A, inicia desde el " + Llenar(once) + " hasta el " + Llenar(doce) + ".";
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                //EXTRAORDINARIAS
                template.IdTemplate = 48;
                template.Li = "Las matrículas extraordinarias para el semestre 2019-A se realizarán desde el " + Llenar(extraInicio) + " hasta el " + Llenar(extaFin) + ".";
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                //Ext anillados
                template.IdTemplate = 14;
                template.Li = "Puedes presentar los anillados" + " hasta el " + Llenar(extAnillados) + ".";
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                //Becas
                template.IdTemplate = 50;
                template.Li = "Los estudiantes de la EPN pueden aplicar a las becas otorgadas por la institución(Situación Económica y Mérito Cultural) desde el " + Llenar(becasInicio) + " hasta el " + Llenar(becasFin) + ".";
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                MessageBox.Show("¡Las fechas han sido actualizadas con éxito!", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("¡Error al ingresar las fechas! Verifique!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            
        }

        private int VerificarFechas(DateTime inicio, DateTime fin)
        {
            if (fin.Year>inicio.Year)
            {
                return 1;
            }
            else if (fin.Year==inicio.Year)
            {
                if (fin.Month>inicio.Month)
                {
                    return 1;
                }else if (fin.Month==inicio.Month)
                {
                    if (fin.Day>inicio.Day)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else 
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
            
        }
        private string Llenar(DateTime fecha)
        {
            string dia=Convert.ToString(fecha.Day);
            string mes = "";
            string año=Convert.ToString(fecha.Year);
            switch (fecha.Month)
            {
                case 1:
                    mes = "Enero";
                    break;
                case 2:
                    mes = "Febrero";
                    break;
                case 3:
                    mes = "Marzo";
                    break;
                case 4:
                    mes = "Abril";
                    break;
                case 5:
                    mes = "Mayo";
                    break;
                case 6:
                    mes = "Junio";
                    break;
                case 7:
                    mes = "Julio";
                    break;
                case 8:
                    mes = "Agosto";
                    break;
                case 9:
                    mes = "Septiembre";
                    break;
                case 10:
                    mes = "Octubre";
                    break;
                case 11:
                    mes = "Noviembre";
                    break;
                case 12:
                    mes = "Diciembre";
                    break;
            }
            string cadena = dia+" de "+mes+" del "+ año;

            
            return cadena;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            extraInicio = dtpExtraordinariasInicio.Value;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        public void cargardgv()
        {
            listaIngenieros.Clear();
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "INGENIERO";
            c1.Width = 265;
            c1.ReadOnly = true;

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "OFICINA";
            c2.Width = 265;
            c2.ReadOnly = true;

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.HeaderText = "TELÉFONO";
            c3.Width = 265;
            c3.ReadOnly = true;

            dgv.Columns.Add(c1);
            dgv.Columns.Add(c2);
            dgv.Columns.Add(c3);
            ObtenerProfesores();
            foreach (var item in listaIngenieros)
            {
                dgv.Rows.Add(item.Nombre, item.Oficina,item.Telefono);    
            }

        }

        public void cargardgvPalabrasClave()
        {
            listaPalabrasClave.Clear();
            listaPalabrasClaveTemplate.Clear();
            dgvListaPalabras.Rows.Clear();
            dgvListaPalabras.Columns.Clear();
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "LISTADO";
            c1.Width = 265;
            c1.ReadOnly = true;

            dgvListaPalabras.Columns.Add(c1);

            ObtenerPalabrasClave();
            foreach (var item in listaPalabrasClave)
            {
                dgvListaPalabras.Rows.Add(item.Pattern);
            }

        }


        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

              
           

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dgv_Click(object sender, EventArgs e)
        {
            txtNombreIngeniero.Text = Convert.ToString(dgv.CurrentRow.Cells[0].Value);
            txtNombreIngeniero.Enabled = false;
            txtOficinaIngeniero.Text = Convert.ToString(dgv.CurrentRow.Cells[1].Value);
            txtTelefonoIngeniero.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
            btnCambiosProfesor.Enabled = true;
            btnEliminarProfesor.Enabled = true;
            btnNuevoProfesor.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

         public String BuscarArchivo()
        {
            OpenFileDialog BuscarArchivo = new OpenFileDialog();
            BuscarArchivo.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm|*.pdf|*.docx";
            BuscarArchivo.FileName = "";
            BuscarArchivo.Title = "Titulo del Dialogo";
            BuscarArchivo.InitialDirectory = "C:\\";

            DialogResult result = BuscarArchivo.ShowDialog();

            // Si seleccionó un archivo (asumiendo que es una imagen lo que seleccionó)
            // la mostramos en el PictureBox de la inferfaz
            if (result == DialogResult.OK)
            {
                return BuscarArchivo.FileName;
            }
            else
            {
                return "";
            }
           
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void mostrarSemestre()
        {
            cbSemestre.Items.Clear();
            foreach (var item in clienteServicioAdministracion.todoslosSemestres())
            {
                cbSemestre.Items.Add(item.NombreSemestre);
                if (item.Seleccionado==1)
                {
                    idSemestreActual = item.Id;
                    cbSemestre.SelectedItem=item.NombreSemestre;
                }
                
            }
        }
        private void mostrarSemestreInicio()
        {
            cb1.Items.Clear();
            foreach (var item in clienteServicioAdministracion.todoslosSemestres())
            {
                cb1.Items.Add(item.NombreSemestre);
                if (item.Seleccionado == 1)
                {
                    idSemestreChatbot = item.Id;
                    cb1.SelectedItem = item.NombreSemestre;
                }

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSeminarios_Click(object sender, EventArgs e)
        {

        }

        private void btnMallaCurricular_Click(object sender, EventArgs e)
        {

        }

        private void tabInicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void btnHorarioMaterias_Click_1(object sender, EventArgs e)
        {
            String nuevoPath=BuscarArchivo();
            if (nuevoPath!="")
            {
                Template template = new Template();
                template.IdTemplate = 4;
                template.Li = Convert.ToString("¿Quieres que te envíe el horario de materias a tu correo institucional?-" + nuevoPath+".");
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                txtHorarioMaterias.Text = nuevoPath;
            }
 
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void txtHorarioMaterias_TextChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

       
        //Al momento de crear un nuevo semestre se copia toda la información del último semestre
        private void copiarTemplates(int nuevoid)
        {
            List<Template> listaTemplatesAntiguo = new List<Template>();     
            foreach (var item in clienteServicioAdministracion.listaTodoslosTemplates(nuevoid - 1, nuevoid))
            {
                listaTemplatesAntiguo.Add(item);
            }
            foreach (var item in listaTemplatesAntiguo)
            {
                clienteServicioAdministracion.insertarListaTemplates(item);
            }
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            txtNombreIngeniero.Enabled=true;
            if (txtNombreIngeniero.Text == ""|| txtOficinaIngeniero.Text == ""||txtTelefonoIngeniero.Text == "")
            {
                MessageBox.Show("¡No se ha podido actualizar! Verifique los parámetros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Template template = new Template();
                Ingeniero inge = new Ingeniero(txtNombreIngeniero.Text, txtOficinaIngeniero.Text, txtTelefonoIngeniero.Text);
                foreach (var item in listaIngenieros)
                {
                    if (item.Nombre == inge.Nombre)
                    {
                        template.Id = item.IdTemplate;
                    }
                }
                template.IdSemestre = idSemestreActual;
                template.Li = Convert.ToString("El ingeniero: " + inge.Nombre + ", tiene su oficina en el: " + inge.Oficina + ", y su teléfono es el: " + inge.Telefono + ".");
                clienteServicioAdministracion.modificarTemplateProfesor(template, idSemestreActual);
                txtNombreIngeniero.Text = "";
                txtOficinaIngeniero.Text = "";
                txtTelefonoIngeniero.Text = "";
                cargardgv();
                btnNuevoProfesor.Enabled = true;
                btnEliminarProfesor.Enabled = false;
                btnCambiosProfesor.Enabled = false;
                MessageBox.Show("¡Se ha actualizado los profesores con éxito!", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }

        }
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
            inputString = signo.Replace(inputString, "");
            char[] MyChar = { ']', '[', '-' };
            inputString = inputString.TrimEnd(MyChar);
            return inputString;
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            txtNombreIngeniero.Enabled = true;
            Template template = new Template();
            Ingeniero inge = new Ingeniero(txtNombreIngeniero.Text, txtOficinaIngeniero.Text, txtTelefonoIngeniero.Text);
            foreach (var item in listaIngenieros)
            {
                if (item.Nombre == inge.Nombre)
                {
                    template.Id = item.IdTemplate;
                }
            }
            int i=clienteServicioAdministracion.eliminarTemplate(template.Id, idSemestreActual); 
            if (i==1)
            {
                
                txtNombreIngeniero.Text = "";
                txtOficinaIngeniero.Text = "";
                txtTelefonoIngeniero.Text = "";
                cargardgv();
                btnNuevoProfesor.Enabled = true;
                btnEliminarProfesor.Enabled = false;
                btnCambiosProfesor.Enabled = false;
                MessageBox.Show("¡Profesor eliminado con éxito!", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("¡Error al eliminar profesor!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (txtNombreIngeniero.Text == "" || txtOficinaIngeniero.Text == "" || txtTelefonoIngeniero.Text == "")
            {
                MessageBox.Show("¡No se ha podido agregar nuevo profesor! Existen campos en blanco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                int g = 0;
                foreach (var item in listaIngenieros)
                {
                    if (String.Compare(item.Nombre,SinTildes(txtNombreIngeniero.Text), StringComparison.OrdinalIgnoreCase)==0)
                    {
                        g = 1;
                        break;
                    }
                }

                if (g==1)
                {
                    MessageBox.Show("¡Ya existe un profesor con ese nombre! Verifique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    int nuevoIdTemplate;
                    //Insertar Respuesta
                    Template template = new Template();
                    Ingeniero inge = new Ingeniero(SinTildes(txtNombreIngeniero.Text), txtOficinaIngeniero.Text, txtTelefonoIngeniero.Text);
                    template.IdTopic = 18;
                    template.IdSemestre = idSemestreActual;
                    template.Li = Convert.ToString("El ingeniero: " + inge.Nombre + ", tiene su oficina en el: " + inge.Oficina + ", y su teléfono es el: " + inge.Telefono + ".");
                    nuevoIdTemplate = clienteServicioAdministracion.insertarTemplate(template, idSemestreActual);
                    //Insertar patrón
                    int idConocimiento1;
                    int idConocimiento2;
                    int idConocimiento3;
                    int idConocimiento4;
                    Conocimiento conocimiento = new Conocimiento();
                    conocimiento.IdComplemento = 1;
                    conocimiento.IdTopic = 18;
                    conocimiento.Pattern = inge.Nombre + " *";
                    idConocimiento1 = clienteServicioAdministracion.insertarConocimiento(conocimiento);
                    conocimiento.Pattern = "_ " + inge.Nombre;
                    idConocimiento2 = clienteServicioAdministracion.insertarConocimiento(conocimiento);
                    conocimiento.Pattern = "_ " + inge.Nombre + " *";
                    idConocimiento3 = clienteServicioAdministracion.insertarConocimiento(conocimiento);
                    conocimiento.Pattern = inge.Nombre;
                    conocimiento.IdComplemento = 0;
                    idConocimiento4 = clienteServicioAdministracion.insertarConocimiento(conocimiento);

                    //Concatenar patrón con respuesta
                    ConocimientoTemplate conocimientoTemplate = new ConocimientoTemplate();
                    conocimientoTemplate.IdTemplate = nuevoIdTemplate;

                    conocimientoTemplate.IdConocimiento = idConocimiento1;
                    clienteServicioAdministracion.insertarConocimientoTemplate(conocimientoTemplate);
                    conocimientoTemplate.IdConocimiento = idConocimiento2;
                    clienteServicioAdministracion.insertarConocimientoTemplate(conocimientoTemplate);
                    conocimientoTemplate.IdConocimiento = idConocimiento3;
                    clienteServicioAdministracion.insertarConocimientoTemplate(conocimientoTemplate);
                    conocimientoTemplate.IdConocimiento = idConocimiento4;
                    clienteServicioAdministracion.insertarConocimientoTemplate(conocimientoTemplate);
                    txtNombreIngeniero.Text = "";
                    txtOficinaIngeniero.Text = "";
                    txtTelefonoIngeniero.Text = "";
                    cargardgv();
                    btnNuevoProfesor.Enabled = true;
                    MessageBox.Show("¡Nuevo porfesor registrado con éxito!", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                }

            }
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void cargarMatriculacion()
        {
            txtUno.Clear();
            SautinSoft.HtmlToRtf h = new SautinSoft.HtmlToRtf();
            string html = clienteServicioAdministracion.buscarFilaPorId(1, idSemestreActual).Li; 
            string rtf = String.Empty;
            if (h.OpenHtml(html))
            {
                rtf = h.ToRtf();
            }
            txtUno.Rtf = rtf;

            txtCinco.Clear();
            SautinSoft.HtmlToRtf h1 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(49, idSemestreActual).Li;
            rtf = String.Empty;
            if (h1.OpenHtml(html))
            {
                rtf = h1.ToRtf();
            }
            txtCinco.Rtf = rtf;

            txtRequisitosMatriculas.Clear();
            SautinSoft.HtmlToRtf h2 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(102, idSemestreActual).Li;
            rtf = String.Empty;
            if (h2.OpenHtml(html))
            {
                rtf = h2.ToRtf();
            }
            txtRequisitosMatriculas.Rtf = rtf;

            txtProcesoMatriculas.Clear();
            SautinSoft.HtmlToRtf h3 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(103, idSemestreActual).Li;
            rtf = String.Empty;
            if (h3.OpenHtml(html))
            {
                rtf = h3.ToRtf();
            }
            txtProcesoMatriculas.Rtf = rtf;
            

        }
        private void cargarCoordinacion()
        {
            txtHorarioCoordinacion.Clear();
            SautinSoft.HtmlToRtf h = new SautinSoft.HtmlToRtf();
            string html = clienteServicioAdministracion.buscarFilaPorId(25, idSemestreActual).Li;
            string rtf = String.Empty;
            if (h.OpenHtml(html))
            {
                rtf = h.ToRtf();
            }
            txtHorarioCoordinacion.Rtf = rtf;

            txtCoordinador.Clear();
            SautinSoft.HtmlToRtf h1 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(51, idSemestreActual).Li;
            rtf = String.Empty;
            if (h1.OpenHtml(html))
            {
                rtf = h1.ToRtf();
            }
            txtCoordinador.Rtf = rtf;

            txtSecretaria.Clear();
            SautinSoft.HtmlToRtf h2 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(52, idSemestreActual).Li;
            rtf = String.Empty;
            if (h2.OpenHtml(html))
            {
                rtf = h2.ToRtf();
            }
            txtSecretaria.Rtf = rtf;
        }
        private void cargarPrácticasPreprofesionales()
        {
            txtProcesoPracticas.Clear();
            SautinSoft.HtmlToRtf h = new SautinSoft.HtmlToRtf();
            string html = clienteServicioAdministracion.buscarFilaPorId(17, idSemestreActual).Li;
            string rtf = String.Empty;
            if (h.OpenHtml(html))
            {
                rtf = h.ToRtf();
            }
            txtProcesoPracticas.Rtf = rtf;

            txtEmpresas.Clear();
            SautinSoft.HtmlToRtf h1 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(16, idSemestreActual).Li;
            rtf = String.Empty;
            if (h1.OpenHtml(html))
            {
                rtf = h1.ToRtf();
            }
            txtEmpresas.Rtf = rtf;
            
        }
        private void cargarArchivos()
        {
            txtHorarioMaterias.Text = obtenerSoloElPath(clienteServicioAdministracion.buscarFilaPorId(4, idSemestreActual).Li);
            txtMallaCurricular.Text = obtenerSoloElPath(clienteServicioAdministracion.buscarFilaPorId(26, idSemestreActual).Li);
            txtSupletorios.Text = obtenerSoloElPath(clienteServicioAdministracion.buscarFilaPorId(27, idSemestreActual).Li);
            txtSeminarios.Text = obtenerSoloElPath(clienteServicioAdministracion.buscarFilaPorId(28, idSemestreActual).Li);
        }

        private void cargarTitulacion()
        {
            txtSeiss.Clear();
            SautinSoft.HtmlToRtf h = new SautinSoft.HtmlToRtf();
            string html = clienteServicioAdministracion.buscarFilaPorId(6, idSemestreActual).Li;
            string rtf = String.Empty;
            if (h.OpenHtml(html))
            {
                rtf = h.ToRtf();
            }
            txtSeiss.Rtf = rtf;

            txtCinncoo.Clear();
            SautinSoft.HtmlToRtf h1 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(5, idSemestreActual).Li;
            rtf = String.Empty;
            if (h1.OpenHtml(html))
            {
                rtf = h1.ToRtf();
            }
            txtCinncoo.Rtf = rtf;

            txtOcho.Clear();
            SautinSoft.HtmlToRtf h2 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(8, idSemestreActual).Li;
            rtf = String.Empty;
            if (h2.OpenHtml(html))
            {
                rtf = h2.ToRtf();
            }
            txtOcho.Rtf = rtf;


            txtSiete.Clear();
            SautinSoft.HtmlToRtf h3 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(7, idSemestreActual).Li;
            rtf = String.Empty;
            if (h3.OpenHtml(html))
            {
                rtf = h3.ToRtf();
            }
            txtSiete.Rtf = rtf;


            txtNueve.Clear();
            SautinSoft.HtmlToRtf h4 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(9, idSemestreActual).Li;
            rtf = String.Empty;
            if (h4.OpenHtml(html))
            {
                rtf = h4.ToRtf();
            }
            txtNueve.Rtf = rtf;

            txtDiez.Clear();
            SautinSoft.HtmlToRtf h5 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(10, idSemestreActual).Li;
            rtf = String.Empty;
            if (h5.OpenHtml(html))
            {
                rtf = h5.ToRtf();
            }
            txtDiez.Rtf = rtf;

            txtOnce.Clear();
            SautinSoft.HtmlToRtf h6 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(11, idSemestreActual).Li;
            rtf = String.Empty;
            if (h6.OpenHtml(html))
            {
                rtf = h6.ToRtf();
            }
            txtOnce.Rtf = rtf;

            txtDoce.Clear();
            SautinSoft.HtmlToRtf h7 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(12, idSemestreActual).Li;
            rtf = String.Empty;
            if (h7.OpenHtml(html))
            {
                rtf = h7.ToRtf();
            }
            txtDoce.Rtf = rtf;

            txtTrece.Clear();
            SautinSoft.HtmlToRtf h8 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(13, idSemestreActual).Li;
            rtf = String.Empty;
            if (h8.OpenHtml(html))
            {
                rtf = h8.ToRtf();
            }
            txtTrece.Rtf = rtf;

            txtQuince.Clear();
            SautinSoft.HtmlToRtf h9 = new SautinSoft.HtmlToRtf();
            html = clienteServicioAdministracion.buscarFilaPorId(15, idSemestreActual).Li;
            rtf = String.Empty;
            if (h9.OpenHtml(html))
            {
                rtf = h9.ToRtf();
            }
            txtQuince.Rtf = rtf;
            
        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarMatriculacion_Click(object sender, EventArgs e)
        {
            try
            {
                Template template = new Template();
                template.IdTemplate = 1;
                string rtf = txtUno.Rtf;
                var html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 49;
                rtf = txtCinco.Rtf;
                var html1 = Rtf.ToHtml(rtf);
                template.Li = html1;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 102;
                rtf = txtRequisitosMatriculas.Rtf;
                var html2 = Rtf.ToHtml(rtf);
                template.Li = html2;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 103;
                rtf = txtProcesoMatriculas.Rtf;
                var html3 = Rtf.ToHtml(rtf);
                template.Li = html3;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                cargarMatriculacion();
                MessageBox.Show("¡La información ha sido actualizadas con éxito!", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al actualizar! Verifique!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

           
        }

        private string chequearPuntoFinal(string mensaje)
        {
            string ultimo = mensaje.Substring(mensaje.Length);

            if (ultimo==".")
            {
                return mensaje;
            }
            else
            {
                mensaje = mensaje + ".";
                return mensaje;
            }
        }
        private void btnTitulacion_Click(object sender, EventArgs e)
        {
            try
            {


                Template template = new Template();
                template.IdTemplate = 6;
                string rtf = txtSeiss.Rtf;
                var html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 5;
                rtf = txtCinncoo.Rtf;
                html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 8;
                rtf = txtOcho.Rtf;
                html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 7;
                rtf = txtSiete.Rtf;
                html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 9;
                rtf = txtNueve.Rtf;
                html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 10;
                rtf = txtDiez.Rtf;
                html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 11;
                rtf = txtOnce.Rtf;
                html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 12;
                rtf = txtDoce.Rtf;
                html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 13;
                rtf =txtTrece.Rtf;
                html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 15;
                rtf = txtQuince.Rtf;
                html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                cargarTitulacion();
                MessageBox.Show("¡La información ha sido actualizadas con éxito!", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al actualizar! Verifique!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }
        private string obtenerSoloElPath(String cadenaTexto)
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
        private void dtpExtrordinariasFin_ValueChanged(object sender, EventArgs e)
        {
            extaFin = dtpExtrordinariasFin.Value;
        }

        private void dtpExtensionAnillados_ValueChanged(object sender, EventArgs e)
        {
            extAnillados = dtpExtensionAnillados.Value;
        }

        private void btnSupletorios_Click(object sender, EventArgs e)
        {

            String nuevoPath = BuscarArchivo();
            if (nuevoPath!="")
            {
                Template template = new Template();
                template.IdTemplate = 27;
                template.Li = Convert.ToString("¿Quieres que te envíe  a tu correo institucional el horario de supletorios?-" + nuevoPath+".");
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                txtSupletorios.Text = nuevoPath;
            }

        }

        private void btnMallaCurricular_Click_1(object sender, EventArgs e)
        {
            String nuevoPath = BuscarArchivo();
            if (nuevoPath!="")
            {
                Template template = new Template();
                template.IdTemplate = 26;
                template.Li = Convert.ToString("¿Quieres que te envíe a tu correo institucional la malla curricular de la carrera de tecnologías de la información?-" + nuevoPath+".");
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                txtMallaCurricular.Text = nuevoPath;
            }

        }

        private void btnSeminarios_Click_1(object sender, EventArgs e)
        {

            String nuevoPath = BuscarArchivo();
            if (nuevoPath!="")
            {
                Template template = new Template();
                template.IdTemplate = 28;
                template.Li = Convert.ToString("¿Quieres que te envíe a tu correo institucional el horario de los seminarios que se ofertan en este semestre?-" + nuevoPath+".");
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                txtSeminarios.Text = nuevoPath;
            }
           
        }

        private void dtpBecasInicio_ValueChanged(object sender, EventArgs e)
        {
            becasInicio = dtpBecasInicio.Value;
        }

        private void dtpBecasFin_ValueChanged(object sender, EventArgs e)
        {
            becasFin = dtpBecasFin.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try { 
                Template template = new Template();
                template.IdTemplate = 17;
                string rtf = txtProcesoPracticas.Rtf;
                var html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 16;
                rtf = txtEmpresas.Rtf;
                html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                cargarPrácticasPreprofesionales();
                MessageBox.Show("¡La información ha sido actualizadas con éxito!", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al actualizar! Verifique!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try { 
                Template template = new Template();
                template.IdTemplate = 25;
                string rtf = txtHorarioCoordinacion.Rtf;
                var html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 51;
                rtf = txtCoordinador.Rtf;
                html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);

                template.IdTemplate = 52;
                rtf = txtSecretaria.Rtf;
                html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                MessageBox.Show("¡La información ha sido actualizadas con éxito!", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al actualizar! Verifique!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            
        }

        private void label74_Click_1(object sender, EventArgs e)
        {

        }

        private void label81_Click(object sender, EventArgs e)
        {

        }

        private void dgvListaPalabras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgvListaPalabras_Click(object sender, EventArgs e)
        {
            txtPalabraClave.Enabled = false;
            btnEliminarPalabraClave.Enabled = true;
            btnGuardarPalabra.Enabled = true;
            btnAñadirPalabraClave.Enabled = false;
            ConocimientoTemplate conocimientoTemplate = new ConocimientoTemplate();
            Template template = new Template();
            txtPalabraClave.Text = Convert.ToString(dgvListaPalabras.CurrentRow.Cells[0].Value);
            foreach (var item in listaPalabrasClave)
            {
                if (item.Pattern==txtPalabraClave.Text)
                {
                   conocimientoTemplate=clienteServicioAdministracion.buscarFilaPorConocimiento(item.Id);
                   template=clienteServicioAdministracion.buscarFilaPorId(conocimientoTemplate.IdTemplate,idSemestreActual);
                    string texto = template.Li;
                    txtRespuestaClave.Clear();
                    SautinSoft.HtmlToRtf h = new SautinSoft.HtmlToRtf();
                    string html = texto;
                    string rtf = String.Empty;
                    if (h.OpenHtml(html))
                    {
                        rtf = h.ToRtf();
                    }

                    txtRespuestaClave.Rtf = rtf;
                   
                    
                }
            }
            
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if (txtPalabraClave.Text == "" || txtRespuestaClave.Text == "")
            {
                MessageBox.Show("¡No se ha podido actualizar! Verifique los parámetros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Conocimiento conocimiento = new Conocimiento();
                ConocimientoTemplate conocimientoTemplate = new ConocimientoTemplate();
                Template template = new Template();
                
                foreach (var item in listaPalabrasClave)
                {
                    if (item.Pattern==txtPalabraClave.Text)
                    {
                        conocimiento.Id= item.Id;
                        break;
                    }
                }

                conocimientoTemplate = clienteServicioAdministracion.buscarFilaPorConocimiento(conocimiento.Id);
                template.IdTemplate = conocimientoTemplate.IdTemplate;
                template.IdSemestre = idSemestreActual;
               
                string rtf = txtRespuestaClave.Rtf;
           
                var html = Rtf.ToHtml(rtf);
                template.Li = html;
                clienteServicioAdministracion.modificarTemplate(template, idSemestreActual);
                txtPalabraClave.Text = "";
                txtRespuestaClave.Text = "";
                cargardgvPalabrasClave();
                btnAñadirPalabraClave.Enabled = true;
                btnEliminarPalabraClave.Enabled = false;
                btnGuardarPalabra.Enabled = false;
                MessageBox.Show("¡Se ha actualizado los profesores con éxito!", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtPalabraClave.Enabled = true;
            }

        }

        private void button4_Click_2(object sender, EventArgs e)
        {

            if (txtPalabraClave.Text == "" || txtRespuestaClave.Text == "")
            {
                MessageBox.Show("¡No se ha podido actualizar! Existen campos en blanco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                int g = 0;
                foreach (var item in listaPalabrasClave)
                {
                   
                    if (String.Compare(item.Pattern,SinTildes(txtPalabraClave.Text), StringComparison.OrdinalIgnoreCase) ==0)
                    {
                        g = 1;
                        break;
                    }
                }
                if (g==1)
                {
                    MessageBox.Show("¡Ya existe esta palabra clave! Verifique.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                }
                else
                {
                    int nuevoIdTemplate;
                    //Insertar Respuesta
                    Template template = new Template();

                    template.IdTopic = 39;
                    template.IdSemestre = idSemestreActual;
                    string rtf = txtRespuestaClave.Rtf;
                    var html = Rtf.ToHtml(rtf);
                    template.Li = html;

                    nuevoIdTemplate = clienteServicioAdministracion.insertarTemplate(template, idSemestreActual);
                    //Insertar patrón
                    int idConocimiento1;
                    Conocimiento conocimiento = new Conocimiento();
                    conocimiento.IdComplemento = 0;
                    conocimiento.IdTopic = 39;
                    conocimiento.Pattern =SinTildes(txtPalabraClave.Text);
                    idConocimiento1 = clienteServicioAdministracion.insertarConocimiento(conocimiento);
                    //Concatenar patrón con respuesta
                    ConocimientoTemplate conocimientoTemplate = new ConocimientoTemplate();
                    conocimientoTemplate.IdTemplate = nuevoIdTemplate;

                    conocimientoTemplate.IdConocimiento = idConocimiento1;
                    clienteServicioAdministracion.insertarConocimientoTemplate(conocimientoTemplate);

                    txtPalabraClave.Text = "";
                    txtRespuestaClave.Text = "";
                    cargardgvPalabrasClave();
                    btnAñadirPalabraClave.Enabled = true;
                    MessageBox.Show("¡Nuevo porfesor registrado con éxito!", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                }

            }


        }

            private void button5_Click_2(object sender, EventArgs e)
            {
                if (txtRespuestaClave.SelectionFont != null)
                {
                    System.Drawing.Font currentFont = txtRespuestaClave.SelectionFont;
                    System.Drawing.FontStyle newFontStyle;
                    if (txtRespuestaClave.SelectionFont.Bold == true)
                    {
                        newFontStyle = FontStyle.Regular;
                    
                    }
                    else
                    {
                        newFontStyle = FontStyle.Bold;
                    }
                    txtRespuestaClave.SelectionFont = new Font(currentFont.FontFamily,currentFont.Size,newFontStyle);
                }
            }

        private void txtRespuestaClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminarPalabraClave_Click(object sender, EventArgs e)
        {

            Template template = new Template();
            Conocimiento conocimiento = new Conocimiento();
            ConocimientoTemplate conocimientoTemplate = new ConocimientoTemplate();
            foreach (var item in listaPalabrasClave)
            {
                if (item.Pattern == txtPalabraClave.Text)
                {
                    conocimiento.Id = item.Id;
                    break;
                }
            }
            conocimientoTemplate = clienteServicioAdministracion.buscarFilaPorConocimiento(conocimiento.Id);
                       
            template.IdTemplate = conocimientoTemplate.IdTemplate;
            template.IdSemestre = idSemestreActual;

            int ini = clienteServicioAdministracion.eliminarTemplate(template.IdTemplate, idSemestreActual);
            if (ini == 1)
            {
                txtPalabraClave.Enabled = true;
                txtPalabraClave.Text = "";
                txtRespuestaClave.Text = "";
                cargardgvPalabrasClave();
                btnAñadirPalabraClave.Enabled = true;
                btnEliminarPalabraClave.Enabled = false;
                btnGuardarPalabra.Enabled = false;
                MessageBox.Show("¡Profesor eliminado con éxito!", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("¡Error al eliminar profesor!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            int nuevoid = clienteServicioAdministracion.insertarSemestre();
            if (nuevoid > 0)
            {
                MessageBox.Show("¡Nuevo semestre ingresado con éxito!", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if (nuevoid == 0)
            {
                MessageBox.Show("Error al ingresar nuevo semestre!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if (nuevoid == -1)
            {
                MessageBox.Show("¡Solo se permite ingresar hasta el semestre 2023-B!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            copiarTemplates(nuevoid);
            mostrarSemestre();
            mostrarSemestreInicio();
        }

        private void cbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string seleccion = Convert.ToString(cbSemestre.SelectedItem);
            idSemestreActual = clienteServicioAdministracion.seleccionarSemestreTexto(seleccion).Id;
            LlenarFechas();
            cargarArchivos();
            cargardgv();
            cargarMatriculacion();
            cargarTitulacion();
            cargarPrácticasPreprofesionales();
            cargarCoordinacion();
            cargardgvPalabrasClave();
            txtNombreIngeniero.Text = "";
            txtOficinaIngeniero.Text = "";
            txtTelefonoIngeniero.Text = "";
            btnNuevoProfesor.Enabled = true;
            btnEliminarProfesor.Enabled = false;
            btnCambiosProfesor.Enabled = false;
            txtPalabraClave.Text = "";
            txtRespuestaClave.Text = "";
            txtRespuestaClave.SelectedRtf = null;
            btnEliminarPalabraClave.Enabled = false;
            btnGuardarPalabra.Enabled = false;
            btnAñadirPalabraClave.Enabled = true;
            txtNombreIngeniero.Enabled = true;
            txtPalabraClave.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int idAnterior = idSemestreChatbot;
            string seleccion = Convert.ToString(cb1.SelectedItem);
            idSemestreChatbot = clienteServicioAdministracion.seleccionarSemestreTexto(seleccion).Id;
            clienteServicioAdministracion.semestreSeleccionado(idAnterior,idSemestreChatbot);
            clienteServicioAdministracion.semestreSeleccionado(idAnterior, idSemestreChatbot);
        }

        private void label82_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label84_Click(object sender, EventArgs e)
        {

        }

        private void label85_Click(object sender, EventArgs e)
        {

        }

        private void label76_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            txtPalabraClave.Text = "";
            txtRespuestaClave.Text = "";
            btnEliminarPalabraClave.Enabled = false;
            btnGuardarPalabra.Enabled = false;
            btnAñadirPalabraClave.Enabled = true;
            txtPalabraClave.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtNombreIngeniero.Enabled = true;
            txtNombreIngeniero.Text = "";
            txtOficinaIngeniero.Text = "";
            txtTelefonoIngeniero.Text = "";
            btnNuevoProfesor.Enabled = true;
            btnEliminarProfesor.Enabled = false;
            btnCambiosProfesor.Enabled = false;
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_3(object sender, EventArgs e)
        {
            if (txtUno.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtUno.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtUno.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtUno.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }

            

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txtRequisitosMatriculas.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtRequisitosMatriculas.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtRequisitosMatriculas.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtRequisitosMatriculas.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (txtProcesoMatriculas.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtProcesoMatriculas.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtProcesoMatriculas.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtProcesoMatriculas.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {

            if (txtCinco.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtCinco.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtCinco.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtCinco.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void button5_Click_3(object sender, EventArgs e)
        {

            if (txtSeiss.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtSeiss.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtSeiss.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtSeiss.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (txtCinncoo.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtCinncoo.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtCinncoo.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtCinncoo.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (txtOcho.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtOcho.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtOcho.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtOcho.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (txtSiete.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtSiete.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtSiete.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtSiete.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (txtNueve.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtNueve.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtNueve.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtNueve.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (txtDiez.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtDiez.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtDiez.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtDiez.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (txtDoce.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtDoce.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtDoce.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtDoce.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (txtTrece.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtTrece.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtTrece.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtTrece.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (txtOnce.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtOnce.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtOnce.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtOnce.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (txtQuince.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtQuince.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtQuince.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtQuince.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtProcesoPracticas.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtProcesoPracticas.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtProcesoPracticas.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtProcesoPracticas.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (txtEmpresas.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtEmpresas.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtEmpresas.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtEmpresas.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void btnGuardarCoordinacion_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (txtCoordinador.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtCoordinador.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtCoordinador.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtCoordinador.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void txtCoordinador_TextChanged(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (txtHorarioCoordinacion.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtHorarioCoordinacion.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtHorarioCoordinacion.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtHorarioCoordinacion.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (txtSecretaria.SelectionFont != null)
            {
                System.Drawing.Font currentFont = txtSecretaria.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (txtSecretaria.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }
                txtSecretaria.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void btnInformacion_Click(object sender,  EventArgs e)
        {
            Información frm = new Información();
            frm.Show();
        }
    }

}
