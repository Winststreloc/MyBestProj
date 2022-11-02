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
    private readonly IMapper _mapper;
    private readonly IPokemonRepository _pokemonRepository;

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

        return Ok(pokemons);
    }

    [HttpGet("{pokemonId:int}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemon([FromRoute] int pokemonId)
    {
        if (!_pokemonRepository.PokemonExists(pokemonId))
        {
            return NotFound();
        }

        var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokemonId));

        return Ok(pokemon);
    }

    [HttpDelete("{pokemonId:int}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(200)]
    public IActionResult DeletePokemon([FromRoute] int pokemonId)
    {
        if (!_pokemonRepository.PokemonExists(pokemonId))
        {
            return NotFound();
        }

        var pokemonToDelete = _pokemonRepository.GetPokemon(pokemonId);

        _pokemonRepository.DeletePokemon(pokemonToDelete);
        return NoContent();
    }

    [HttpPost]
    public IActionResult CreatePokemon([FromRoute] int ownerId, [FromRoute] int categoryId,
        [FromBody] PokemonDto pokemonDto)
    {
        if (pokemonDto == null)
        {
            return BadRequest(pokemonDto);
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var pokemon = _mapper.Map<Pokemon>(pokemonDto);
        _pokemonRepository.CreatePokemon(ownerId, categoryId, pokemon);

        return Ok();
    }

    [HttpPut]
    public IActionResult UpdatePokemon([FromRoute] int pokemonId, [FromRoute] string pokemonName)
    {
        var pokemonCreate = new Pokemon
        {
            Id = pokemonId,
            Name = pokemonName
        };
        _pokemonRepository.UpdatePokemon(pokemonCreate);
        return Ok();
    }
}