using Integration.Interfaces;
using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Integration.Classes
{
    public class PhotoClient : IPhotosClient
    {
        private HttpClient _client;

        public PhotoClient(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<List<Photo>> GetPhotosAsync()
        {

            var response = await _client.GetAsync("photos");
            return JsonConvert.DeserializeObject<List<Photo>>(await response.Content.ReadAsStringAsync());
        }
    }
}