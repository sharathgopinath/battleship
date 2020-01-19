using System.Collections.Generic;

namespace Domain.Entities
{
    public class ProgressState
    {
        public IEnumerable<string> Hits { get; set; }
        public IEnumerable<string> Misses { get; set; }
    }
}
