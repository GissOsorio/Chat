using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    //Clase que almacena los mensajes que el chatbot entiende
    [Serializable]
    public class Conocimiento
    {
        private int id;
        private int idTopic;
        private String pattern;
        private int idComplemento;

        public Conocimiento() { }

        public Conocimiento(int idTopic, string pattern)
        {
            this.idTopic = idTopic;
            this.pattern = pattern;
        }

        public Conocimiento(int id, int idTopic, string pattern)
        {
            this.Id = id;
            this.IdTopic = idTopic;
            this.Pattern = pattern;
        }

        public Conocimiento(int id, int idTopic, string pattern, int idComplemento)
        {
            this.id = id;
            this.idTopic = idTopic;
            this.pattern = pattern;
            this.idComplemento = idComplemento;
        }

        public int Id { get => id; set => id = value; }
        public int IdTopic { get => idTopic; set => idTopic = value; }
        public string Pattern { get => pattern; set => pattern = value; }
        public int IdComplemento { get => idComplemento; set => idComplemento = value; }

        public override string ToString()
        {
            return this.Pattern;
        }
    }
}
