using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringManipulations
{
    internal class Search_Suggestions_System
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SuggestedProducts(new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" }, "mouse"));//OP - 
            //Output:[
            //["mobile","moneypot","monitor"],
            //["mobile","moneypot","monitor"],
            //["mouse","mousepad"],
            //["mouse","mousepad"],
            //["mouse","mousepad"]
            //]
            Console.ReadLine();
        }

        static IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            var suggestions = new List<IList<string>>();
            var suggestion = new List<string>();
            StringBuilder currentSearch = new StringBuilder();
            Array.Sort(products);

            foreach (char c in searchWord)
            {
                currentSearch.Append(c);
                suggestion = new List<string>();

                foreach (string product in products)
                {
                    if (suggestion.Count >= 3)
                    {
                        break;
                    }
                    string productBatch = product.Substring(0, Math.Min(currentSearch.Length, product.Length));

                    if (productBatch.Length == currentSearch.Length && productBatch == currentSearch.ToString())
                    {
                        suggestion.Add(product);
                    }
                }
                suggestions.Add(suggestion);
            }
            return suggestions;
        }
    }
}
