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
            int[] arr = new int[a];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            arr = DoubleArray(arr);

            for(int i=0;  i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.ReadKey();
        }

        static int[] DoubleArray(int[] a)
        {
            int[] res = new int[a.Length*2];
            for(int i=0; i < a.Length; i++)
            {
                res[i * 2] = a[i];
                res[i * 2 + 1] = a[i];
            }
            return res;
        }
    }


}
