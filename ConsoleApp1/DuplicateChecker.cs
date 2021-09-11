using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DuplicateChecker
    {
        public List<People> FindDuplicates(List<People> originals, List<People> newPeople)
        {
            //List<People> d = new List<People>();
            return originals.Intersect(newPeople, new Comparer<People>((p1, p2) => p1.Forename.Equals(p2.Forename, StringComparison.InvariantCultureIgnoreCase) 
            && p1.Surname.Equals(p2.Surname, StringComparison.InvariantCultureIgnoreCase))).ToList();
            //for (int x = 1; x < originals.Count; x++)
            //{
            //    foreach (var np in newPeople)
            //    {
            //        if (np.Forename == originals[x].Forename &&
            //            np.Surname == originals[x].Surname)
            //        {
            //            d.Add(np);
            //            break;
            //        }
            //    }
            //}
            //return d;
        }
    }

    public class Comparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _equalityComparer;

        public Comparer(Func<T, T, bool> equalityComparer)
        {
            _equalityComparer = equalityComparer;
        }

        public bool Equals(T first, T second)
        {
            return _equalityComparer(first, second);
        }

        public int GetHashCode(T value)
        {
            return value.GetHashCode();
        }
    }

    public class People
    {
        public string Surname { get; set; }

        public string Forename { get; set; }
        public int Id { get; set; }
    }
}
