namespace AzureMon.Api.Models;

public static class PokemonValidator
{
    public static (bool IsValid, List<string> Errors) Validate(Pokemon pokemon)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(pokemon.Name))
            errors.Add("Name is required.");

        if (string.IsNullOrWhiteSpace(pokemon.Species))
            errors.Add("Species is required.");

        if (pokemon.Level <= 0)
            errors.Add("Level must be greater than 0.");

        if (pokemon.Hp <= 0)
            errors.Add("Hp must be greater than 0.");

        if (pokemon.Attack <= 0)
            errors.Add("Attack must be greater than 0.");

        if (pokemon.Defense <= 0)
            errors.Add("Defense must be greater than 0.");

        if (string.IsNullOrWhiteSpace(pokemon.Move1))
            errors.Add("Move1 is required.");

        if (string.IsNullOrWhiteSpace(pokemon.Move2))
            errors.Add("Move2 is required.");

        return (errors.Count == 0, errors);
    }
}