using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Graphs
{
    internal class CourseSchedule
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CanFinish(3, new int[3][] { new int[2] { 0, 1 }, new int[2] { 0, 2 }, new int[2] { 1, 2 } }));//true
            Console.ReadLine();
        }

        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {

            Dictionary<int, List<int>> courses = new Dictionary<int, List<int>>();

            for (int i = 0; i < prerequisites.Length; i++)
            {

                if (courses.ContainsKey(prerequisites[i][1]))
                {
                    courses[prerequisites[i][1]].Add(prerequisites[i][0]);
                }
                else
                {
                    courses.Add(prerequisites[i][1], new List<int> { prerequisites[i][0] });
                }
            }

            bool[] check = new bool[numCourses];
            bool[] path = new bool[numCourses];

            for (int currCourse = 0; currCourse < numCourses; ++currCourse)
            {
                if (isCyclic(currCourse, courses, check, path))
                    return false;
            }

            return true;
        }

        /*
       * postorder DFS check that no cycle would be formed starting from currCourse
       */
        protected static bool isCyclic(
            int currCourse, Dictionary<int, List<int>> courseDict,
            bool[] check, bool[] path)
        {

            // bottom cases
            if (check[currCourse])
                // this node has been checked, no cycle would be formed with this node.
                return false;
            if (path[currCourse])
                // come across a previously visited node, i.e. detect the cycle
                return true;

            // no following courses, no loop.
            if (!courseDict.ContainsKey(currCourse))
                return false;

            // before backtracking, mark the node in the path
            path[currCourse] = true;

            bool ret = false;
            // postorder DFS, to visit all its children first.
            foreach (int child in courseDict[currCourse])
            {
                ret = isCyclic(child, courseDict, check, path);
                if (ret)
                    break;
            }

            // after the visits of children, we come back to process the node itself
            // remove the node from the path
            path[currCourse] = false;

            // Now that we've visited the nodes in the downstream,
            // we complete the check of this node.
            check[currCourse] = true;
            return ret;
        }
    }
}
