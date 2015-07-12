using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.Estruturas
{
    public class Aresta
    {
        public int Peso { get; set; }
        public Vertice Origem { get; set; }
        public Vertice Destino { get; set; }
    }
}
