using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Heap
{
    internal class MeetingRoomsII
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(MinMeetingRooms(new int[3][]
            {
                new int[2]{ 0,30},
                new int[2]{ 5,10},
                new int[2]{ 15,20},
            }));//Output - 2
            Console.ReadLine();
        }

        public int MinMeetingRoomsSol1(int[][] intervals)
        {

            // Sort in-place by start dates
            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));

            List<int> occupiedRooms = new List<int>();

            int maxCount = 0;

            for (int i = 0; i < intervals.Length; ++i)
            {

                var meeting = intervals[i];

                // Can I free up a room?
                // If any rooms end after we start, we can kill them
                occupiedRooms = occupiedRooms.Where(occupiedRoom => meeting[0] < occupiedRoom).ToList();

                // If there are currently no occupied rooms, add one with an end-date
                occupiedRooms.Add(intervals[i][1]);
                maxCount = Math.Max(maxCount, occupiedRooms.Count);
            }

            return maxCount;
        }

        public static int MinMeetingRooms(int[][] intervals)
        {

            // Check for the base case. If there are no intervals, return 0
            if (intervals.Length == 0)
            {
                return 0;
            }

            Array.Sort(intervals, delegate (int[] m, int[] n) {
                return (m[0] - n[0]);
            });

            var allocation = new Heap(new List<int>(), false);

            //Add the first meeting
            allocation.Add(intervals[0][1]);

            //iterate over remaining intervals
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] >= allocation.Peek())
                {
                    allocation.ExtractTop();
                }
                allocation.Add(intervals[i][1]);
            }
            return allocation.Size();
        }

        public class Heap
        {
            public List<int> arr { get; set; }
            public bool isMax { get; set; }
            public Heap(List<int> arr, bool isMax)
            {
                this.arr = arr;
                this.isMax = isMax;
            }

            public int Size()
            {
                return arr.Count;
            }

            public void Add(int element)
            {
                arr.Add(element);
                int i = arr.Count / 2;
                while (i > 0)
                {
                    Heapify(i);
                    i = i / 2;
                }

                return;
            }

            public void Heapify(int index)
            {
                var left = 2 * index;
                var right = 2 * index + 1;

                int root = index;
                if (left <= arr.Count && Compare(arr[left - 1], arr[index - 1], isMax))
                {
                    root = left;
                }

                if (right <= arr.Count && Compare(arr[right - 1], arr[root - 1], isMax))
                {
                    root = right;
                }

                if (root != index)
                {
                    int temp = arr[root - 1];
                    arr[root - 1] = arr[index - 1];
                    arr[index - 1] = temp;
                    Heapify(root);
                }

                return;
            }

            public int ExtractTop()
            {
                int tmp = arr[0];
                arr[0] = arr[arr.Count - 1];
                arr.RemoveAt(arr.Count - 1);
                Heapify(1);
                return tmp;
            }

            public int Peek()
            {
                return arr[0];
            }

            public bool Compare(int a, int b, bool isMax)
            {
                if (isMax)
                    return a > b;
                else
                    return a < b;
            }
        }
    }
}
