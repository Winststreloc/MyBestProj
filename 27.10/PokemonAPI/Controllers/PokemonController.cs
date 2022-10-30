using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Dto;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : ControllerBase
{
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IMapper _mapper;

    public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
    {
        _pokemonRepository = pokemonRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemons()
    {
        var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(pokemons);
    }

    [HttpGet("{pokemonId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemon(int pokemonId)
    {
        if (!_pokemonRepository.PokemonExists(pokemonId))
        {
            return NotFound();
        }
        
        var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokemonId));
        
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

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _pokemonRepository.CreatePokemon(ownerId, categoryId, pokemonCreate);

        return Ok();
    }

    [HttpPut]
    public IActionResult UpdatePokemon([FromQuery] int pokemonId,[FromQuery] string pokemonName)
    {
        var pokemonCreate = new Pokemon()
        {
            Id = pokemonId,
            Name = pokemonName,
        };
        _pokemonRepository.UpdatePokemon(pokemonCreate);
        return Ok();
    }
}