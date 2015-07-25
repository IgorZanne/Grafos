using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.Estruturas
{
    public class Vertice
    {
        public Vertice(string id)
        {
            this.Id = id;
            this.Descoberta = 0;
            this.Cor = CoresEnum.Branco;
        }

        public CoresEnum Cor {get; set;}
        public Vertice Pai { get; set; }
        public string Id { get; set; }
        public int Descoberta { get; set; }
    }
}
