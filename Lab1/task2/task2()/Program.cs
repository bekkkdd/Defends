using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2__
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Student
    {
        string name;
        int id, year;

        public Student(string name, int id)
        {

        }
        public String GetName()
        {
            return name;
        }
        public int GetId()
        {
            return id;
        }
        public void incrementYear(int year)
        {
            ++year;
        }
    }
}
