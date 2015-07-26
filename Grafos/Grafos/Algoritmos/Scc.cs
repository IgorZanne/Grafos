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
        private int tempo;
        private string componente;
        private List<string> retorno = new List<string>();

        private void dfs(Grafo grafo, bool decrescente)
        {
            grafo.Direcionado = true;
            foreach(var vertice in grafo.Vertices)
            {
                vertice.Cor = CoresEnum.Branco;
                vertice.Pai = null;
            }
            tempo = 0;
            foreach (var vertice in (!decrescente ? grafo.Vertices : grafo.Vertices.OrderByDescending(e => e.Finalizacao).ToList()))
            {
                if (vertice.Cor == CoresEnum.Branco)
                {
                    componente = string.Empty;
                    dfsVisit(vertice);
                    if (decrescente)
                        retorno.Add(componente);
                }
            }
        }

        private void dfsVisit(Vertice u)
        {
            componente = componente + " " + u.Id;
            tempo++;
            u.Cor = CoresEnum.Cinza;
            u.Descoberta = tempo;
            foreach(Vertice vertice in grafoCorrente.GetAdj(u.Id))
            {
                if (vertice.Cor == CoresEnum.Branco)
                {
                    vertice.Pai = u;
                    dfsVisit(vertice);
                }
            }
            u.Cor = CoresEnum.Preto;
            tempo++;
            u.Finalizacao = tempo;
        }

        public override IEnumerable<string> Executar(Grafo grafo)
        {
            grafoCorrente = grafo;
            dfs(grafo, false);
            var transposto = GrafoHelper.GetTransposto(grafo);
            dfs(transposto, true);

            return retorno;
        }
    }
}
