using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Trainer
    {
        public Trainer()
        {
            Horses = new HashSet<Horse>();
        }

        public long TrainerId { get; set; }
        public string? FullName { get; set; }
        public long? Age { get; set; }
        public double? Rating { get; set; }

        public virtual ICollection<Horse> Horses { get; set; }
    }
}
