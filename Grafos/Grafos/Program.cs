using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                VerificarParametros(args);
                var nomeAlgoritmo = args[0];
                var arquivoEntrada = args[1];

                var algoritmo = new Factory(nomeAlgoritmo);
                var resultado = algoritmo.Executar(arquivoEntrada);

                foreach (var item in resultado)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void VerificarParametros(string[] args)
        {
            if (!args.Any())
                throw new Exception("Imforme os parametros para execucao do algoritmo.");

            if (String.IsNullOrEmpty(args[1]))
                throw new Exception("Imforme o arquivo de entrada para o algoritmo.");
        }
    }
}
