using System;
using System.Collections.Generic;

#nullable disable

namespace crud.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Castings = new HashSet<Casting>();
        }

        public int Movieno { get; set; }
        public string Title { get; set; }
        public short? Relyear { get; set; }
        public short? Runtime { get; set; }

        public virtual ICollection<Casting> Castings { get; set; }

        public int NumActors()
        {
            return 1;
        }

        public int GetAge()
        {
            return 1;
        }
    }
}
