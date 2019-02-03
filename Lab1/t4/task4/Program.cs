using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating [*]
            String s = "[*]";
            //reading number from console
            int n = int.Parse(Console.ReadLine());
            //algorithm to create a stairs from [*]
            for (int i=1; i <=n; i++)
            {
                for(int j=0;j<i; j++)
                {
                    Console.Write(s);
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
    }
}
