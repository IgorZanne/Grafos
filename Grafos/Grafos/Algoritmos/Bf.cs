﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafos.Estruturas;

namespace Grafos.Algoritmos
{
    public class Bf : Algoritmo
    {
        private void initialize(Grafo grafo)
        {
            foreach(var vertice in grafo.Vertices)
            {
                vertice.Descoberta = Int32.MaxValue;
                vertice.Pai = null;
            }
        }

        private void relax(Vertice u, Vertice v, int w)
        {
            if (v.Descoberta > (u.Descoberta+w))
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
                var saida = ver.Descoberta.ToString();
                while (ver.Pai != null)
                {
                    saida = ver.Pai.Id + " " + saida;
                }

                if (saida.StartsWith(grafo.Vertices.First().Id))
                    retorno.Add(saida);
            }

            return retorno;
        }
    }
}
