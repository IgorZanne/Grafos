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
            grafo.Direcionado = true;

            var retorno = new List<string>();
            List<Vertice> Q = new List<Vertice>();
            Q.Add(grafo.Vertices.First());
            while (Q.Any())
            {
                Vertice U = Q.First();
                Q.RemoveAt(0);
                foreach (var Vertice in grafo.GetAdj(U.Id))
                {
                    if (Vertice.Cor == CoresEnum.Branco)
                    {
                        Vertice.Descoberta = U.Descoberta + 1;
                        Vertice.Pai = U;
                        Vertice.Cor = CoresEnum.Cinza;
                        Q.Add(Vertice);
                    }
                }
                retorno.Add(String.Format("{0} {1} {2}", grafo.Vertices.First().Id, U.Id, U.Descoberta));
                U.Cor = CoresEnum.Preto;
            }

            return retorno;
        }
    }
}
