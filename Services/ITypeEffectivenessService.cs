using PokemonEffectivenessApp.Models;

namespace PokemonEffectivenessApp.Services;

public interface ITypeEffectivenessService
{
    void ApplyTypeRelations(TypesDto typeDto, CombinedEffectivenessDTO combined);
}

