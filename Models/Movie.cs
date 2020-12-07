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
        public short Relyear { get; set; }
        public short? Runtime { get; set; }

        public virtual ICollection<Casting> Castings { get; set; }

        public int NumActors(MoviesContext context, int userInputMovie)
        {

            var sqlResult = context.Castings.Where(row => row.Movieno == userInputMovie);


            return sqlResult.Count();

        }

        public int GetAge(MoviesContext context, Int16 userInputMovie2)
        {
 
            
                var moviequery = from moviee in context.Movies
                            where moviee.Movieno == userInputMovie2
                            select moviee;

                var moviequeryresult = moviequery.FirstOrDefault<Movie>();

                Console.WriteLine(moviequeryresult.Relyear);
           
            ///add trycatch for less than 0 age   


            //var result = Convert.ToInt32(mathvariable);
            return 2020 - moviequeryresult.Relyear;


            //int mathvariable = Convert.ToInt32(2020) - Convert.ToInt32(sqlResultMovieAge.First().Relyear);



        }

        
    }
}
