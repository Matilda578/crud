using crud.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace crud
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MoviesContext();
            var Movieclass = new Movie();

            ////Console.WriteLine("Please enter MovieNo: ");
            ////var userMovieNo = Convert.ToInt32(Console.ReadLine());

            ////var numberofActors = Movieclass.NumActors(context,userMovieNo);
            ////Console.WriteLine(numberofActors);


            Console.WriteLine("To check a Movie's age please enter the Movie No: ");
            var userMovieAgeCheck = Convert.ToInt16(Console.ReadLine());

            var movieAgeResult = Movieclass.GetAge(context, userMovieAgeCheck);
            Console.WriteLine($"The movie is {movieAgeResult} years old.");


            
            List<Movie> movieList = context.Movies.ToList();
            foreach (Movie moobie in movieList)
            {
                Console.WriteLine(moobie.Title);
            }


            var moviesearch = from movienames in context.Movies
                             where movienames.Title.StartsWith("The")
                              select movienames;

            List<Movie> moobiess = moviesearch.ToList();
            foreach (Movie mooovie in moobiess)
            {
                Console.WriteLine(mooovie.Title);
            }
          //  var moviequeryresult = moviesearch.FirstOrDefault<Movie>();

          //  Console.WriteLine(moviequeryresult.Relyear);



        }
    }
}
