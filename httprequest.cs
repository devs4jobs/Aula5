using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aula5
{
    public static class httprequest
    {
        public static async Task<BuscaCep> GetUrlAsync(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            if ((int)response.StatusCode != 200)
                Console.WriteLine("CEP inválido");

            var resultado = await response.Content.ReadAsStringAsync();
            Console.WriteLine(resultado);

            return JsonConvert.DeserializeObject<BuscaCep>(resultado);

        }
    }
}
