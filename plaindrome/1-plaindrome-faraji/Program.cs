using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_palinrome2_faraji
{
    class Program
    {
        static void Main(string[] args)
        {
            String s, rev = "";
            Console.WriteLine("Enter AsString: ");
            s = Console.ReadLine();
            int StrLen = s.Length - 1;
            for (int i = StrLen; i >= 0; i--)

            {
                rev += s[i].ToString();

            }
            if (rev == s)
            {
                Console.WriteLine("\n {0} String is Palindrome.", s);
                Console.WriteLine("\n Reverse is: {0} ", rev);
            }
            else
            {
                Console.WriteLine("\n {0} is not Palinerome.",s);
            }
            Console.ReadKey();
        }
    }
}
