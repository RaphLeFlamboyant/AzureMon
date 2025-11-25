using AzureMon.Api.Data;
using AzureMon.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureMon.Api.Services.Repositories;

public class EfPokemonRepository(PokemonDbContext db) : IPokemonRepository
{
    public async Task<Pokemon> AddAsync(Pokemon pokemon)
    {
        pokemon.Id = Guid.NewGuid();

        db.Pokemons.Add(pokemon);
        await db.SaveChangesAsync();

        return pokemon;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await db.Pokemons.FindAsync(id);
        if (existing is null)
            return false;

        db.Pokemons.Remove(existing);
        await db.SaveChangesAsync();

        return true;
    }

    public async Task<IReadOnlyList<Pokemon>> GetAllAsync()
    {
        var list = await db.Pokemons
            .AsNoTracking()
            .ToListAsync();

        return list;
    }

    public async Task<int> CountAsync()
    {
        return await db.Pokemons.CountAsync();
    }
}