using PokemonEffectivenessApp.Models;

namespace PokemonEffectivenessApp.ApiClients
{
    public interface IPokeApiClient
    {
        Task<PokemonDto?> GetPokemonAsync(string name);
        Task<TypesDto?> GetTypeByUrlAsync(string url);
    }

}
