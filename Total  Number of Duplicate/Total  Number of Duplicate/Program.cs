using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10];
            int i, j,len, count = 0;
            Console.WriteLine("Program Total Number of Duplicate In Array");
            Console.WriteLine(  " Enter length of Array:");
            len = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            for (i = 0; i < len; i++)
            
            {
                Console.WriteLine("Enter {0} of Array:",i);
                a[i] = Convert.ToInt32(Console.ReadLine());

            }
           
            Console.WriteLine("\n");
            for (i = 0; i <= len; i++)
            {
                for (j = i + 1; j < len; j++)
                {
                    if (a[i] == a[j])
                    {
                        Console.WriteLine("Duplicate is: {0}",a[i]);
                        count++;
                        break;
                    }
                }
            }
            Console.WriteLine("The number of Duplicate Elements Present in Array is={0}", count);
            Console.ReadLine();
        }
    }
}
