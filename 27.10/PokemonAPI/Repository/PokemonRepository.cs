using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly PokemonDbContext _context;

    public PokemonRepository(PokemonDbContext context)
    {
        _context = context;
    }
    public async Task<ICollection<Pokemon>> GetPokemons()
    {
        return await _context.Pokemon.OrderBy(p => p.Id).ToListAsync();
    }

    public async Task<Pokemon> GetPokemon(int Id)
    {
        return await _context.Pokemon.Where(p => p.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<bool> PokemonExists(int pokemonId)
    {
        return await _context.Pokemon.AnyAsync(p => p.Id == pokemonId);
    }

    public void DeletePokemon(Pokemon pokemon)
    {
        _context.Remove(pokemon);
        Save();
    }

    public async Task CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
    {
        Owner pokemonOwnerEntity = await _context.Owners.Where(a => a.Id == ownerId).FirstOrDefaultAsync();
        Category category = await _context.Categories.Where(a => a.Id == categoryId).FirstOrDefaultAsync();

        var pokemonOwner = new PokemonOwner
        {
            Owner = pokemonOwnerEntity,
            Pokemon = pokemon
        };

        await _context.AddAsync(pokemonOwner);

        var pokemonCategory = new PokemonCategory
        {
            Category = category,
            Pokemon = pokemon
        };

        await _context.AddAsync(pokemonCategory);

        await _context.AddAsync(pokemon);
        Save();
    }

    public void UpdatePokemon(Pokemon pokemon)
    {
        _context.Update(pokemon);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}