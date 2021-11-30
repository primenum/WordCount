using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WordCount.Infrastructure.Service.Rest
{
    internal class RestImplementation : IRest
    {
        private readonly HttpClient _client;

        public RestImplementation()
        {
            _client = new HttpClient();
    }

        public async Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            var response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}
