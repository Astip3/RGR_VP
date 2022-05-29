using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Jockey
    {
        public Jockey()
        {
            Horses = new HashSet<Horse>();
        }

        public long JockeyId { get; set; }
        public string? FullName { get; set; }
        public double? Weight { get; set; }
        public long? Growth { get; set; }

        public virtual ICollection<Horse> Horses { get; set; }
    }
}
