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

        public Grafo(bool direcionado)
        {
            this.Direcionado = direcionado;
            this.Vertices = new List<Vertice>();
            this.Arestas = new List<Aresta>();
        }

        public Grafo Ler(string caminhoArquivo, bool direcionado)
        {
            var arquivo = File.ReadAllLines(caminhoArquivo);
            var retorno = new Grafo(direcionado);

            var primeiraParte = true;
            foreach (var linha in arquivo)
            {
                if (linha.Equals("#"))
                    primeiraParte = false;
                if (primeiraParte)
                    retorno.Vertices.Add(new Vertice());
                else
                    retorno.Arestas.Add(new Aresta());
            }

            return retorno;
        }
    }
}
