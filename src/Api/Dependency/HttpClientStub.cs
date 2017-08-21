using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Asos.Customer.Recs.Http;

namespace Api.Dependency
{
    public class HttpClientStub : IHttpClient
    {
        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            var response = new HttpResponseMessage
            {
                Content = new StringContent("Test server running..."),
                StatusCode = HttpStatusCode.OK
            };

            return Task.FromResult(response);
        }

        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return GetAsync(new Uri(requestUri));
        }

        public Task<HttpResponseMessage> PutAsync(string requestUri, StringContent content)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PutAsync(Uri requestUri, StringContent content)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PostAsJsonAsync<T>(Uri requestUri, T value)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PostAsJsonAsync<T>(string requestUri, T value)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, StringContent content)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PostAsync(string requestUri, StringContent content)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage message)
        {
            throw new NotImplementedException();
        }

        public Uri BaseAddress { get; set; }
        public TimeSpan Timeout { get; set; }
        public HttpRequestHeaders DefaultRequestHeaders { get; }
    }
}