using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEffectivenessApp.Core.Models
{
    public record TypeRelations(
        List<string> DoubleDamageTo,
        List<string> HalfDamageTo,
        List<string> NoDamageTo,
        List<string> DoubleDamageFrom,
        List<string> HalfDamageFrom,
        List<string> NoDamageFrom
    );

}
