using PokemonEffectivenessApp.Models;

namespace PokemonEffectivenessApp.ApiClients
{
    public interface IPokeApiClient
    {
        Task<PokemonDto?> GetPokemonAsync(string name);
        Task<TypeDto?> GetTypeByUrlAsync(string url);
    }

}
