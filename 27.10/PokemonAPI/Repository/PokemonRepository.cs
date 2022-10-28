using PokemonAPI.Data;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly DataContext _context;

    public PokemonRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<Pokemon> GetPokemons()
    {
        return _context.Pokemon.OrderBy(p => p.Id).ToList();
    } 

    public Pokemon GetPokemon(int Id)
    {
        return _context.Pokemon.Where(p => p.Id == Id).FirstOrDefault();
    }

    public Pokemon GetPokemon(string Name)
    {
        return _context.Pokemon.Where(p => p.Name == Name).FirstOrDefault();
    }

    public void DeletePokemon(Pokemon pokemon)
    {
        _context.Remove(pokemon);
    }

    public void CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
    {
        var pokemonOwnerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
        var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

        var pokemonOwner = new PokemonOwner()
        {
            Owner = pokemonOwnerEntity,
            Pokemon = pokemon,
        };

        _context.Add(pokemonOwner);
            
        var pokemonCategory = new PokemonCategory()
        {
            Category = category,
            Pokemon = pokemon,
        };

        _context.Add(pokemonCategory);

        _context.Add(pokemon);
    }

    public void UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
    {
        throw new NotImplementedException();
    }
}