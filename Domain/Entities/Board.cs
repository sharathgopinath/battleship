using System.Collections.Generic;

namespace Domain.Entities
{
    public class Board
    {
        public int Size { get; set; }
        public IEnumerable<string> ShipCO { get; set; }
        public ProgressState ProgressState { get; set; }
    }
}
