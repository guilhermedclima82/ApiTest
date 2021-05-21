using Integration.Classes;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Unit.Tests
{
    public class UserTest
    {
        private readonly UserClient _instance;

        public UserTest()
        {
            var httpClient = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
            _instance = new UserClient(httpClient);
        }

        [Fact]
        public async Task should_return_list_of_albums()
        {
            var result = await _instance.GetUsersAsync();
            Assert.True(result.Count > 0);
        }
    }
}
