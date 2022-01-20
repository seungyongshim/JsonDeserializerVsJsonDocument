using System.Text.Json;
using BenchmarkDotNet.Attributes;
using JsonBenchmark;
using JsonBenchmark.Properties;

[HtmlExporter]
public class JsonDeserializerVsJsonDocument
{
    public string JsonText { get; private set; }
    public MemoryStream MemoryStream { get; private set; }

    [GlobalSetup]
    public void Setuo()
    {
        JsonText = Resources.Test;
    }

    [Benchmark]
    public SendMailDto RawText()
    {
        return JsonSerializer.Deserialize<SendMailDto>(JsonText);
    }


    [Benchmark]
    public SendMailDto JsonDocumenter()
    {
        var doc = JsonDocument.Parse(JsonText.AsMemory());

        return JsonSerializer.Deserialize<SendMailDto>(doc.RootElement.GetRawText());
    }

    [Benchmark(Baseline = true)]
    public SendMailDto JsonDeserializer()
    {
        var dto = JsonSerializer.Deserialize<SendMailDto>(JsonText);
        var text = JsonSerializer.Serialize(dto with { From = new MailAddress("1", "111@111.111")});

        return JsonSerializer.Deserialize<SendMailDto>(text);
    }

   
}
