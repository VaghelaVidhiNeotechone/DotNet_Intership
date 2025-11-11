using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Demo
{
    internal class Class_Object
    {
        public string Name;
        public int Age;

        public void Introduce()
        {
            Console.WriteLine($"My Name is {Name} And My Age is {Age}.");
        }

        public static void run()
        {
            Class_Object p1 = new Class_Object();
            p1.Name = "Krishiv";
            p1.Age = 25;
            p1.Introduce();
        }
    }
}
