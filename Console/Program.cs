using Microsoft.Extensions.DependencyInjection;
using PokemonEffectivenessApp.ApiClients;
using PokemonEffectivenessApp.Models;
using PokemonEffectivenessApp.Services;

internal static class Program
{
    private static async Task Main(string[] args)
    {

        var services = new ServiceCollection();
        services.AddSingleton<HttpClient>();
        services.AddSingleton<IPokeApiClient, PokeApiClient>();
        services.AddSingleton<ITypeEffectivenessService, TypeEffectivenessService>();

        using var serviceProvider = services.BuildServiceProvider();
        var apiClient = serviceProvider.GetRequiredService<IPokeApiClient>();
        var effectivenessService = serviceProvider.GetRequiredService<ITypeEffectivenessService>();

        while (true)
        {
            try
            {
                Console.Write("\nEnter Pokémon name: ");
                var input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid Pokémon name.");
                    continue;
                }
                if (input.Equals("exit"))
                {
                    Console.WriteLine("goodbye...");
                    break;
                }

                var pokemon = await apiClient.GetPokemonAsync(input.ToLower());
                if (pokemon == null || pokemon.Types.Count == 0)
                {
                    Console.WriteLine($"Pokémon '{input}' not found or has no types.");
                    continue;
                }

                var combined = new CombinedEffectivenessDTO
                {
                    Name = pokemon.Name,
                    Types = pokemon.Types.Select(t => t.Type.Name)
                };

                // Fetch all type DTOs concurrently
                var typeDtos = await Task.WhenAll(
                    pokemon.Types.Select(t => apiClient.GetTypeByUrlAsync(t.Type.Url))
                );

                // Apply type relations for each successfully fetched type
                foreach (var typeDto in typeDtos.Where(t => t != null))
                {
                    effectivenessService.ApplyTypeRelations(typeDto!, combined);
                }


                DisplayEffectiveness(combined);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Network error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }

    private static void DisplayEffectiveness(CombinedEffectivenessDTO combined)
    {
        Console.WriteLine($"\n{combined.Name} : {string.Join(", ", combined.Types)}");
        Console.WriteLine($"Strong Against: {(combined.StrongAgainst.Any() ? string.Join(", ", combined.StrongAgainst) : "None")}");
        Console.WriteLine($"Weak Against: {(combined.WeakAgainst.Any() ? string.Join(", ", combined.WeakAgainst) : "None")}");
    }
}
