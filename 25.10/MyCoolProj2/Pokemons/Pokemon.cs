using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using MyCoolProj2.Interfaces;

namespace MyCoolProj2.Pokemons
{
    public class Pokemon : IPokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        private readonly IConfiguration _config;

        public Pokemon()
        {
            Id = 0;
            Name = "Pikachu";
            BirthDate = DateTime.Now;
        }

        public Pokemon(int id, string name, DateTime birthDate)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
        }

        public Pokemon GetPokemon()
        {
            return new Pokemon();
        }

        public string ReadPokemon()
        {
            FileStream fs = new FileStream(_config.GetValue<string>("Datafile"), FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fs);

            return streamReader.ReadToEnd();
        }
    }
    
}