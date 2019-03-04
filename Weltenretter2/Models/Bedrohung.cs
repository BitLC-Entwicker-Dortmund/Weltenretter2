using System;
using System.Collections.Generic;

namespace Weltenretter2.Models
{
    public partial class Bedrohung
    {
        public int BedrohungId { get; set; }
        public string Name { get; set; }
        public bool Existent { get; set; }
        public int AgressorId { get; set; }
        public int? HeldId { get; set; }

        public Agressor Agressor { get; set; }
        public Held Held { get; set; }
    }
}
