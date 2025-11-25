using AzureMon.Api.Data;
using AzureMon.Api.Endpoints;
using AzureMon.Api.Services.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPokemonRepository, EfPokemonRepository>();

var connectionString = builder.Configuration.GetConnectionString("PokemonDb")
                       ?? throw new InvalidOperationException(
                           "Connection string 'PokemonDb' not found. " +
                           "Configure it via user-secrets en local ou Connection Strings dans Azure."
                       );

builder.Services.AddDbContext<PokemonDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Endpoints
app.MapGet("/", () => Results.Ok("AzureMon API is running - v1"));
app.MapPokemonEndpoints();
app.MapStatsEndpoints();

app.Run();
