using AzureMon.Api.Data;
using AzureMon.Api.Endpoints;
using AzureMon.Api.Services.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repository in-memory
builder.Services.AddSingleton<IPokemonRepository, InMemoryPokemonRepository>();

var connectionString = builder.Configuration.GetConnectionString("PokemonDb")
                       ?? throw new InvalidOperationException(
                           "Connection string 'PokemonDb' not found. " +
                           "Configure it via user-secrets en local ou Connection Strings dans Azure."
                       );

builder.Services.AddDbContext<PokemonDbContext>(options =>
    options.UseSqlServer(connectionString));

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
