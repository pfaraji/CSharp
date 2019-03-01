using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delete_Element_at_position_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, pos, len;
            int[] arr1 = new int[50];



            Console.Write("\n Delete an element at desired position from an array :\n");
            Console.Write("Enter the lenght of array : ");
            len = Convert.ToInt32(Console.ReadLine());
            Console.Write("ENTER {0} elements in the array in ascending order:\n", len);
            for (i = 0; i < len; i++)
            {
                Console.Write("\n Element - {0} : ", i);
                arr1[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("\nEnter the position for delete an Array: ");

            pos = Convert.ToInt32(Console.ReadLine());
           if (pos >len)
            {
                Console.WriteLine("\n Your number is out off range.\n");
            }
            i = 0;
            while (i != pos - 1)
                i++;
           
            while (i < len)
            {
                arr1[i] = arr1[i + 1];
                i++;
            }
            len = len-1;
            Console.WriteLine("New Lenght of array is: {0}",len);
            Console.Write("\n The New Elements of Array is: ");

            for (i = 0; i <len; i++)
            {
                Console.WriteLine("\n Element [{0}]: => {1}",i, arr1[i]);
            }
            
            Console.ReadKey();
        }
    }
    }

