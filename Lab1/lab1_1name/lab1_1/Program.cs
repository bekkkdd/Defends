using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_1
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = int.Parse(Console.ReadLine());
            // read String from console
            String s = Console.ReadLine();
            //parse String to array of chars
            string[] parts = s.Split();


            int count = 0;
            //checking is the digit is prime, if yes count them
            for (int i = 0; i < s.Length; i++)
            {
                if (isPrime(s[i] - '0')) count++;
            }
            // write count to the console
            Console.WriteLine(count);
            //write each prime element to console
            for (int i = 0; i < s.Length; i++)
            {
                if (isPrime(s[i] - '0')) Console.Write(s[i] + " ");
            }

            Console.ReadKey();

        }
        // func to check
        static bool isPrime(int a)
        {
            if (a < 2) return false;

            for (int i = 2; i * i <= a; i++)
            {
                if (a % i == 0) return false;
            }
            return true;
        }
    }
}
