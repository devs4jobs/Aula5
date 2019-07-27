using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula5
{
    class Program
    {
        public static List<BuscaCep> cepsBuscados = new List<BuscaCep>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Informe o cep");
                var cep = Console.ReadLine();

                if (cep.Length < 8)
                    Console.WriteLine("CEP inválido!");

                cepsBuscados.Add(httprequest.GetUrlAsync($"https://viacep.com.br/ws/{cep}/json/").Result);
                Console.WriteLine($"Total de ceps consultados/cadastrados: {cepsBuscados.Count}");

                Console.WriteLine("Digite 1 para exibir o primeiro registro \nDigite 2 para exibir o último registro");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": { Console.WriteLine(JsonConvert.SerializeObject(cepsBuscados.First())); break; }
                    case "2": { Console.WriteLine(JsonConvert.SerializeObject(cepsBuscados.Last())); break; }
                    default:
                        {
                            Console.WriteLine("Opção inválida!");
                            break;
                        }

                }
            }

        }
    }
}
