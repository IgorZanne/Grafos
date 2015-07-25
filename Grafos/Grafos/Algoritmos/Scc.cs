using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafos.Estruturas;

namespace Grafos.Algoritmos
{
    public class Scc : Algoritmo
    {
        private void dfs(Grafo grafo)
        {
            foreach(var vertice in grafo.Vertices)
            {
                vertice.Cor = CoresEnum.Branco;
                vertice.Pai = null;
            }
            int tempo = 0;
            foreach(var vertice in grafo.Vertices)
            {
                if (vertice.Cor == CoresEnum.Branco)
                {
                    dfsVisit(vertice, tempo);
                }
            }
        }

        private void dfsVisit(Vertice U, int tempo)
        {
            tempo = tempo++;
            U.Cor = CoresEnum.Cinza;
            U.Descoberta = tempo;
            foreach(Vertice vertice in U.Adj)
            {
                if (vertice.Cor == CoresEnum.Branco)
                {
                    vertice.Pai = U;
                    dfsVisit(vertice, tempo);
                }
            }
            U.Cor = CoresEnum.Preto;
            tempo = tempo++;
            //U.finalizacao = tempo;
        }

        private void calculaTransposto(Grafo grafo)
        {
            Grafo grafoTransposto = new Grafo();
            foreach(var vertice in grafo.Vertices)
            {
                
            }
        }
        public override IEnumerable<string> Executar(Grafo grafo)
        {
            dfs(grafo);

            throw new NotImplementedException();
        }
    }
}
