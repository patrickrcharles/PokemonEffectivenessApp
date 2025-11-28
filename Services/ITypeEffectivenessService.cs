using PokemonEffectivenessApp.Models;

namespace PokemonEffectivenessApp.Services;

public interface ITypeEffectivenessService
{
    void ApplyTypeRelations(TypeDto typeDto, CombinedEffectivenessDTO combined);
}

