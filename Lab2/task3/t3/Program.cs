using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace t3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir =new DirectoryInfo(@"C:\Users\Asus\Desktop\Defends");
            printInfo(dir,0);
            
            Console.ReadKey();
        }
        static void printInfo(FileSystemInfo dir , int k)
        {
            string line = new string('\t', k);
            line += dir.Name;
            Console.WriteLine(line);
            if(dir.GetType() == typeof(DirectoryInfo))
            {
                var f = (dir as DirectoryInfo).GetFileSystemInfos();
                foreach (var i in f)
                {
                    printInfo(i, k + 1);
                }
            }
        }

        
    }
}
