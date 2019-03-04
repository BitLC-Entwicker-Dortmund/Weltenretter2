using System;
using System.Collections.Generic;

namespace Weltenretter2.Models
{
    public partial class Held
    {
        public Held()
        {
            Bedrohung = new HashSet<Bedrohung>();
        }

        public int HeldId { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Beruf { get; set; }

        public ICollection<Bedrohung> Bedrohung { get; set; }
    }
}
