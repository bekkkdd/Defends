using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace t4
{
    class Program
    {
        static void Main(string[] args)
        {
            String fileName = "MyFile.txt";
             
            var cre = File.Create(@"C:\Users\Asus\Desktop\Defends\Lab2\task4\created\" + fileName);
            cre.Close();
            // to see that file created
            Console.ReadKey();
            File.Copy(@"C:\Users\Asus\Desktop\Defends\Lab2\task4\created\" + fileName, @"C:\Users\Asus\Desktop\Defends\Lab2\task4\copied\" + fileName, true);
            File.Delete(@"C:\Users\Asus\Desktop\Defends\Lab2\task4\created\" + fileName);

          
        }
    }
}
