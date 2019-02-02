using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            String s = Console.ReadLine();
            string[] parts = s.Split();


            int count = 0;
            for(int i=0;  i < s.Length; i++)
            {
                if (isPrime(s[i] - '0')) count++;
            }
            Console.WriteLine(count);
            for (int i = 0; i < s.Length; i++)
            {
                if (isPrime(s[i] - '0')) Console.Write(s[i]+" ");
            }
            Console.ReadKey();
           
        }

        static bool isPrime(int a)
        {
            if (a < 2) return false;
          
            for(int i = 2; i * i <= a; i++)
            {
                if (a % i == 0) return false;
            }
            return true;
        }


    }
}
