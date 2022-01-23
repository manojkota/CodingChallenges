using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Arrays
{
    internal class SumOfSubArrayEqualsK
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumberOfSubarrays(new int[] { 1, 1, 2, 1, 1 }, 3));//OP - 2
            Console.ReadLine();
        }

        static int NumberOfSubarrays(int[] nums, int k)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = nums[i] & 1;
            }

            var dict = new Dictionary<int, int>();
            int sum = 0, count = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum == k)
                {
                    count++;
                }
                if (dict.ContainsKey(sum - k))
                {
                    count += dict[sum - k];
                }
                if (dict.ContainsKey(sum))
                {
                    dict[sum]++;
                }
                else
                {
                    dict[sum] = 1;
                }
            }
            return count;
        }
    }
}
