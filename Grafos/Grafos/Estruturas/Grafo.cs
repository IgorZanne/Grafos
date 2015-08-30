using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.Estruturas
{
    public class Grafo
    {
        public bool Direcionado { get; set; }
        public List<Aresta> Arestas { get; set; }

        public Dictionary<string, Vertice> Vertices { get; set; }

        public Dictionary<string, Vertice> GetAdj(string vertice)
        {
            return Vertices[vertice].Adjacentes;
        }

        public Grafo()
        {
            this.Direcionado = true;
            this.Vertices = new Dictionary<string, Vertice>();
            this.Arestas = new List<Aresta>();
        }

        public Grafo(bool direcionado)
        {
            this.Direcionado = direcionado;
            this.Vertices = new Dictionary<string, Vertice>();
            this.Arestas = new List<Aresta>();
        }
    }
}
