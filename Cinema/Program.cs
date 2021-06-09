using System;
using System.Collections.Generic;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            //int numberOfFilms;
            //string movieTitle;
            //int movieDuration;

            //Console.Write("Enter movies quantity:");
            //numberOfFilms = Convert.ToInt32(Console.ReadLine());

            List<Movie> movies = new List<Movie>()
            {
                new Movie(){Title="QQQ", Duration=120},
                new Movie(){Title="WWW", Duration=95}
            };

            Scheduler scheduler = Scheduler.GetScheduler(movies);

            scheduler.GetStartBestSchedule();
            scheduler.GetSchedule();

            foreach (var movie in scheduler.BestSchedule.Movies)
            {
                Console.WriteLine($"({movie.Title} - {movie.Duration})");
            }

            //for (int i = 0; i < numberOfFilms; ++i)
            //{
            //    Console.Write("Enter movie name: ");
            //    movieTitle = Console.ReadLine();

            //    Console.Write("Enter movie duration in minutes : ");
            //    movieDuration = Convert.ToInt32(Console.ReadLine());
            //    Movie movie = new Movie() { Title = movieTitle, Duration = movieDuration };
            //    movies.Add(movie);
            //}
        }
    }
}
