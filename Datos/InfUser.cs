using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    //Clase que almacena al usuario del chatbot con el tema de conversación que mantiene con el chatbot
    [Serializable]
    public class InfUser
    {
        private int id;
        private int idUser;
        private int idTopic;
        private int esAutenticado;
        public InfUser() { }

        public InfUser(int id, int idUser, int idTopic)
        {
            this.id = id;
            this.idUser = idUser;
            this.idTopic = idTopic;
        }

        public InfUser(int id, int idUser, int idTopic, int esAutenticado)
        {
            this.id = id;
            this.idUser = idUser;
            this.idTopic = idTopic;
            this.esAutenticado = esAutenticado;
        }

        public int Id { get => id; set => id = value; }
        public int IdUser { get => idUser; set => idUser = value; }
        public int IdTopic { get => idTopic; set => idTopic = value; }
        public int EsAutenticado { get => esAutenticado; set => esAutenticado = value; }
    }
}

