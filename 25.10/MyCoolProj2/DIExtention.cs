using Microsoft.Extensions.DependencyInjection;
using MyCoolProj2.Interfaces;
using MyCoolProj2.Pokemons;

namespace MyCoolProj2
{
    public static class DIExtention
    {
        public static void ConfigureServices(this IServiceCollection service)
        {
            service.AddScoped<IPokemon, Pokemon>();
        }
    }
}