﻿using System.Collections.Generic;

namespace API.ViewModels
{
    public class AttackOutputVM
    {
        public string GameProgressCode { get; set; }
        public IList<string> Hits { get; set; }
        public IList<string> Misses { get; set; }

    }
}
