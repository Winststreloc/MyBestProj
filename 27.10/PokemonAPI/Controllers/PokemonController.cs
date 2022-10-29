using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : Controller
{
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonController(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    public IActionResult GetPokemons()
    {
        var pokemons = _pokemonRepository.GetPokemons();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(pokemons);
    }

    [HttpGet("{pokemonId}")]
    public IActionResult GetPokemon(int pokemonId)
    {
        var pokemon = _pokemonRepository.GetPokemon(pokemonId);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(pokemon);
    }

    [HttpDelete("{pokemonId}")]
    public IActionResult DeletePokemon(int pokemonId)
    {
        var pokemonToDelete = _pokemonRepository.GetPokemon(pokemonId);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _pokemonRepository.DeletePokemon(pokemonToDelete);
        return NoContent();
    }

    [HttpPost]
    public IActionResult CreatePokemon([FromQuery] int ownerId,[FromQuery] int categoryId,
        [FromQuery] int pokemonId,[FromQuery] string pokemonName)
    {
        var pokemonCreate = new Pokemon()
        {
            Id = pokemonId,
            Name = pokemonName,
        };
        
        if (pokemonCreate == null)
        {
            return BadRequest(ModelState);
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _pokemonRepository.CreatePokemon(ownerId, categoryId, pokemonCreate);

        return Ok();
    }

    [HttpPut]
    public IApplicationBuilder UpdatePokemon([FromQuery] int ownerId,[FromQuery] int categoryId,
        [FromQuery] int pokemonId,[FromQuery] string pokemonName)
    {
        var pokemonCreate = new Pokemon()
        {
            Id = pokemonId,
            Name = pokemonName,
        };
    }
}