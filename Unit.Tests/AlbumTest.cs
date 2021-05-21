using Integration.Classes;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Unit.Tests
{
    public class AlbumsTest
    {
        private readonly AlbumsClient _instance;

        public AlbumsTest()
        {
            var httpClient = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
            _instance = new AlbumsClient(httpClient);
        }

        [Fact]
        public async Task should_return_list_of_albums()
        {
            var result = await _instance.GetAlbumsAsync();
            Assert.True(result.Count > 0);
        }
    }
}
