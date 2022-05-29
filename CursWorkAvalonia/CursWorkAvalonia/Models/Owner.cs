using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Owner
    {
        public Owner()
        {
            Horses = new HashSet<Horse>();
        }

        public long OwnerId { get; set; }
        public string? FullName { get; set; }

        public virtual ICollection<Horse> Horses { get; set; }
    }
}
