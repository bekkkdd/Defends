using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string[] s = Console.ReadLine().Split();
            for(int i = 0; i < a; i++)
            {
                Console.Write(s[i] + " " + s[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
