using Grafos.Estruturas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.Helpers
{
    public static class GrafoHelper
    {
        public static Grafo Ler(string caminhoArquivo)
        {
            var arquivo = File.ReadAllLines(caminhoArquivo);
            var retorno = new Grafo();

            var primeiraParte = true;
            foreach (var linha in arquivo)
            {
                if (linha.Equals("#"))
                {
                    primeiraParte = false;
                    continue;
                }
                if (primeiraParte) 
                {
                    var vertice = new Vertice(linha);
                    retorno.Vertices.Add(linha, vertice);
                }
                else
                {
                    var carac = linha.Split(' ');
                    var tamanho = carac.Length;
                    if (tamanho <= 0 || tamanho > 3)
                        throw new Exception("Não foi possível identificar especificações da aresta no arquivo de entrada");

                    if (tamanho >= 2) 
                    {
                        var origem = retorno.Vertices[carac[0]];
                        var destino = retorno.Vertices[carac[1]];
                        origem.Adjacentes.Add(destino.Id, destino);
                        var aresta = new Aresta(carac[0], carac[1]);
                        if (tamanho > 2) 
                            aresta.Peso = Convert.ToInt16(carac[2]);
                        retorno.Arestas.Add(aresta);
                    }
                }
            }

            return retorno;
        }

        public static Grafo GetTransposto(Grafo grafo)
        {
            var novaListaAresta = new List<Aresta>();
            foreach (var aresta in grafo.Arestas)
            {
                if (grafo.Vertices[aresta.Origem].Adjacentes.ContainsKey(aresta.Destino))
                    grafo.Vertices[aresta.Origem].Adjacentes.Remove(aresta.Destino);
                if (grafo.Vertices[aresta.Destino].Adjacentes.ContainsKey(aresta.Origem))
                    grafo.Vertices[aresta.Destino].Adjacentes.Remove(aresta.Origem);
                grafo.Vertices[aresta.Destino].Adjacentes.Add(aresta.Origem, grafo.Vertices[aresta.Origem]);

                novaListaAresta.Add(new Aresta(aresta.Destino, aresta.Origem));
            }
            grafo.Arestas = novaListaAresta;
            return grafo;
        }
    }
}
