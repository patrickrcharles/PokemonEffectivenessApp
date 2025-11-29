using PokemonEffectivenessApp.Models;

namespace PokemonEffectivenessApp.Services;

public interface IPokemonTypeEffectivenessService
{
    void ApplyTypeRelations(TypesDto typeDto, CombinedEffectivenessDTO combined);
}

