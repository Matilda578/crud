using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public int Relyear { get; set; }
        public short? Runtime { get; set; }

        public virtual ICollection<Casting> Castings { get; set; }

        public int NumActors(MoviesContext context, int userInputMovie)
        {

            var sqlResult = context.Castings.Where(row => row.Movieno == userInputMovie);


            return sqlResult.Count();

        }

        public int GetAge(MoviesContext context, int userInputMovie2)
        {
            var sqlResultMovieAge = context.Movies.Where<Movie>(row => row.Movieno == userInputMovie2);


            return 2020 - sqlResultMovieAge.FirstOrDefault().Relyear;  
        }

        
    }
}
