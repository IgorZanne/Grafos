using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafos.Estruturas;
using Grafos.Helpers;

namespace Grafos.Algoritmos
{
    public class Scc : Algoritmo
    {
        private Grafo grafoCorrente;

        private void dfs(Grafo grafo, bool decrescente)
        {
            foreach(var vertice in grafo.Vertices)
            {
                vertice.Cor = CoresEnum.Branco;
                vertice.Pai = null;
            }
            int tempo = 0;
            foreach (var vertice in (decrescente ? grafo.Vertices : grafo.Vertices.OrderByDescending(e => e.Finalizacao).ToList()))
            {
                if (vertice.Cor == CoresEnum.Branco)
                {
                    dfsVisit(vertice, tempo);
                }
            }
        }

        private void dfsVisit(Vertice u, int tempo)
        {
            tempo = tempo++;
            u.Cor = CoresEnum.Cinza;
            u.Descoberta = tempo;
            foreach(Vertice vertice in grafoCorrente.GetAdj(u.Id))
            {
                if (vertice.Cor == CoresEnum.Branco)
                {
                    vertice.Pai = u;
                    dfsVisit(vertice, tempo);
                }
            }
            u.Cor = CoresEnum.Preto;
            tempo = tempo++;
            u.Finalizacao = tempo;
        }

        public override IEnumerable<string> Executar(Grafo grafo)
        {
            grafoCorrente = grafo;
            dfs(grafo, false);
            var tranposto = GrafoHelper.GetTransposto(grafo);
            dfs(tranposto, true);


            throw new NotImplementedException();
        }
    }
}
