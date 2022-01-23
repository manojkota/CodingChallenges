using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tree
{
    internal class ExpressionTree
    {
        static void Main(string[] args)
        {
            TreeBuilder obj = new TreeBuilder();
            Node expTree = obj.buildTree(new string[] {"3", "4", "+", "2", "*", "7", "/"});
            Console.WriteLine(expTree.evaluate());
            Console.ReadLine();
        }

        /**
 * This is the interface for the expression tree Node.
 * You should not remove it, and you can define some classes to implement it.
 */

        public abstract class Node
        {
            public abstract int evaluate();
            // define your fields here

        };

        public class ValueNode : Node
        {
            public int Value { get; set; }

            public ValueNode(int val)
            {
                Value = val;
            }

            public override int evaluate()
            {
                return Value;
            }
        }

        public class OperatorNode : Node
        {
            public Func<int, int, int> operation;

            public Node left { get; set; }
            public Node right { get; set; }

            public OperatorNode(Func<int, int, int> operation, Node left, Node right)
            {
                this.operation = operation;
                this.left = left;
                this.right = right;
            }

            public override int evaluate()
            {
                return this.operation(left.evaluate(), right.evaluate());
            }
        }

        public static class Opearations
        {
            public static Func<int, int, int> GetOperation(char op)
            {
                switch (op)
                {
                    case '+': return (a, b) => a + b;
                    case '-': return (a, b) => a - b;
                    case '*': return (a, b) => a * b;
                    case '/': return (a, b) => a / b;
                }

                throw new InvalidOperationException();
            }
        }


        /**
         * This is the TreeBuilder class.
         * You can treat it as the driver code that takes the postinfix input 
         * and returns the expression tree represnting it as a Node.
         */

        public class TreeBuilder
        {

            public Node buildTree(string[] postfix)
            {
                var stack = new Stack<Node>();
                foreach (string s in postfix)
                {
                    Node node;
                    if (char.IsNumber(s[0]))
                    {
                        node = new ValueNode(int.Parse(s));
                    }
                    else
                    {
                        var right = stack.Pop();
                        var left = stack.Pop();

                        node = new OperatorNode(Opearations.GetOperation(s[0]), left, right);
                    }
                    stack.Push(node);
                }
                return stack.Last();
            }
        }


        /**
         * Your TreeBuilder object will be instantiated and called as such:
         * TreeBuilder obj = new TreeBuilder();
         * Node expTree = obj.buildTree(postfix);
         * int ans = expTree.evaluate();
         */
    }
}
