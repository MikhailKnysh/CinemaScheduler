using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    class Scheduler
    {
        private const int _durationCinema = 840;
        
        public Schedule BestSchedule { get; private set; }

        private int _timeRest = 0;
        private List<Movie> _movies;
        private Schedule _currentSchedule;

        private Scheduler(List<Movie> movies)
        {
            _movies = new List<Movie>(movies);
            _currentSchedule = new Schedule();
            BestSchedule = new Schedule();
            _timeRest = _durationCinema;
        }

        public static Scheduler GetScheduler(List<Movie> movies)
        {
            return new Scheduler(movies);
        }

        public void GetStartBestSchedule()
        {
            foreach (Movie movie in _movies)
            {
                if (_timeRest > movie.Duration)
                {
                    _timeRest -= movie.Duration;
                    BestSchedule.ScheduleDuration += movie.Duration;

                    ++BestSchedule.UniqeMovieCount;

                    BestSchedule.Movies.Add(movie);
                }
                else
                {
                    break;
                }
            }
        }

        public void GetSchedule()
        {
            if (_currentSchedule != null)
            {
                foreach (var movie in _movies)
                {
                    bool isAddedFilm = false;

                    if (AddMovie(movie))
                    {
                        GetSchedule();
                        isAddedFilm = true;
                    }

                    if (CheckBestSchedule())
                    {
                        BestSchedule = _currentSchedule;
                    }

                    if (isAddedFilm)
                    {
                        RemoveFilm(movie);
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("Current schedule is null");
            }
        }

        private bool CheckBestSchedule()
        {
            bool isBest = false;

            if (_currentSchedule.UniqeMovieCount > BestSchedule.UniqeMovieCount
                && _currentSchedule.Movies.Count > BestSchedule.Movies.Count
                && _currentSchedule.ScheduleDuration > BestSchedule.ScheduleDuration)
            {
                isBest = true;
            }

            return isBest;
        }

        private bool AddMovie(Movie movie)
        {
            if (movie != null)
            {
                bool result = false;

                if (_timeRest >= movie.Duration)
                {
                    _currentSchedule.ScheduleDuration += movie.Duration;
                    _currentSchedule.Movies.Add(new Movie(movie));

                    if (_currentSchedule.Movies.Contains(movie))
                    {
                        ++_currentSchedule.UniqeMovieCount;
                    }

                    result = true;
                }

                return result;
            }

            throw new ArgumentException("Movie is null");
        }

        private void RemoveFilm(Movie movie)
        {
            if (movie != null)
            {
                if (_movies != null)
                {
                    _currentSchedule.ScheduleDuration -= movie.Duration;
                    _currentSchedule.Movies.Remove(movie);
                }
            }
        }
    }
}