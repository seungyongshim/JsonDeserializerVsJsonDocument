using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Flurl.Http;
using Flurl;
using WebApplication1.Tests.Properties;

namespace WebApplication1.Tests
{
    public class WebApplication1Factory : WebApplicationFactory<Program>
    {

    }
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var x = new WebApplication1Factory();
            var client = x.CreateClient();

            //var request = new HttpRequestMessage();
            //request.Headers.Add("content-type", "application/json");

            var cli = new FlurlClient(client);

            var ret = await cli.Request("/SendMailStream")
                               .WithHeader("content-type", "application/json; charset=utf-8")
                               .PostStringAsync(Resources.Test);
        }
    }
}
