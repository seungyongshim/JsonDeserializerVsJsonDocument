using System.Text.Json;
using BenchmarkDotNet.Attributes;
using JsonBenchmark;
using JsonBenchmark.Properties;

[HtmlExporter]
public class JsonDeserializerVsJsonDocument
{
    public string JsonText { get; private set; }
    public NJsonSchema.JsonSchema NSchema { get; private set; }
    public Json.Schema.JsonSchema DtoSchema { get; private set; }
    public MemoryStream MemoryStream { get; private set; }

    [GlobalSetup]
    public void Setuo()
    {
        JsonText = Resources.Test;

        NSchema = NJsonSchema.JsonSchema.FromType<SendMailDto>();

        var jsonSchema = NJsonSchema.JsonSchema.FromType<SendMailDto>().ToJson();

        DtoSchema = Json.Schema.JsonSchema.FromText(jsonSchema);
    }

    [Benchmark]
    public SendMailDto RawText() => JsonSerializer.Deserialize<SendMailDto>(JsonText);

    [Benchmark]
    public SendMailDto RawTextValidate()
    {
        NSchema.Validate(JsonText);
        return JsonSerializer.Deserialize<SendMailDto>(JsonText);
    }


    [Benchmark]
    public SendMailDto JsonDocumenter()
    {
        var doc = JsonDocument.Parse(JsonText.AsMemory());

        return JsonSerializer.Deserialize<SendMailDto>(doc.RootElement);
    }

    [Benchmark]
    public SendMailDto JsonDocumenterValidate()
    {
        var doc = JsonDocument.Parse(JsonText.AsMemory());

        DtoSchema.Validate(doc.RootElement);

        return JsonSerializer.Deserialize<SendMailDto>(doc.RootElement);
    }



    [Benchmark]
    public SendMailDto JsonDocumenterRawText()
    {
        var doc = JsonDocument.Parse(JsonText.AsMemory());

        return JsonSerializer.Deserialize<SendMailDto>(doc.RootElement.GetRawText());
    }

    [Benchmark]
    public SendMailDto JsonDocumenterRawTextValidate()
    {
        var doc = JsonDocument.Parse(JsonText.AsMemory());

        DtoSchema.Validate(doc.RootElement);

        return JsonSerializer.Deserialize<SendMailDto>(doc.RootElement.GetRawText());
    }

    [Benchmark(Baseline = true)]
    public SendMailDto JsonDeserializer()
    {
        var dto = JsonSerializer.Deserialize<SendMailDto>(JsonText);
        var text = JsonSerializer.Serialize(dto);

        return JsonSerializer.Deserialize<SendMailDto>(text);
    }

    [Benchmark2]
    public SendMailDto JsonDeserializerValidate()
    {
        NSchema.Validate(JsonText);

        var dto = JsonSerializer.Deserialize<SendMailDto>(JsonText);
        var text = JsonSerializer.Serialize(dto);

        return JsonSerializer.Deserialize<SendMailDto>(text);
    }


}
