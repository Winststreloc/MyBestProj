using PokemonAPI.Models;

namespace PokemonAPI.Interfaces;

public interface IPokemonRepository
{
    Task<ICollection<Pokemon>> GetPokemons();
    Task<Pokemon> GetPokemon(int Id);
    Task<bool> PokemonExists(int Id);
    Task CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);
    void UpdatePokemon(Pokemon pokemon);
    void DeletePokemon(Pokemon pokemon);
    void Save();
}