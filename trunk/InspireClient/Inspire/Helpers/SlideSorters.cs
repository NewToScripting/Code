using System;
using System.Collections.Generic;

namespace Inspire.Helpers
{
    public class Shuffler
    {
        private static readonly Random rng = new Random();
        public static List<ScheduledSlide> Shuffle(List<ScheduledSlide> c)
        {
            var a = new ScheduledSlide[c.Count];
            c.CopyTo(a, 0);
            var b = new byte[a.Length];
            rng.NextBytes(b);
            Array.Sort(b, a);
            return new List<ScheduledSlide>(a);
        }

        public static IEnumerable<ScheduledSlide> ShuffleSlides(List<ScheduledSlide> randomSlides, List<ScheduledSlide> normalSlides)
        {
            if (randomSlides.Count == 0)
                return normalSlides; Random r = new Random();
            int randomIndex = 0;
            int random2 = 0;
            while (randomSlides.Count > 0)
            {
                random2 = r.Next(0, randomSlides.Count);
                randomIndex = r.Next(0, normalSlides.Count); //Choose a random object in the list
                normalSlides.Insert(randomIndex,randomSlides[random2]); //add it to the new, random list<
                randomSlides.RemoveAt(random2); //remove to avoid duplicates
            }     //clean up
            randomSlides.Clear();
            randomSlides = null;
            r = null; return normalSlides; //return the new random list

        }
    }

    public class Intersperser
    {
        public static List<ScheduledSlide> Intersperse(List<Schedule> schedules)
        {
            var interspersedSlides = new List<ScheduledSlide>();
            var maxcount = 0;
            foreach (var schedule in schedules)
            {
                if (schedule.ScheduledSlides.Count > maxcount)
                    maxcount = schedule.ScheduledSlides.Count;
            }


            for (var i = 0; i < maxcount; i++)
            {
                foreach (var schedule in schedules)
                {
                    if (schedule.ScheduledSlides[i] != null)
                        interspersedSlides.Add(schedule.ScheduledSlides[i]);
                }
            }
            return interspersedSlides;
        }


        public static List<ScheduledSlide> IntersperseSlides(List<ScheduledSlide> interspersedSlides, List<ScheduledSlide> regularSlides)
        {
           // var interspersedSlides = new List<ScheduledSlide>();
            int regSlideCount = regularSlides.Count;
            int interspersedCount = interspersedSlides.Count;

            //foreach (var scheduledSlide in interspersedSlides)
            //{
            //    SlideManager.SlidePlaylist.Add(new PlayListSlide(scheduledSlide));
            //}

            if (regSlideCount >= interspersedCount)
            {
                int insertposition = 1;
                int intSlidePos = 0;
                for (int i = 0; i < regSlideCount; i++)
                {
                    if (interspersedCount > 0)
                    {
                        if (intSlidePos > interspersedCount -1)
                            intSlidePos = 0;
                        regularSlides.Insert(insertposition, interspersedSlides[intSlidePos]);
                        insertposition = insertposition + 2;
                        intSlidePos++;
                    }
                }
                return regularSlides;
            }
            else if(interspersedCount > regSlideCount)
            {
                int insertposition = 1;
                int intSlidePos = 0;
                for (int i = 0; i < interspersedCount; i++)
                {
                    if (regSlideCount > 0)
                    {
                        if (intSlidePos > regSlideCount -1)
                            intSlidePos = 0;
                        interspersedSlides.Insert(insertposition, regularSlides[intSlidePos]);
                        insertposition = insertposition + 2;
                        intSlidePos++;
                    }
                }
                return interspersedSlides;
            }
            return interspersedSlides;
        }
    }
}
