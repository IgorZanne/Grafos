using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.Estruturas
{
    public class Vertice
    {
        public CoresEnum Cor {get; set;}
        public Vertice Pai { get; set; }
        public List<Vertice> Adj { get; set; }
        public string Id { get; set; }
        public int Descoberta { get; set; }
    }
}
