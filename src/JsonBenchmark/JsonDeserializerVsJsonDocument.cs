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
    public SendMailDto JsonDeserializer() => JsonSerializer.Deserialize<SendMailDto>(JsonText);

    [Benchmark]
    public SendMailDto JsonDocument() => JsonSerializer.Deserialize<SendMailDto>(JsonText);
}
