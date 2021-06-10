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
    }
}