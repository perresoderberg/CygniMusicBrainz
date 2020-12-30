using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cygni.MusicBrainz.Facade
{
    public class GenericHttpClientHandler : IGenericHttpClientHandler
    {
        protected readonly HttpClient HttpClient;
        public GenericHttpClientHandler()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/6.0;)");
        }
        public async Task<string> createHttpResponse(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");

                using (var httpResponse = await client.GetAsync(new Uri(url)))
                {
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                        throw new Cygni.MusicBrainz.Exceptions.NotFoundException($"404 - content not found from url {url}");

                    httpResponse.EnsureSuccessStatusCode();

                    var stringResponse = await httpResponse.Content.ReadAsStringAsync();

                    return stringResponse;
                }
            }

        }
    }

    public interface IGenericHttpClientHandler
    {
        Task<string> createHttpResponse(string url);


    }
}
