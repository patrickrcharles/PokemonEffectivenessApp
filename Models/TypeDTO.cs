using System.Text.Json.Serialization;

namespace PokemonEffectivenessApp.Models
{
    public class TypeDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("damage_relations")]
        public TypeRelationsDto DamageRelations { get; init; } = new();
    }

}
