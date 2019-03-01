using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyofElementsofArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, len;
            int[] arr1 = new int[100];
            int[] fr1 = new int[100];
            int ctr;

            Console.WriteLine("Program Count The Frequency of each elements of an Array.\n");
            Console.WriteLine("Enter the number of elements:");
            len = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            for (i = 0; i < len; i++)

            {
                Console.WriteLine("Enter {0} of Array:", i);
                arr1[i] = Convert.ToInt32(Console.ReadLine());
                fr1[i] = -1;
            }

            for (i = 0; i < len; i++)
            {
                ctr = 1;
                for (j = i + 1; j < len; j++)
                {
                    if (arr1[i] == arr1[j])
                    {
                        ctr++;
                        fr1[j] = 0;
                    }
                }

                if (fr1[i] != 0)
                {
                    fr1[i] = ctr;
                }
            }
            Console.WriteLine("\n Frequency of all elements of Array:\n");
            for (i = 0; i < len; i++)
            {
                if (fr1[i] != 0)
                {
                    Console.Write("{0} occurs {1} times.\n", arr1[i], fr1[i]);
                }
            }
            Console.ReadKey();        }
    }
}
