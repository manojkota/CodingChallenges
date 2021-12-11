using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringManipulations
{
    class AlteringCharacters
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Solve("AABAAB"));
            //Console.WriteLine(MakeAnagram("cde", "abc"));
            //Console.WriteLine(MakeAnagram("cde", "dcf"));
            Console.ReadLine();
        }

        public static int Solve(string s)
        {
            var count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if((i+1) == s.Length)
                {
                    break;
                }
                if(s[i] == s[i+1])
                {
                    count++;
                }
            }

            return count;
        }
    }
}
