using PokemonEffectivenessApp.Models;

namespace PokemonEffectivenessApp.Services;

public class TypeEffectivenessService : ITypeEffectivenessService
{
    public void ApplyTypeRelations(TypeDto typeDto, CombinedEffectivenessDTO combined)
    {
        ArgumentNullException.ThrowIfNull(typeDto);
        ArgumentNullException.ThrowIfNull(combined);

        // Define sources for strong and weak relations
        var strong = new[]
        {
        typeDto.DamageRelations.DoubleDamageTo,
        typeDto.DamageRelations.HalfDamageFrom,
        typeDto.DamageRelations.NoDamageFrom
        };

        var weak = new[]
        {
        typeDto.DamageRelations.DoubleDamageFrom,
        typeDto.DamageRelations.HalfDamageTo,
        typeDto.DamageRelations.NoDamageTo
        };

        // Strong Against: add only if not already Weak
        foreach (var list in strong)
        {
            foreach (var t in list)
            {
                if (!string.IsNullOrWhiteSpace(t.Name) && !combined.WeakAgainst.Contains(t.Name))
                    combined.StrongAgainst.Add(t.Name);
            }
        }

        // Weak Against: add only if not already Strong
        foreach (var list in weak)
        {
            foreach (var t in list)
            {
                if (!string.IsNullOrWhiteSpace(t.Name) && !combined.StrongAgainst.Contains(t.Name))
                    combined.WeakAgainst.Add(t.Name);
            }
        }
    }
}

