
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    //Clase que representa a un estudiante con sus credenciales
    [Serializable]
    public class Estudiante
    {
        private String correo;
        private String password;

        public Estudiante() { }
        public Estudiante(string correo, string password)
        {
            this.Correo = correo;
            this.Password = password;
        }

        public string Correo { get => correo; set => correo = value; }
        public string Password { get => password; set => password = value; }
    }
}
