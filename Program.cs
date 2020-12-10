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

              Console.WriteLine("Please enter MovieNo: ");
              var userMovieNo = Convert.ToInt32(Console.ReadLine());

              var numberofActors = Movieclass.NumActors(context,userMovieNo);
              Console.WriteLine(numberofActors);


             Console.WriteLine("To check a Movie's age please enter the Movie No: ");
              var userMovieAgeCheck = Convert.ToInt16(Console.ReadLine());

              var movieAgeResult = Movieclass.GetAge(context, userMovieAgeCheck);
              Console.WriteLine($"The movie is {movieAgeResult} years old.");



             List<Movie> movieList = context.Movies.ToList();
              foreach (Movie moobie in movieList)
             {
                  Console.WriteLine(moobie.Title, moobie.Runtime);
              }


              var moviesearch = from movienames in context.Movies
                               where movienames.Title.StartsWith("The")
                                select movienames;

             List<Movie> moobiess = moviesearch.ToList();
              foreach (Movie mooovie in moobiess)
              {
                  Console.WriteLine(mooovie.Title);
              }



             Console.WriteLine("Please enter Movie Title: ");
              var userupdateMovieselection = Console.ReadLine();

              Console.WriteLine("Please enter the new title for the movie: ");
              var Movieuserupdatemovie = Console.ReadLine();


              var moviequery2 = from Movie in context.Movies
                                where Movie.Title.StartsWith(userupdateMovieselection)
                                select Movie;

              var moviequery2result = moviequery2.FirstOrDefault<Movie>();

              moviequery2result.Title = Movieuserupdatemovie;
              context.SaveChanges();

            //  ///b

            Console.WriteLine("Please enter the actor's fullname: ");
              var updateactorsname = Console.ReadLine();

              Console.WriteLine("Please enter the new  first name for the actor: ");
             var updateactorfirstname = Console.ReadLine();

              Console.WriteLine("Please enter the new  SURNAME for the actor: ");
             var updateactorsurname = Console.ReadLine();


             var updateactornamequery = from Actor in context.Actors
                                where Actor.Fullname.StartsWith(updateactorsname)
                               select Actor;

            var updateactornamequeryresult = updateactornamequery.FirstOrDefault<Actor>();

              updateactornamequeryresult.Givenname = updateactorfirstname;
              updateactornamequeryresult.Surname = updateactorsurname;
              context.SaveChanges();

              Console.WriteLine("Please add new title: ");
              var addnewMovieTitle = Console.ReadLine();

              Console.WriteLine("Please add new Release year: ");
              var addnewMovieRelyear = Convert.ToInt16(Console.ReadLine());

              Console.WriteLine("Please add new movienumber: ");
             var addnewMovieNumber = Convert.ToInt32(Console.ReadLine());

              Console.WriteLine("Please add new Run Time: ");
             var addnewMovierunTime = Convert.ToInt16(Console.ReadLine());

              Movie useraddMovie = new Movie { Title = addnewMovieTitle, Movieno = addnewMovieNumber, Relyear = addnewMovieRelyear, Runtime = addnewMovierunTime };

             context.Movies.AddRange(useraddMovie);
             context.SaveChanges();


            Console.WriteLine("Please add a new Actor given name: ");
            var addnewActorgivenname = Console.ReadLine();

            Console.WriteLine("Please add new Actor surname : ");
            var addnewActorSurname = (Console.ReadLine());

            Console.WriteLine("Please add new actor number: ");
            var addnewActorNumber = Convert.ToInt32(Console.ReadLine());


            Actor useraddActor = new Actor { Givenname = addnewActorgivenname, Surname = addnewActorSurname, Actorno = addnewActorNumber, Fullname = ($"{addnewActorgivenname}  {addnewActorSurname}") };

            context.Actors.AddRange(useraddActor);
            context.SaveChanges();

            Console.WriteLine("Pleas enter the actor number to be cast: ");
            var castnewActorNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Pleas search for the movie number to be cast into: ");
            var castnewActorMOVIENo = Convert.ToInt32(Console.ReadLine());


            var castingsearch = context.Castings.OrderByDescending(u => u.Castid).FirstOrDefault();



            Casting userCasting = new Casting
            {
                Actorno = castnewActorNo,
                Movieno = castnewActorMOVIENo,
                Castid = (castingsearch.Castid + 1)

            };
            context.Castings.AddRange(userCasting);
            context.SaveChanges();
        }
    }
}
