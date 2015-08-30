using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafos.Estruturas;

namespace Grafos.Algoritmos
{
    public class Dk : Algoritmo
    {
        private void initialize(Grafo grafo)
        {
            foreach (var vertice in grafo.Vertices)
            {
                vertice.Value.Descoberta = Int32.MaxValue;
                vertice.Value.Pai = null;
            }
        }

        private void relax(Vertice u, Vertice v, int w)
        {
            if (u.Descoberta != Int32.MaxValue && v.Descoberta > (u.Descoberta + w))
            {
                v.Descoberta = u.Descoberta + w;
                v.Pai = u;
            }
        }
        public override IEnumerable<string> Executar(Grafo grafo)
        {
            var retorno = new List<string>();
            grafo.Direcionado = true;
            initialize(grafo);
            var s = grafo.Vertices.First();
            s.Value.Descoberta = 0;
            Dictionary<string, Vertice> q = new Dictionary<string, Vertice>();
            List<Vertice> w = new List<Vertice>();
            q = grafo.Vertices;
            while (q.Any())
            {
                q.OrderBy(e => e.Value.Descoberta).ToList();
                var u = q.First();
                q.Remove(q.Keys.First());

                foreach (var vertice in grafo.GetAdj(u.Value.Id))
                {
                    var aresta = grafo.Arestas
                        .Where(e => e.Origem.Id.Equals(u.Value.Id)
                                 && e.Destino.Id.Equals(vertice.Value.Id))
                        .FirstOrDefault();
                    relax(u.Value, vertice.Value, aresta.Peso);
                    
                }

                if (u.Value.Descoberta != Int32.MaxValue)
                    retorno.Add(String.Format("{0} {1} {2}", s.Value.Id, u.Value.Id, u.Value.Descoberta));

            }
            return retorno;
        }
    }
}
