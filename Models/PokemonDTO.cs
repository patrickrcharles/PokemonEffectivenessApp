using System.Text.Json.Serialization;

namespace PokemonEffectivenessApp.Models
{
    public class PokemonDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("types")]
        public List<PokemonTypeInfo> Types { get; init; } = new();
    }

    public class PokemonTypeInfo
    {
        [JsonPropertyName("type")]
        public PokemonType Type { get; init; } = new();
    }

    public class PokemonType
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }

}
