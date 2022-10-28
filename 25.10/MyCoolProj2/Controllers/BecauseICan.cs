using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyCoolProj2.Interfaces;

namespace MyCoolProj2.Controllers
{
    [ApiController]
    [Route("App/[controller]")]
    public class BecauseICan : Controller
    {
        private readonly IPokemon _pokemon;
        private readonly IConfiguration _config;

        public BecauseICan(IConfiguration config, IPokemon pokemon)
        {
            _config = config;
            _pokemon = pokemon;
        }
        
        [HttpGet("getDatafile")]
        public string DataFileResult()
        {
            return _config.GetValue<string>("Datafile");
        }

        [HttpGet("getDataFilePokemon")]
        public IPokemon GetPokemon()
        {
            return _pokemon.GetPokemon();
        }

        [HttpGet("getFile")]
        public string ReadPokemonFile()
        {
            return _pokemon.ReadPokemon();
        }
    }
}