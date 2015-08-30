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
            Dictionary<string, Vertice> Q = new Dictionary<string, Vertice>();
            var primeiro = grafo.Vertices.First();
            Q.Add(primeiro.Key, primeiro.Value);
            while (Q.Any())
            {
                var U = Q.First();
                Q.Remove(Q.Keys.First());
                foreach (var vertice in grafo.GetAdj(U.Key))
                {
                    if (vertice.Value.Cor == CoresEnum.Branco)
                    {
                        vertice.Value.Descoberta = U.Value.Descoberta + 1;
                        vertice.Value.Pai = U.Value;
                        vertice.Value.Cor = CoresEnum.Cinza;
                        Q.Add(vertice.Key, vertice.Value);
                    }
                }
                retorno.Add(String.Format("{0} {1} {2}", grafo.Vertices.First().Key, U.Value.Id, U.Value.Descoberta));
                U.Value.Cor = CoresEnum.Preto;
            }

            return retorno;
        }
    }
}
