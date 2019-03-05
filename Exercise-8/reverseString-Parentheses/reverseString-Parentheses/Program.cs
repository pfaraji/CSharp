using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reverseString_Parentheses

{
    class Program
    {
        public class Example
    {
        public static string reverse_remove_parentheses(string str)
        {
            int lid = str.IndexOf('(');
            if (lid == -1)
            {
                return str;
            }
            else
            {
                int rid = str.IndexOf(')', lid);

                return str.Substring(0, lid) + new string(str.Substring(lid + 1, rid - lid - 1).Reverse().ToArray())
                    + str.Substring(rid + 1);
            }                                                 
        }

        public static void Main(string[] args)

        {
             String str;
                Console.WriteLine("For Example:\n");
                Console.WriteLine("p(rq)st => {0} ", reverse_remove_parentheses("p(rq)st"));

                Console.WriteLine("\nEnter A String With Parentheses:\n");
            str= Console.ReadLine();

            Console.WriteLine("\n {0} => {1} ",str,reverse_remove_parentheses(str));
                Console.ReadKey();
        }
    }
    
        
    }
}
