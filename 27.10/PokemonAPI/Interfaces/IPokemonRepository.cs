using PokemonAPI.Models;

namespace PokemonAPI.Interfaces;

public interface IPokemonRepository
{
    ICollection<Pokemon> GetPokemons();
    Pokemon GetPokemon(int Id);
    Pokemon GetPokemon(string Name);
    void CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);
    void UpdatePokemon(Pokemon pokemon);
    void DeletePokemon(Pokemon pokemon);

}