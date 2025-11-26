using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEffectivenessApp.Core.Models
{
    public record Pokemon(string Name, List<PokemonType> Types);
}
