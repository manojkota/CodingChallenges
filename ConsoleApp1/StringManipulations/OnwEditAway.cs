using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringManipulations
{
    /// <summary>
    /// Write a function that takes two strings and returns true if they areone awayfrom each other. 
    /// They areone awayfrom each other ifa single operation (changing a character, deleting a character or adding a character) will change one of the strings to the other. 
    /// Examples: "abcde" and"abcd" are one away (deleting a character)."a" and"a" are one away (changing the only character'a' to the equivalent character 'a')."abc" and"bcc" areNOTone away. (They are two operations away.)
    /// </summary>
    internal class OnwEditAway
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve("abcde", "abfde"));//result - true
            Console.WriteLine(Solve("abcde", "abde"));//result - true
            Console.WriteLine(Solve("abcde", "abfe"));//result - false
            Console.ReadLine();
        }

        static bool Solve(string s1, string s2)
        {
            var result = false;
            if(s1.Length == s2.Length)
            {
                result = sameLength(s1, s2);
            }
            else if (s1.Length > s2.Length)
            {
                result = differentLength(s1, s2);
            }
            else if (s1.Length < s2.Length)
            {
                result = differentLength(s2, s1);
            }
            return result;
        }

        static bool sameLength(string s1, string s2)
        {
            var x = 0;
            var y = 0;
            var diff = 0;
            while(x < s1.Length && y < s2.Length)
            {
                if(s1[x] != s2[y])
                {
                    diff++;
                    if (diff > 1)
                    {
                        break;
                    }
                }
                x++;y++;
            }
            return diff == 1;
        }

        static bool differentLength(string s1, string s2)
        {
            if(s1.Length - s2.Length > 1)
            {
                return false;
            }

            var x = 0;
            var y = 0;
            var diff = 0;
            while (x < s1.Length && y < s2.Length)
            {
                if (s1[x] != s2[y])
                {
                    diff++;
                    x++;
                    if(diff > 1)
                    {
                        break;
                    }
                }
                else
                {
                    x++;y++;
                }
            }
            return diff == 1;
        }
    }
}
