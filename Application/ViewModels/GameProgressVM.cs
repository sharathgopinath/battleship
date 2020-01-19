using System.Collections.Generic;

namespace Application.ViewModels
{
    public class GameProgressVM
    {
        public string ShipCO { get; set; }
        public IList<string> Hits { get; set; }
        public IList<string> Misses { get; set; }
    }
}
