using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    //Clase que permite relacionar un mensaje que el chatbot entiende con su respuesta
    [Serializable]
    public class ConocimientoTemplate
    {
        private int id;
        private int idConocimiento;
        private int idTemplate;

        public ConocimientoTemplate() { }

        public ConocimientoTemplate(int id, int idConocimiento, int idTemplate)
        {
            this.Id = id;
            this.IdConocimiento = idConocimiento;
            this.IdTemplate = idTemplate;
        }

        public int Id { get => id; set => id = value; }
        public int IdConocimiento { get => idConocimiento; set => idConocimiento = value; }
        public int IdTemplate { get => idTemplate; set => idTemplate = value; }
    }
}
