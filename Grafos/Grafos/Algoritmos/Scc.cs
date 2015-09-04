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
            foreach (var vertice in grafo.Vertices)
            {
                vertice.Value.Cor = CoresEnum.Branco;
                vertice.Value.Pai = null;
            }
            tempo = 0;
            foreach (var vertice in (!decrescente ? grafo.Vertices : grafo.Vertices.OrderByDescending(e => e.Value.Finalizacao).AsEnumerable()))
            {
                if (vertice.Value.Cor == CoresEnum.Branco)
                {
                    componente = string.Empty;
                    dfsVisit(vertice.Value);
                    if (decrescente)
                        retorno.Add(componente.Trim());
                }
            }
        }

        private void dfsVisit(Vertice u)
        {
            componente += " " + u.Id;
            tempo++;
            u.Cor = CoresEnum.Cinza;
            u.Descoberta = tempo;
            foreach(var vertice in grafoCorrente.GetAdj(u.Id))
            {
                if (vertice.Value.Cor == CoresEnum.Branco)
                {
                    vertice.Value.Pai = u;
                    dfsVisit(vertice.Value);
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
