using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    //Clase que representa a un usuario que ingresa al chatbot sin auntenticación
    [Serializable]
    public class Publico
    {
        private int id;
        private string correo;
        public Publico()
        {

        }
        public Publico(int id, string correo)
        {
            this.id = id;
            this.correo = correo;
        }

        public int Id { get => id; set => id = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
