﻿using PokemonAPI.Data;
using PokemonAPI.Models;

namespace PokemonAPI;

public class Seed
{
    private readonly DbContext _dbContext;

    public Seed(DbContext context)
    {
        _dbContext = context;
    }

    public void SeedDataContext()
    {
        if (!_dbContext.PokemonOwners.Any())
        {
            var pokemonOwners = new List<PokemonOwner>
            {
                new()
                {
                    Pokemon = new Pokemon
                    {
                        Name = "Pikachu",
                        BirthDate = new DateTime(1903, 1, 1),
                        PokemonCategories = new List<PokemonCategory>
                        {
                            new() { Category = new Category { Name = "Electric" } }
                        },
                        Reviews = new List<Review>
                        {
                            new()
                            {
                                Title = "Pikachu", Text = "Pickahu is the best pokemon, because it is electric",
                                Rating = 5,
                                Reviewer = new Reviewer { FirstName = "Teddy", LastName = "Smith" }
                            },
                            new()
                            {
                                Title = "Pikachu", Text = "Pickachu is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer { FirstName = "Taylor", LastName = "Jones" }
                            },
                            new()
                            {
                                Title = "Pikachu", Text = "Pickchu, pickachu, pikachu", Rating = 1,
                                Reviewer = new Reviewer { FirstName = "Jessica", LastName = "McGregor" }
                            }
                        }
                    },
                    Owner = new Owner
                    {
                        FirstName = "Jack",
                        LastName = "London",
                        Gym = "Brocks Gym",
                        Country = new Country
                        {
                            Name = "Kanto"
                        }
                    }
                },
                new()
                {
                    Pokemon = new Pokemon
                    {
                        Name = "Squirtle",
                        BirthDate = new DateTime(1903, 1, 1),
                        PokemonCategories = new List<PokemonCategory>
                        {
                            new() { Category = new Category { Name = "Water" } }
                        },
                        Reviews = new List<Review>
                        {
                            new()
                            {
                                Title = "Squirtle", Text = "squirtle is the best pokemon, because it is electric",
                                Rating = 5,
                                Reviewer = new Reviewer { FirstName = "Teddy", LastName = "Smith" }
                            },
                            new()
                            {
                                Title = "Squirtle", Text = "Squirtle is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer { FirstName = "Taylor", LastName = "Jones" }
                            },
                            new()
                            {
                                Title = "Squirtle", Text = "squirtle, squirtle, squirtle", Rating = 1,
                                Reviewer = new Reviewer { FirstName = "Jessica", LastName = "McGregor" }
                            }
                        }
                    },
                    Owner = new Owner
                    {
                        FirstName = "Harry",
                        LastName = "Potter",
                        Gym = "Mistys Gym",
                        Country = new Country
                        {
                            Name = "Saffron City"
                        }
                    }
                },
                new()
                {
                    Pokemon = new Pokemon
                    {
                        Name = "Venasuar",
                        BirthDate = new DateTime(1903, 1, 1),
                        PokemonCategories = new List<PokemonCategory>
                        {
                            new() { Category = new Category { Name = "Leaf" } }
                        },
                        Reviews = new List<Review>
                        {
                            new()
                            {
                                Title = "Veasaur", Text = "Venasuar is the best pokemon, because it is electric",
                                Rating = 5,
                                Reviewer = new Reviewer { FirstName = "Teddy", LastName = "Smith" }
                            },
                            new()
                            {
                                Title = "Veasaur", Text = "Venasuar is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer { FirstName = "Taylor", LastName = "Jones" }
                            },
                            new()
                            {
                                Title = "Veasaur", Text = "Venasuar, Venasuar, Venasuar", Rating = 1,
                                Reviewer = new Reviewer { FirstName = "Jessica", LastName = "McGregor" }
                            }
                        }
                    },
                    Owner = new Owner
                    {
                        FirstName = "Ash",
                        LastName = "Ketchum",
                        Gym = "Ashs Gym",
                        Country = new Country
                        {
                            Name = "Millet Town"
                        }
                    }
                }
            };
            _dbContext.PokemonOwners.AddRange(pokemonOwners);
            _dbContext.SaveChanges();
        }
    }
}