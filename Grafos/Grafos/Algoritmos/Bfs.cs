using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafos.Estruturas;

namespace Grafos.Algoritmos
{
    public class Bfs : Algoritmo
    {
        public override string Executar(Grafo grafo)
        {
            foreach (var vertice in grafo.Vertices)
            {
                vertice.Cor = CoresEnum.Branco;
                vertice.Pai = null;
                
            }

            throw new NotImplementedException();
        }
    }
}
