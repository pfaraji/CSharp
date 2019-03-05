using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWordinString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Enter Your Sentence : ");
            string text = Console.ReadLine();

            text += " ";

            string revword = string.Empty;
            int pos = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    string tmp = text.Substring(pos, i - pos);
                    string tmp2 = string.Empty;
                    for (int j = tmp.Length - 1; j >= 0; j--)
                    {
                        tmp2 += tmp[j];
                    }
                    revword += tmp2 + " ";
                    pos = i + 1;
                }
            }
            Console.WriteLine("\n Reverse Words In String: ");
            Console.WriteLine(revword.Trim());
            Console.ReadKey();
        }   
    }
    }
