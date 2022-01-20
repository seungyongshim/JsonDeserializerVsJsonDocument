using System.Text.Json;
using BenchmarkDotNet.Attributes;
using JsonBenchmark;
using JsonBenchmark.Properties;

public class JsonDeserializerVsJsonDocument
{
    public string JsonText { get; private set; }

    [GlobalSetup]
    public void Setuo()
    {
        JsonText = Resources.Test;
    }

    [Benchmark]
    public SendMailDto JsonDeserializer()
    {
        var dto = JsonSerializer.Deserialize<SendMailDto>(JsonText);
        var text = JsonSerializer.Serialize(dto);

        return JsonSerializer.Deserialize<SendMailDto>(text);
    }

    [Benchmark]
    public SendMailDto JsonDocumenter()
    {
        var doc = JsonDocument.Parse(JsonText);

        return JsonSerializer.Deserialize<SendMailDto>(doc.RootElement.GetRawText());
    }
}
