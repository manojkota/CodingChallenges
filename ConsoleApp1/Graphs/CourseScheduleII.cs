using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Graphs
{
    internal class CourseScheduleII
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", FindOrder(3, new int[3][] { new int[2] { 0, 1 }, new int[2] { 0, 2 }, new int[2] { 1, 2 } })));//[2,1,0]
            Console.ReadLine();
        }

        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            int[] indegree = new int[numCourses];
            int[] topologicalOrder = new int[numCourses];

            // Create the adjacency list representation of the graph
            for (var j = 0; j < prerequisites.Length; j++)
            {
                int dest = prerequisites[j][0];
                int src = prerequisites[j][1];
                if(adjList.ContainsKey(src))
                {
                    adjList[src].Add(dest);
                }
                else
                {
                    List<int> lst = new List<int>();
                    lst.Add(dest);
                    adjList.Add(src, lst);
                }

                // Record in-degree of each vertex
                indegree[dest] += 1;
            }

            // Add all vertices with 0 in-degree to the queue
            Queue<int> q = new Queue<int>();
            for (int j = 0; j < numCourses; j++)
            {
                if (indegree[j] == 0)
                {
                    q.Enqueue(j);
                }
            }

            int i = 0;
            // Process until the Q becomes empty
            while (q.Count > 0)
            {
                int node = q.Dequeue();
                topologicalOrder[i++] = node;

                // Reduce the in-degree of each neighbor by 1
                if (adjList.ContainsKey(node))
                {
                    foreach (int neighbor in adjList[node])
                    {
                        indegree[neighbor]--;

                        // If in-degree of a neighbor becomes 0, add it to the Q
                        if (indegree[neighbor] == 0)
                        {
                            q.Enqueue(neighbor);
                        }
                    }
                }
            }

            // Check to see if topological sort is possible or not.
            if (i == numCourses)
            {
                return topologicalOrder;
            }

            return new int[0];
        }
    }
}
