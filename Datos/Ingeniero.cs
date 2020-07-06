using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    //Clase que representa a un profesor con su información
    [Serializable]
    public class Ingeniero
    {
        private int idTemplate;
        private String nombre;
        private String oficina;
        private String telefono;
        public Ingeniero() { }
        public Ingeniero(string nombre, string oficina, string telefono)
        {
            this.nombre = nombre;
            this.oficina = oficina;
            this.telefono = telefono;
        }

        public Ingeniero(string nombre, string oficina, string telefono, int idTemplate)
        {
            this.idTemplate = idTemplate;
            this.nombre = nombre;
            this.oficina = oficina;
            this.telefono = telefono;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Oficina { get => oficina; set => oficina = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int IdTemplate { get => idTemplate; set => idTemplate = value; }
    }
}
