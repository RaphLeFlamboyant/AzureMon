using AzureMon.Api.Models;
using AzureMon.Api.Services.Repositories;

namespace AzureMon.Api.Endpoints;

/// <summary>
/// Simple separation between program.cs and endpoint definition.
/// Contains the endpoint logic because we didn't used any kind of clean archi here
/// </summary>
public static class PokemonEndpoints
{
    public static IEndpointRouteBuilder MapPokemonEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/pokemon");

        group.MapPost("/", async (Pokemon pokemon, IPokemonRepository repository) =>
        {
            var (isValid, errors) = PokemonValidator.Validate(pokemon);
            if (!isValid)
            {
                return Results.BadRequest(new { errors });
            }

            var created = await repository.AddAsync(pokemon);
            return Results.Created($"/pokemon/{created.Id}", created);
        });

        group.MapDelete("/{id:guid}", async (Guid id, IPokemonRepository repository) =>
        {
            var deleted = await repository.DeleteAsync(id);

            return deleted
                ? Results.NoContent()
                : Results.NotFound();
        });

        group.MapGet("/", async (IPokemonRepository repository) =>
        {
            var pokemons = await repository.GetAllAsync();
            return Results.Ok(pokemons);
        });

        return app;
    }

    public static IEndpointRouteBuilder MapStatsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/stats", async (IPokemonRepository repository) =>
        {
            var count = await repository.CountAsync();
            return Results.Ok(new { total = count });
        });

        return app;
    }
}