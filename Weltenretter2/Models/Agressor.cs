using System;
using System.Collections.Generic;

namespace Weltenretter2.Models
{
    public partial class Agressor
    {
        public Agressor()
        {
            Bedrohung = new HashSet<Bedrohung>();
        }

        public int AgressorId { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Spezialitaet { get; set; }

        public ICollection<Bedrohung> Bedrohung { get; set; }
    }
}
