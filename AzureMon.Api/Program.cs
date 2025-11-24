using AzureMon.Api.Endpoints;
using AzureMon.Api.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repository in-memory
builder.Services.AddSingleton<IPokemonRepository, InMemoryPokemonRepository>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoint minimal pour vérifier que l’API tourne
app.MapGet("/", () => Results.Ok("AzureMon API is running"));

app.MapPokemonEndpoints();
app.MapStatsEndpoints();

app.Run();
