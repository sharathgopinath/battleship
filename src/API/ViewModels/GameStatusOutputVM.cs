using System.Collections.Generic;

namespace API.ViewModels
{
    public class GameStatusVM
    {
        public IList<string> Hits { get; set; }
        public IList<string> Misses { get; set; }
    }
}
