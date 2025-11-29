using PokemonEffectivenessApp.Models;

namespace PokemonEffectivenessApp.ApiClient
{
    public interface IPokeApiClient
    {
        Task<PokemonDto?> GetPokemonAsync(string name);
        Task<TypesDto?> GetTypeByUrlAsync(string url);
    }

}
