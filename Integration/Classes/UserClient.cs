using Integration.Interfaces;
using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Integration.Classes
{
    public class UserClient : IUserClient
    {
        private HttpClient _client;

        public UserClient(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var response = await _client.GetAsync("users");
            return JsonConvert.DeserializeObject<List<User>>(await response.Content.ReadAsStringAsync());
        }
    }
}