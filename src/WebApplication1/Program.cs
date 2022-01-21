using System.Text.Json;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(NJsonSchema.JsonSchema.FromType<SendMailDto>());
builder.Services.AddSingleton(sp => Json.Schema.JsonSchema.FromText(sp.GetService<NJsonSchema.JsonSchema>().ToJson()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapPost("/SendMail", (SendMailDto req) =>
{
    var text = JsonSerializer.Serialize(req);

    return Results.Ok(text);
});

app.MapPost("/SendMailDocument", (JsonDocument req) =>
{
    var text = JsonSerializer.Serialize(req.RootElement);

    return Results.Ok(text);
}).Accepts<SendMailDto>("application/json");


app.MapPost("/SendMailStream", async (HttpRequest req) =>
{
    using var sr = new StreamReader(req.Body);
    var text = await sr.ReadToEndAsync();

    return Results.Ok(text);
}).Accepts<SendMailDto>("application/json");

app.Run();