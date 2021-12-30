using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1
{
    public class RansomNote
    {
        public static void Execute(int m, int n, string mag, string noteInput)
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            if ((m < n) || (m == 0) || (n == 0))
            {
                Console.WriteLine("No");
                return;
            }

            var magazine = mag.TrimEnd().Split(' ').ToArray();
            var note = noteInput.TrimEnd().Split(' ').ToArray();

            var success = true;

            var notesGroup = note.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var magGroup = magazine.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            
            foreach (KeyValuePair<string, int> item in notesGroup)
            {
                if (!magGroup.Contains(item))
                {
                    if (magGroup.ContainsKey(item.Key) && magGroup[item.Key] < item.Value)
                    {
                        success = false;
                        break;
                    }
                }
            }
            
            Console.WriteLine(success ? "Yes" : "No");
            t.Stop();
            Console.WriteLine(t.ElapsedMilliseconds);
        }
    }
}
