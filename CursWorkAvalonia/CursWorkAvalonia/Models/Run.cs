using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Run
    {
        public Run()
        {
            Bookmakers = new HashSet<Bookmaker>();
        }

        public long RunId { get; set; }
        public string? TypeOfRace { get; set; }
        public long? DistanceFur { get; set; }
        public long? ListOfHorseId { get; set; }
        public long? LocationId { get; set; }

        public virtual Horse? ListOfHorse { get; set; }
        public virtual Location? Location { get; set; }
        public virtual ICollection<Bookmaker> Bookmakers { get; set; }
    }
}
