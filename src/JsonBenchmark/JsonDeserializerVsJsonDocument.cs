using BenchmarkDotNet.Attributes;

public class JsonDeserializerVsJsonDocument
{
    [GlobalSetup]
    public void Setuo()
    {
        
    }

    [Benchmark]
    public int JsonDeserializer() => 1;

    [Benchmark]
    public int JsonDocument() => 1;
}
