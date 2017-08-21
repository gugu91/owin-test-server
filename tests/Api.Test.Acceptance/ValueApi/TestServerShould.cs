using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Asos.Customer.Recs.Http;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Api.Test.Acceptance.ValueApi
{
    [TestFixture]
    public class TestServerShould : InMemoryTest
    {
        private const string Expected = "Test server tested...";

        [TestCase(TestName = "Return correct body When I make a GET request to /testserver route")]
        public async Task Return_correct_body_When_I_make_a_request_to_TestServerController_Get()
        {
            var httpClient = 
                Substitute.For<IHttpClient>();
            httpClient.GetAsync(Arg.Any<string>())
                .Returns(GetMockedResponse());
            OvverideComponent(() => httpClient);

            var response = await HttpClient.GetAsync("/testserver");
            var body = await response.Content.ReadAsByteArrayAsync();
            var str = Encoding.UTF8.GetString(body);

            str.Should().Be(Expected);
        }

        private static Task<HttpResponseMessage> GetMockedResponse()
        {
            return Task.FromResult(
                new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ByteArrayContent(Encoding.UTF8.GetBytes(Expected))
                });
        }
    }
}
