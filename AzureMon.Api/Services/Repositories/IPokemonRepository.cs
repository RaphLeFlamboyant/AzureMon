using AzureMon.Api.Models;

namespace AzureMon.Api.Services.Repositories;

public interface IPokemonRepository
{
    Task<Pokemon> AddAsync(Pokemon pokemon);
    Task<bool> DeleteAsync(Guid id);
    Task<IReadOnlyList<Pokemon>> GetAllAsync();
    Task<int> CountAsync();
}