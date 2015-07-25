using Grafos.Estruturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.Algoritmos
{
    public abstract class Algoritmo
    {
        public abstract IEnumerable<string> Executar(Grafo grafo);
    }
}
