using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafos.Estruturas;

namespace Grafos.Algoritmos
{
    public class Bf : Algoritmo
    {
        private Grafo _grafo;
        private void initialize(Grafo grafo)
        {
            foreach(var vertice in grafo.Vertices)
            {
                vertice.Value.Descoberta = Int32.MaxValue;
                vertice.Value.Pai = null;
            }
            _grafo = grafo;
        }

        //private void relax(Vertice u, Vertice v, int w)
        //{
        //    if (v.Descoberta > (u.Descoberta+w))
        //    {
        //        v.Descoberta = u.Descoberta + w;
        //        v.Pai = u;
        //    }
        //}

        private void relax(string u, string v, int w)
        {
            if (_grafo.Vertices[v].Descoberta > (_grafo.Vertices[u].Descoberta + w))
            {
                _grafo.Vertices[v].Descoberta = _grafo.Vertices[u].Descoberta + w;
                _grafo.Vertices[v].Pai = _grafo.Vertices[u];
            }
        }

        public override IEnumerable<string> Executar(Grafo grafo)
        {
            var retorno = new List<string>();
            grafo.Direcionado = true;
            initialize(grafo);
            var s = grafo.Vertices.First();
            s.Value.Descoberta = 0;
            int i;
            for (i = 1; i < grafo.Vertices.Count -1; i++ )
            {
                foreach(var aresta in grafo.Arestas)
                {
                    relax(aresta.Origem, aresta.Destino, aresta.Peso);       
                }
            }

            foreach (var ver in grafo.Vertices)
            {
                var saida = ver.Value.Descoberta.ToString();
                while (ver.Value.Pai != null)
                {
                    saida = ver.Value.Pai.Id + " " + saida;
                }

                if (saida.StartsWith(grafo.Vertices.First().Value.Id))
                    retorno.Add(saida);
            }

            return retorno;
        }
    }
}
