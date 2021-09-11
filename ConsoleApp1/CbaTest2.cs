using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;

    public class UnloadingTime
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public UnloadingTime(DateTime start, DateTime end)
        {
            this.Start = start;
            this.End = end;
        }

       
    }

    public static class UnloadingTrucks
    {
        public static bool CanUnloadAll(IEnumerable<UnloadingTime> unloadingTimes)
        {
            var overlapCount = 0;

            
            foreach (var item in unloadingTimes.OrderBy(x => x.Start))
            {
                if(overlapCount > 2)
                {
                    break;
                }
                var c = unloadingTimes.Except(new List<UnloadingTime>() { item }).Count(x =>
                  x.Start < item.End && item.Start < x.End);
                overlapCount += c;
                
            }
            return overlapCount <= 2;
        }

        //public static void Main(string[] args)
        //{
        //    var format = System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat;

        //    UnloadingTime[] unloadingTimes = new UnloadingTime[]
        //    {
        //    new UnloadingTime(DateTime.Parse("3/4/2019 19:00", format), DateTime.Parse("3/4/2019 20:30", format)),
        //    new UnloadingTime(DateTime.Parse("3/4/2019 22:10", format), DateTime.Parse("3/4/2019 22:30", format)),
        //    new UnloadingTime(DateTime.Parse("3/4/2019 20:30", format), DateTime.Parse("3/4/2019 22:00", format))
        //    };

        //    Console.WriteLine(UnloadingTrucks.CanUnloadAll(unloadingTimes));
        //}
    }
}
