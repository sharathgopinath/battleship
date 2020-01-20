using System.Collections.Generic;

namespace Application.BattleShip
{
    public class ProgressState
    {
        public IEnumerable<string> Hits { get; set; }
        public IEnumerable<string> Misses { get; set; }

        public ProgressState()
        {
            Hits = new List<string>();
            Misses = new List<string>();
        }
    }
}
