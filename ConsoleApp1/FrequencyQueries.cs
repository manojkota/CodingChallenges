using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FrequencyQueries
    {
        public static List<int> Execute(List<List<int>> queries)
        {
            Dictionary < int, int> num_freq_Dictionary = new Dictionary<int, int> ();
            Dictionary < int, int> freq_num_Dictionary = new Dictionary<int, int> ();

            List<int> output = new List<int>();

            queries.ForEach(x =>
            {
                if (x[0] == 1)
                {
                    if (num_freq_Dictionary.ContainsKey(x[1]))
                    {
                        Decrease(freq_num_Dictionary, num_freq_Dictionary[x[1]]);
                    }

                    Increase(num_freq_Dictionary, x[1]);
                    Increase(freq_num_Dictionary, num_freq_Dictionary[x[1]]);
                }

                if (x[0] == 2)
                {
                    if (num_freq_Dictionary.ContainsKey(x[1]))
                    {
                        Decrease(freq_num_Dictionary, num_freq_Dictionary[x[1]]);
                        Decrease(num_freq_Dictionary, x[1]);

                        if (num_freq_Dictionary.ContainsKey(x[1]))
                            Increase(freq_num_Dictionary, num_freq_Dictionary[x[1]]);
                    }
                }

                if (x[0] == 3)
                {
                    output.Add(freq_num_Dictionary.ContainsKey(x[1]) ? 1 : 0);
                }
            });

            return output;
        }

        static void Decrease(Dictionary<int, int> dictionary, int value)
        {
            if (dictionary.ContainsKey(value))
            {
                dictionary[value]--;

                if (dictionary[value] == 0)
                    dictionary.Remove(value);
            }
        }

        static void Increase(Dictionary<int, int> dictionary, int value)
        {
            if (dictionary.ContainsKey(value))
            {
                dictionary[value]++;
            }
            else
            {
                dictionary.Add(value, 1);
            }
        }
    }
}
