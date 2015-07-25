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
        public override IEnumerable<string> Executar(Grafo grafo)
        {
            foreach (var vertice in grafo.Vertices)
            {
                vertice.Cor = CoresEnum.Branco;
                vertice.Pai = null;
            }
            List<Vertice> Q = new List<Vertice>();
            Q.Add(grafo.Vertices.First());
            while (Q.Any())
            {
                Vertice U;
                U = Q.First();
                foreach (var Vertice in U.Adj)
                {
                    if (Vertice.Cor == CoresEnum.Branco)
                    {
                        Vertice.Descoberta = U.Descoberta + 1;
                        Vertice.Pai = U;
                        Vertice.Cor = CoresEnum.Cinza;
                        Q.Add(Vertice);
                    }
                }
                U.Cor = CoresEnum.Preto;
            }

            throw new NotImplementedException();
        }
    }
}
