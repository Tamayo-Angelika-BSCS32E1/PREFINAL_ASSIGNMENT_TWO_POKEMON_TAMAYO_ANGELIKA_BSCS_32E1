using System.Collections.Generic;

namespace PokemonApp.Models
{
    public class Pokemon
    {
        public string Name { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<Move> Moves { get; set; }
    }

    public class Ability
    {
        public AbilityDetail AbilityDetail { get; set; }  // Renamed property
    }

    public class AbilityDetail
    {
        public string Name { get; set; }
    }

    public class Move
    {
        public MoveDetail MoveDetail { get; set; }  // Renamed property
    }

    public class MoveDetail
    {
        public string Name { get; set; }
    }
}
