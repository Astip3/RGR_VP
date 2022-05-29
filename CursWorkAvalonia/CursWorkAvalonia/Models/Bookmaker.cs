using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Bookmaker
    {
        public string OrganizationSName { get; set; } = null!;
        public long? LeadTheRase { get; set; }
        public long? RunId { get; set; }

        public virtual Run? Run { get; set; }
    }
}
