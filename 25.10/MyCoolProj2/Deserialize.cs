#nullable enable
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MyCoolProj2.Pokemons;
using Newtonsoft.Json;

namespace MyCoolProj2
{
    public class Deserialize
    {
        private static readonly IConfiguration _config;

        public static Pokemon DeserializeFile()
        {
            string path = _config.GetValue<string>("FilePath");
            FileStream fileStream = File.Open(path, FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fileStream);
            Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(streamReader.ReadToEnd());
            return pokemon;
        }

        public static string ReadFile()
        {
            FileStream fs = new FileStream(_config.GetValue<string>("FilePath"), FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fs);

            return streamReader.ReadToEnd();

        }
    }
}