using AzureMon.Api.Models;

namespace AzureMon.Api.Services.Repositories;

public class InMemoryPokemonRepository : IPokemonRepository
{        
    private readonly List<Pokemon> _pokemons = [];

    public Task<Pokemon> AddAsync(Pokemon pokemon)
    {
        pokemon.Id = Guid.NewGuid();
        _pokemons.Add(pokemon);
        return Task.FromResult(pokemon);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var existing = _pokemons.FirstOrDefault(p => p.Id == id);
        if (existing is null)
            return Task.FromResult(false);

        _pokemons.Remove(existing);
        return Task.FromResult(true);
    }

    public Task<IReadOnlyList<Pokemon>> GetAllAsync()
    {
        IReadOnlyList<Pokemon> snapshot = _pokemons.ToList();
        return Task.FromResult(snapshot);
    }

    public Task<int> CountAsync()
    {
        var count = _pokemons.Count;
        return Task.FromResult(count);
    }
}