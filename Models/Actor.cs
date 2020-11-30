using System;
using System.Collections.Generic;

#nullable disable

namespace crud.Models
{
    public partial class Actor
    {
        public Actor()
        {
            Castings = new HashSet<Casting>();
        }

        public int Actorno { get; set; }
        public string Fullname { get; set; }
        public string Givenname { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Casting> Castings { get; set; }

        public void setFullName()
        {

        }
    }
}
