using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {

            
            FileStream fs = new FileStream(@"C:\Users\Asus\source\repos\W3G3\digits.txt", FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            String s = sr.ReadLine();
            String[] parts = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] a = new int[parts.Length];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = int.Parse(parts[i]);
            }

            FileStream fs1 = new FileStream(@"C:\Users\Asus\source\repos\W3G3\output.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);
            String ans = "";
            for(int i = 0;i < a.Length; i++)
            {
                if (isPrime(a[i])) ans+=a[i]+" ";
            }
            sw.Write(ans);
            sw.Close();
            fs1.Close();
            
            
            sr.Close();
            fs.Close();
        }
        
    
        static bool isPrime(int a)
        {
            if (a == 1) return false;
            if (a == 2) return true;
            if (a == 3) return true;
            for(int i = 2; i * i <= a; i++)
            {
                if (a % i == 0) return false;
            }
            return true;
        }
    }
}
