using Grafos.Estruturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.Algoritmos
{
    public class Dfs
    {
        private int tempo;
        private Grafo grafo;

        public void Executar(Grafo grafo)
        {
            this.grafo = grafo;
            tempo = 0;
            foreach (var item in (true ? grafo.Vertices : grafo.Vertices.OrderByDescending(e => e.Finalizacao).ToList()))
            {
                if (item.Cor == CoresEnum.Branco)
                    dfsVisit(item);
            }
        }

        public void dfsVisit(Vertice vertice) 
        {
            tempo++;
            vertice.Descoberta++;
            vertice.Cor = CoresEnum.Cinza;

            foreach (var v in grafo.GetAdj(vertice.Id))
            {
                if (v.Cor == CoresEnum.Branco)
                {
                    v.Pai = vertice;
                    dfsVisit(v);
                }
            }

            vertice.Cor = CoresEnum.Preto;
            tempo++;
            vertice.Finalizacao = tempo;
        }
    }
}
