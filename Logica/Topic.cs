using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Topic
    {
        private int id;
        private String tema;

        public Topic() { }

        public Topic(int id, string tema)
        {
            this.Id = id;
            this.Tema = tema;
        }

        public int Id { get => id; set => id = value; }
        public string Tema { get => tema; set => tema = value; }

        public override string ToString()
        {
            return this.Tema;
        }
    }
}
