using System;
using System.Collections.Generic;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfFilms;
            string movieTitle;
            int movieDuration;

            Console.Write("Введите кол-во фильмов : ");
            numberOfFilms = Convert.ToInt32(Console.ReadLine());

            List<Movie> movies = new List<Movie>()
            {
                new Movie(){Title="QQQ", Duration=120},
                new Movie(){Title="WWW", Duration=95}
            };

            for (int i = 0; i < numberOfFilms; ++i)
            {
                Console.Write("Введите фильм : ");
                movieTitle = Console.ReadLine();
                Console.Write("Введите длительность фильма в минутах : ");
                movieDuration = Convert.ToInt32(Console.ReadLine());
                Movie movie = new Movie() { Title = movieTitle, Duration = movieDuration };
                movies.Add(movie);
            }


        }
    }
}
