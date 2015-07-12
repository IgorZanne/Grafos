using Grafos.Algoritmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class Factory
    {
        private readonly Algoritmo algoritmo;

        public Factory(string nome)
        {
            switch (nome.ToUpper())
            {
                case "BF":    algoritmo = new Bf();    break;
                case "BFALL": algoritmo = new Bfall(); break;
                case "BFS":   algoritmo = new Bfs();   break;
                case "DK":    algoritmo = new Dk();    break;
                case "DKALL": algoritmo = new Dkall(); break;
                case "MST":   algoritmo = new Mst();   break;
                case "SCC":   algoritmo = new Scc();   break;
                default:
                    throw new Exception(String.Format("Algoritmo '{0}' não identificado", nome.ToUpper()));
            }
        }

        public String Executar()
        {
            var result = algoritmo.Executar();
            return result;
        }
    }
}
