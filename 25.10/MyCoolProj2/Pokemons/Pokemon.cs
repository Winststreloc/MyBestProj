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
            return Deserialize.DeserializeFile();
        }

        public string ReadPokemon()
        {
            return Deserialize.ReadFile();
        }
    }
    
}