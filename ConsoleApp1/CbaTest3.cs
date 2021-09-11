using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;

    public class MaxSum
    {
        public static int FindMaxSum(List<int> list)
        {
            var a = list.Max();
            list.Remove(a);
            return a + list.Max();
        }

        //public static void Main(string[] args)
        //{
        //    List<int> list = new List<int> { 5, 9, 7, 11 };
        //    Console.WriteLine(FindMaxSum(list));
        //}
    }
}
