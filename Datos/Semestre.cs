using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    //Clase que representa los periodos académicos
    [Serializable]
    public class Semestre
    {
        private int id;
        private String nombreSemestre;
        private int seleccionado;

        public Semestre() { }

        public Semestre(int id, string nombreSemestre, int seleccionado)
        {
            this.id = id;
            this.nombreSemestre = nombreSemestre;
            this.seleccionado = seleccionado;
        }

        public int Id { get => id; set => id = value; }
        public string NombreSemestre { get => nombreSemestre; set => nombreSemestre = value; }
        public int Seleccionado { get => seleccionado; set => seleccionado = value; }
    }
}
