using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    //Clase que representa a las respuestas del chatbot
    [Serializable]
    public class Template
    {
        private int id;
        private int idTemplate;
        private int idTopic;
        private String li;
        private int idSemestre;

        public Template() { }

        public Template(int id, int idTemplate, int idTopic, string li, int idSemestre)
        {
            this.id = id;
            this.idTemplate = idTemplate;
            this.idTopic = idTopic;
            this.li = li;
            this.idSemestre = idSemestre;
        }

        public int Id { get => id; set => id = value; }
        public int IdTemplate { get => idTemplate; set => idTemplate = value; }
        public int IdTopic { get => idTopic; set => idTopic = value; }
        public string Li { get => li; set => li = value; }
        public int IdSemestre { get => idSemestre; set => idSemestre = value; }

        public override string ToString()
        {
            return this.Li;
        }

    }
}
