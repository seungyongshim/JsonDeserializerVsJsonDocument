using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Flurl.Http;
using JsonBenchmark.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;

public class WebApplication1Factory : WebApplicationFactory<WebApplication1.Program>
{
}

[HtmlExporter]
public class JsonDeserializerVsJsonDocument
{
    public string JsonText { get; private set; }
    public HttpClient TestClient { get; private set; }

    [GlobalSetup]
    public void Setuo()
    {
        JsonText = Resources.Test;

        TestClient = new WebApplication1Factory().CreateClient();
    }

    [Benchmark(Baseline = true)]
    public async Task<HttpResponseMessage> SystemTextJsonDeserializer()
    {
        var cli = new FlurlClient(TestClient);

        var ret = await cli.Request("/SendMail")
                           .WithHeader("content-type", "application/json; charset=utf-8")
                           .PostStringAsync(Resources.Test);

        return ret.ResponseMessage;
    }

    [Benchmark()]
    public async Task<HttpResponseMessage> JsonDocumentNonDeserializer()
    {
        var cli = new FlurlClient(TestClient);

        var ret = await cli.Request("/SendMailDocument")
                           .WithHeader("content-type", "application/json; charset=utf-8")
                           .PostStringAsync(Resources.Test);

        return ret.ResponseMessage;
    }
}
