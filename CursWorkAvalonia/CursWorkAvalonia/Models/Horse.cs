using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Horse
    {
        public Horse()
        {
            Runs = new HashSet<Run>();
        }

        public long HorseId { get; set; }
        public string? Name { get; set; }
        public double? Rating { get; set; }
        public string? Breed { get; set; }
        public double? Weight { get; set; }
        public long? Age { get; set; }
        public long? TrainerId { get; set; }
        public long? JockeyId { get; set; }
        public long? OwnerId { get; set; }

        public virtual Jockey? Jockey { get; set; }
        public virtual Owner? Owner { get; set; }
        public virtual Trainer? Trainer { get; set; }
        public virtual ICollection<Run> Runs { get; set; }
    }
}
