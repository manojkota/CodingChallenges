using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Arrays
{
    internal class AsteroidCollision
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", Solve(new int[3] {5, 10, -5})));//[5, 10]
            Console.ReadLine();
        }

        static int[] Solve(int[] asteroids)
        {

            var s = new Stack<int>();
            for (int a = 0; a < asteroids.Length; a++)
            {
                var ast = asteroids[a];
                var addValue = true;

                //About to collide
                while (s.Count > 0 && ast < 0 && s.Peek() > 0)
                {
                    //Blast the stack top & ast still exist
                    if (s.Peek() < -ast)
                    {
                        s.Pop();
                        continue;
                    }
                    //Both blasts
                    else if (s.Peek() == -ast)
                    {
                        s.Pop();
                        addValue = false;
                    }
                    //Stack top is greater than ast
                    addValue = false;
                    break;
                }
                if (addValue)
                {
                    s.Push(ast);
                }


            }

            var arr = new int[s.Count];
            for (int t = arr.Length - 1; t >= 0; t--)
            {
                arr[t] = s.Pop();
            }

            return arr.ToArray();
        }
    }
}
