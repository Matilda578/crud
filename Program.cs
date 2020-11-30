using crud.Models;
using System;

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
            var userMovieAgeCheck = Convert.ToInt32(Console.ReadLine());

            var movieAgeResult = Movieclass.GetAge(context, userMovieAgeCheck);
            Console.WriteLine(movieAgeResult);
        }
    }
}
