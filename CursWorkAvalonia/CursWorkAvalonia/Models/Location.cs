using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Location
    {
        public Location()
        {
            Runs = new HashSet<Run>();
        }

        public long LocationId { get; set; }
        public string? City { get; set; }
        public string? Stadium { get; set; }
        public string? Date { get; set; }

        public virtual ICollection<Run> Runs { get; set; }
    }
}
