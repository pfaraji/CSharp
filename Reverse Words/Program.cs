using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Words
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("\n Enter Your String : ");
            string s = Console.ReadLine();
            string[] a = s.Split(' ');
            string[] b = new string[10];

            //Array.Reverse(a);         
            int pos = a.Length - 1;
            
            for (int i = 0; i <= a.Length - 1; i++)
            {
                b[i]=a[pos];
                pos--;
            }

            Console.WriteLine("\n Reverse String is:");
             for(int i=0;i<=a.Length-1;i++)
             {
               Console.Write(b[i]+""+' ');
             }
    Console.ReadKey();

          }
        }
}

