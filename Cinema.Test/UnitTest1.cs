using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Cinema.Test
{
    public class Tests
    {
        [TestCase(null)]
        public void GetScheduler_WhenDataIsNull_ShouldThrowArgumentException(
            List<Movie> valueToSet)
        {
            Assert.Throws<ArgumentException>(() => Scheduler.GetScheduler(valueToSet));
        }

        [TestCaseSource(typeof(MovieListMock))]
        public void GetStartBestSchedule_WhenMethodExecute_SouldGenerateBestSchedule(
            /*List<Movie> inputMovies,*/ Schedule expectedSchedule)
        {
            List<Movie> inputMovies = new List<Movie>()
            {
                new Movie(){Title="QQQ", Duration=120},
                new Movie(){Title="WWW", Duration=95},
                new Movie(){Title="PPP", Duration=95},
                new Movie(){Title="AAA", Duration=135}
            };

            Scheduler scheduler = Scheduler.GetScheduler(inputMovies);
            scheduler.GetStartBestSchedule();
            Schedule actualSchedule = scheduler.BestSchedule;

            Assert.AreEqual(expectedSchedule, actualSchedule);
        }
    }

    public class MovieListMock : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                //new List<Movie>()
                //{
                //    new Movie(){Title="QQQ", Duration=120},
                //    new Movie(){Title="WWW", Duration=95},
                //    new Movie(){Title="PPP", Duration=95},
                //    new Movie(){Title="AAA", Duration=135}
                //},
                new Schedule()
                {
                    Movies = new List<Movie>()
                    {
                        new Movie(){Title="QQQ", Duration=120},
                        new Movie(){Title="WWW", Duration=95},
                        new Movie(){Title="PPP", Duration=95},
                        new Movie(){Title="AAA", Duration=135}
                    },
                    UniqeMovieCount = 4,
                    ScheduleDuration = 445
                }
            };
        }
    }
}