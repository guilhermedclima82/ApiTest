using Integration.Classes;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Unit.Tests
{
    public class PhotoTest
    {
        private readonly PhotoClient _instance;

        public PhotoTest()
        {
            var httpClient = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
            _instance = new PhotoClient(httpClient);
        }

        [Fact]
        public async Task should_return_list_of_albums()
        {
            var result = await _instance.GetPhotosAsync();
            Assert.True(result.Count > 0);
        }
    }
}
