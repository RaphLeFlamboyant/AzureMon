using AzureMon.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureMon.Api.Data;

public class PokemonDbContext(DbContextOptions<PokemonDbContext> options)
    : DbContext(options)
{
    public DbSet<Pokemon> Pokemons => Set<Pokemon>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var pokemon = modelBuilder.Entity<Pokemon>();

        pokemon.ToTable("Pokemons");

        pokemon.HasKey(p => p.Id);

        pokemon.Property(p => p.Id)
            .ValueGeneratedNever(); // Guid géré côté appli

        pokemon.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        pokemon.Property(p => p.Species)
            .IsRequired()
            .HasMaxLength(100);

        pokemon.Property(p => p.Level)
            .IsRequired();

        pokemon.Property(p => p.Hp)
            .IsRequired();

        pokemon.Property(p => p.Attack)
            .IsRequired();

        pokemon.Property(p => p.Defense)
            .IsRequired();

        pokemon.Property(p => p.Move1)
            .IsRequired()
            .HasMaxLength(100);

        pokemon.Property(p => p.Move2)
            .HasMaxLength(100);
    }
}