using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WordCount.Infrastructure.Service.Rest
{
    public interface IRest
    {

        Task<HttpResponseMessage> GetAsync(Uri uri);
    }
}