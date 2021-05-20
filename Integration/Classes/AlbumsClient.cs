using Integration.Interfaces;
using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Integration.Classes
{
    public class AlbumsClient : IAlbumsClient
    {
        private HttpClient _client;

        public AlbumsClient(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<List<Album>> GetAlbumsAsync()
        {
            using (var httpClient = _client)
            {
                var response = await httpClient.GetAsync("photos");
                return JsonConvert.DeserializeObject<List<Album>>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}