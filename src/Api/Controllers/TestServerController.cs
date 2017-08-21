using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Asos.Customer.Recs.Http;

namespace Api.Controllers
{
    public class TestServerController : ApiController
    {
        private readonly IHttpClient _dependency;

        public TestServerController(IHttpClient dependency)
        {
            _dependency = dependency;
        }

        public async Task<string> Get()
        {
            var response = await _dependency.GetAsync("http://www.any.com");

            return await response.Content.ReadAsStringAsync();
        }

    }
}