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
                    retorno.Vertices.Add(new Vertice(linha));
                else
                {
                    var carac = linha.Split(' ');
                    var tamanho = carac.Length;
                    if (tamanho <= 0 || tamanho > 3)
                        throw new Exception("Não foi possível identificar especificações da aresta no arquivo de entrada");

                    if (tamanho == 2)
                        retorno.Arestas.Add(new Aresta(new Vertice(carac[0]), new Vertice(carac[1])));

                    if (tamanho == 3)
                        retorno.Arestas.Add(new Aresta(new Vertice(carac[0]), new Vertice(carac[1]), Convert.ToInt16(carac[2])));
                }
            }

            return retorno;
        }
    }
}
