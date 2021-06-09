using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    class Movie
    {
        public string Title { get; set; }
        public int Duration { get; set; }

        public Movie()
        {

        }

        public Movie(Movie movie)
        {
            Title = movie.Title;
            Duration = movie.Duration;
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Movie)
            {
                Movie movie = (Movie)obj;

                if (Duration == movie.Duration && Title == movie.Title)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
