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
            Console.WriteLine("Enter A String: ");
            s = Console.ReadLine();
            int StrLen = s.Length -1 ;
            for (int i =StrLen;i>=0; i--)

            {
                rev += s[i].ToString();

            }
            if(rev==s)
            {
                Console.WriteLine("String is Palinrome.{0} ",s);
                Console.WriteLine("\n String Reverse is:{0} ", rev);
            }
            else
            {
                Console.WriteLine("String is not Palinerome."); 
            }
            Console.ReadKey();
        } 
    }
}
