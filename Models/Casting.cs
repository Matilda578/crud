using System;
using System.Collections.Generic;

#nullable disable

namespace crud.Models
{
    public partial class Casting
    {
        public int Castid { get; set; }
        public int? Actorno { get; set; }
        public int? Movieno { get; set; }

        public virtual Actor ActornoNavigation { get; set; }
        public virtual Movie MovienoNavigation { get; set; }
    }
}
