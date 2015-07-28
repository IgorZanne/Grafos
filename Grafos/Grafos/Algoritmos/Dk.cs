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
                vertice.Descoberta = Int32.MaxValue;
                vertice.Pai = null;
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
            Vertice s = grafo.Vertices.First();
            s.Descoberta = 0;
            List<Vertice> q = new List<Vertice>();
            List<Vertice> w = new List<Vertice>();
            q.AddRange(grafo.Vertices);
            while (q.Any())
            {
                q.OrderBy(e => e.Descoberta).ToList();
                Vertice u = q.First();
                q.RemoveAt(0);
                
                foreach(var vertice in grafo.GetAdj(u.Id))
                {
                    var aresta = grafo.Arestas
                        .Where(e => e.Origem.Id.Equals(u.Id)
                                 && e.Destino.Id.Equals(vertice.Id))
                        .FirstOrDefault();
                    relax(u, vertice, aresta.Peso);
                    
                }

                if (u.Descoberta != Int32.MaxValue)
                    retorno.Add(String.Format("{0} {1} {2}", s.Id, u.Id, u.Descoberta));

            }
            return retorno;
        }
    }
}
