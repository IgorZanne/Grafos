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
        public List<Vertice> Vertices { get; set; }
        public List<Aresta> Arestas { get; set; }

        public Grafo()
        {
            this.Direcionado = false;
            this.Vertices = new List<Vertice>();
            this.Arestas = new List<Aresta>();
        }

        public Grafo(bool direcionado)
        {
            this.Direcionado = direcionado;
            this.Vertices = new List<Vertice>();
            this.Arestas = new List<Aresta>();
        }
    }
}
