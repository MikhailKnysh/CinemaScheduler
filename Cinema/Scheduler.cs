using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    class Scheduler
    {
        private const int _durationCinema = 840;

        private int _currentDurationCinema = 0;
        private List<Movie> _movies;
        private Schedule _bestSchedule;
        private Schedule _currentSchedule;

        private Scheduler(List<Movie> movies)
        {
            _movies = new List<Movie>(movies);
            _currentDurationCinema = _durationCinema;
        }

        public static Scheduler GetScheduler(List<Movie> movies)
        {
            return new Scheduler(movies);
        }

        private void GetStartBestSchedule()
        {
            foreach (Movie movie in _movies)
            {
                if (_currentDurationCinema > movie.Duration)
                {
                    _currentDurationCinema -= movie.Duration;
                    _bestSchedule.ScheduleDuration += movie.Duration;

                    ++_bestSchedule.UniqeMovieCount;

                    _bestSchedule.Movies.Add(movie);
                }
                else
                {
                    break;
                }
            }
        }

        private bool CheckBestSchedule()
        {
            bool isBest = false;

            if (_currentSchedule.UniqeMovieCount > _bestSchedule.UniqeMovieCount 
                && _currentSchedule.Movies.Count > _bestSchedule.Movies.Count
                && _currentSchedule.ScheduleDuration < _bestSchedule.ScheduleDuration)
            {
                isBest = true;
            }

            return isBest;
        }

        public void GetSchedule()
        {

        }
    }
}
