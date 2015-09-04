using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos.Estruturas
{
    public class Aresta
    {
        public Aresta(string origem, string destino)
        {
            this.Origem = origem;
            this.Destino = destino;
            this.Peso = 0;
        }

        public Aresta(string origem, string destino, int peso)
        {
            this.Origem = origem;
            this.Destino = destino;
            this.Peso = peso;
        }

        public int Peso { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
    }
}
